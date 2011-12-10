using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using NUnit.Framework;

using GDNET.Web.Mvc.Extensions;

namespace GDNET.Web.Mvc.Tests.Extensions
{
    [TestFixture]
    public class HtmlDynamicInputTests
    {
        private class TestViewDataContainer : IViewDataContainer
        {
            public ViewDataDictionary ViewData
            {
                get;
                set;
            }
        }

        [Test]
        public void BuildInput_TestInputText()
        {
            var html = new HtmlHelper(new ViewContext(), new TestViewDataContainer());
            var result = html.BuildInput("1:01;10:015;11:255;12:32;");
            Assert.AreEqual("<input type='text' maxlength='255' size='32' {0} />", result.ToHtmlString());
        }

        [Test]
        public void BuildInput_TestInputPassword()
        {
            var html = new HtmlHelper(new ViewContext(), new TestViewDataContainer());
            var result = html.BuildInput("1:01;10:013;11:255;12:32;");
            Assert.AreEqual("<input type='password' maxlength='255' size='32' {0} />", result.ToHtmlString());
        }

        [Test]
        public void BuildInput_TestTextArea()
        {
            var html = new HtmlHelper(new ViewContext(), new TestViewDataContainer());
            var result = html.BuildInput("1:02;17:3;18:2;");
            Assert.AreEqual("<textarea rows='3' cols='2' >{0}</textarea>", result.ToHtmlString());
        }
    }
}
