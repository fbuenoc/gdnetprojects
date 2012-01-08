using System;

namespace GDNET.Common.Base
{
    public interface IModification
    {
        /// <summary>
        /// Created by email
        /// </summary>
        string CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Last modified by email
        /// </summary>
        string LastModifiedBy
        {
            get;
            set;
        }

        DateTime? LastModifiedAt
        {
            get;
            set;
        }
    }
}
