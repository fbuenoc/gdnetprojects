using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Web.Mvc.Base
{
    public abstract class ModelBase
    {
        public string ModeleId
        {
            get;
            protected set;
        }

        public ModelBase(bool autoGenerateId)
        {
            if (autoGenerateId)
            {
                this.ModeleId = Guid.NewGuid().ToString();
            }
        }

        public ModelBase(string modeleId)
        {
            this.ModeleId = modeleId;
        }
    }
}
