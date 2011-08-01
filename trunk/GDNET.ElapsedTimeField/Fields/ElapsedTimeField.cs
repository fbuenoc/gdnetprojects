using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage;
using Orchard.Environment.Extensions;

namespace GDNET.ElapsedTimeField.Fields
{
    [OrchardFeature(Constants.ElapsedTimeField)]
    public class ElapsedTimeField : ContentField
    {
        public string ElapsedTime
        {
            get
            {
                return Storage.Get<string>();
            }
            set
            {
                Storage.Set<string>(value);
            }
        }
    }
}