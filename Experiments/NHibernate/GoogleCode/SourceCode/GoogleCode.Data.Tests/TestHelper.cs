using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleCode.Core.Domain;

namespace GoogleCode.Data.Tests
{
    public class TestHelper
    {
        public static Project NewProject(int id)
        {
            return new Project
            {
                Name = "Project " + id,
                Activity = "High",
                Description = "This is project " + id,
                Homepage = "/p/gdnetprojects/",
                LastUpdate = DateTime.Today,
                LogoUrl = ""
            };
        }

        public static Label NewLabel(int id)
        {
            return new Label
            {
                Name = "Label " + id
            };
        }
    }
}
