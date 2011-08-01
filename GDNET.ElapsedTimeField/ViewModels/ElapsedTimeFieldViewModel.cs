using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDNET.ElapsedTimeField.ViewModels
{
    public class ElapsedTimeFieldViewModel
    {
        public string Name { get; set; }
        public uint Years { get; set; }
        public uint Months { get; set; }
        public uint Days { get; set; }
        public uint Hours { get; set; }
        public uint Minutes { get; set; }
    }
}