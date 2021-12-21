using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LinkedIn_Applier
{
    public static class Logs
    {
        public static string LogFolder { get; set; }
        public static string LogFile { get; set; }
        public static string LogFileName => LogFolder + "/" + LogFile;
        public static void Write(string Message)
        {
            if (!Directory.Exists(LogFolder)) Directory.CreateDirectory(LogFolder);

            System.Diagnostics.Debug.WriteLine(message: Message);

            DataSet ds = new DataSet();
            if (File.Exists(LogFileName))
            {
                ds.ReadXml(LogFileName);
            }
            else
            {

                ds.Tables.Add(new DataTable("Logs", "LinkedIn"));
                ds.Tables[0].Columns.Add("Messages");
            }
            ds.Tables[0].Rows.Add(Message);
            ds.DataSetName = "LinkedinLogs";
            ds.Namespace = ("LinkedinLogs");
            ds.WriteXml(LogFileName);
            ds.Dispose();

        }



    }
}
