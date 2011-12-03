using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GDNET.Common.Base.Entities;

namespace WebFrameworkData.UnitTest
{
    public static class VerificationUtils
    {
        public static void EmptyCreMod(IEntityCreMod entity)
        {
            Assert.IsTrue(string.IsNullOrEmpty(entity.CreatedBy));
            Assert.IsTrue(string.IsNullOrEmpty(entity.LastModifiedBy));
            Assert.IsTrue(entity.CreatedAt == default(DateTime));
            Assert.IsTrue(entity.LastModifiedAt == null);
        }
    }
}
