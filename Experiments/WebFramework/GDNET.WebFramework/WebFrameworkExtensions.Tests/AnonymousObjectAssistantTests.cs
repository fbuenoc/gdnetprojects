using System.Collections.Generic;
using GDNET.Extensions;
using NUnit.Framework;

namespace WebFrameworkExtensions.Tests
{
    [TestFixture]
    public class AnonymousObjectAssistantTests
    {
        [Test]
        public void FromDictionaryTest1()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("K1", "V1");
            dict.Add("K2", "V2");

            var objet = AnonymousObjectAssistant.FromDictionary(dict);
        }
    }
}
