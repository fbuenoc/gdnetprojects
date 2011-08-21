using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.Domain
{
    /// <summary>
    /// Base object with generic Id.
    /// </summary>
    /// <typeparam name="TId">Type of object' Id</typeparam>
    public abstract class DomainBase<TId>
    {
        public virtual TId Id
        {
            get;
            set;
        }
    }
}
