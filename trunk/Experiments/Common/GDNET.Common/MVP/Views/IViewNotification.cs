using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;

namespace GDNET.Common.MVP
{
    /// <summary>
    /// Display a message
    /// </summary>
    public interface IViewNotification
    {
        bool Visible { get; set; }
        bool IsError { get; set; }
        string Message { get; set; }
    }
}
