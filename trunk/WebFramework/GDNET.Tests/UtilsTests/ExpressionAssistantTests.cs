using GDNET.Domain.Base;
using GDNET.Utils;
using NUnit.Framework;

namespace GDNET.Tests.UtilsTests
{
    [TestFixture]
    public class ExpressionAssistantTests
    {
        [Test]
        public void CanGetPropertyName()
        {
            var x = default(IEntity);
            var s = ExpressionAssistant.GetPropertyName(() => x.Signature);
            Assert.AreEqual("Signature", s);
        }
    }
}
