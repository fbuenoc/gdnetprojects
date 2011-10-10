using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuyenMua.MobileWeb.Common
{
    public class QueryStringConstants
    {
        public const string Mode = "m";
        public const string Id = "id";
    }

    public enum QueryStringMode
    {
        None = 0,
        Create,
        Delete,
        Edit,
        View,
    }
}