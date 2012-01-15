using System;
using GDNET.Common.Base;
using NUnit.Framework;

namespace WebFrameworkData.UnitTest
{
    public static class VerificationUtils
    {
        public static void EmptyCreMod(IModification entity)
        {
            Assert.IsTrue(string.IsNullOrEmpty(entity.CreatedBy));
            Assert.IsTrue(string.IsNullOrEmpty(entity.LastModifiedBy));
            Assert.IsTrue(entity.CreatedAt == default(DateTime));
            Assert.IsTrue(entity.LastModifiedAt == null);
        }
    }
}
