using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedIn_Applier.DataAccess.Concrete.EntityFramework
{
    public class LinkedInContext : DbContext
    {
        public string ConnectionStringProp { private get; set; }
        const string dbName = "LinkedIn";
        string LocalSqlServer = $"Server=.;Database=db{dbName};Trusted_Connection=True;";
        string LocalSqlite = $"Data Source=C://db{dbName}.db";
        DatabaseSystem dbSysem;

        #region DebugModeSettings
        /// <summary>
        /// Sqlite local database ( FOR TESTS )
        /// </summary>
        public LinkedInContext()
        {
            ConnectionStringProp = LocalSqlite;
            dbSysem = DatabaseSystem.Sqlite;
        }

        /// <summary>
        /// Sqlserver or Sqlite local connections ( FOR TESTS )
        /// </summary>
        /// <param name="system"></param>
        public LinkedInContext(DatabaseSystem system)
        {
            switch (system)
            {
                case DatabaseSystem.SqlServer:
                    ConnectionStringProp = LocalSqlServer;
                    break;
                case DatabaseSystem.Sqlite:
                    ConnectionStringProp = LocalSqlite;

                    break;
                default:
                    break;
            }
            dbSysem = system;
        }

        #endregion


        #region ReleaseModeSettings
        /// <summary>
        /// Release connection
        /// </summary>
        /// <param name="system">Database system</param>
        /// <param name="ConnectionString">Connection string</param>
        public LinkedInContext(DatabaseSystem system, string ConnectionString)
        {
            dbSysem = system;
            ConnectionStringProp = ConnectionString;
        }
        #endregion


        #region DbSets
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Setting> ClientSettings { get; set; }
        public DbSet<Location> Locations { get; set; }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (dbSysem)
            {
                case DatabaseSystem.SqlServer:
                    optionsBuilder.UseSqlServer(ConnectionStringProp, builder =>
                    {
                        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

                    });
                    base.OnConfiguring(optionsBuilder);
                    break;
                case DatabaseSystem.Sqlite:
                    optionsBuilder.UseSqlite(ConnectionStringProp);
                    break;
                default:
                    break;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

        #region SaveChangesOverrides
        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added || EntityState.Deleted == entry.State
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    if (Debugger.IsAttached)
                    {
                        Debug.Indent();
                        foreach (var valid in validationResults)
                        {
                            Debug.WriteLine(string.Join(",", valid.MemberNames) + " is not validated! Error:" + valid.ErrorMessage);
                        }

                        Debug.Unindent();
                    }
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added || EntityState.Deleted == entry.State
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    if (Debugger.IsAttached)
                    {
                        Debug.Indent();
                        foreach (var valid in validationResults)
                        {
                            Debug.WriteLine(string.Join(",", valid.MemberNames) + " is not validated! Error:" + valid.ErrorMessage);
                        }

                        Debug.Unindent();
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion
        public enum DatabaseSystem
        {
            SqlServer,
            Sqlite
        }
    }
}
