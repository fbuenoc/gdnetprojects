using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDNET.ElapsedTimeField.Settings
{
    public enum ElapsedTimeFieldDisplay
    {
        FullValue,
        MeaningValueOnly
    }

    public class ElapsedTimeFieldSettings
    {
        public ElapsedTimeFieldDisplay Display
        {
            get;
            set;
        }
    }
}