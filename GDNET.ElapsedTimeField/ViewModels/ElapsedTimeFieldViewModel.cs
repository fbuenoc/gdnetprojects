using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDNET.ElapsedTimeField.Models;

namespace GDNET.ElapsedTimeField.ViewModels
{
    public class ElapsedTimeFieldViewModel
    {
        public string Name { get; set; }
        public ElapsedTimeInfo Data { get; set; }
    }
}