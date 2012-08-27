using System;
using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Entities.System
{
    public partial class Employee : EntityHistoryComplex
    {
        public virtual DateTime StartDate
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        protected internal Employee() { }
    }
}
