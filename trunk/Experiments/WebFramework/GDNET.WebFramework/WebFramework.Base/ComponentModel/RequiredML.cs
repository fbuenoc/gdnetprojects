﻿using System.ComponentModel.DataAnnotations;

namespace WebFramework.Base.ComponentModel
{
    public sealed class RequiredML : RequiredAttribute
    {
        public string ErrorCode
        {
            get;
            set;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
