using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GDNET.Extensions.NHibernateImpl;
using GoogleCode.Data.Mapping;

namespace GoogleCodeAnalyzer
{
    static class Program
    {
        private const string DefaultCfgFile = "hibernate.cfg.xml";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NHSessionManager.Initialize(MappingUtil.GetHbmMapping(), DefaultCfgFile);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
