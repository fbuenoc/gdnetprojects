using GDNET.Utils;
using NUnit.Framework;

namespace GDNET.Tests.UtilsTests
{
    [TestFixture]
    public class RandomAssistantTests
    {
        [Test]
        public void CanGenerateEmailAddress()
        {
            var s = RandomAssistant.GenerateEmailAddress();
            Assert.IsNotEmpty(s);
            Assert.IsTrue(s.Contains("@"));
            Assert.IsTrue(s.Contains("."));
        }
    }
}
