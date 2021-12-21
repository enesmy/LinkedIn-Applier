using System;

namespace LinkedIn_Applier.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDateTime { get; set; }

    }
}