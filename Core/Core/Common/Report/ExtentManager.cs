using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;

namespace NT.Core.ReportHelper
{
    public class ExtentManager
    {
        private static string reportDirectory = "Report\\" + DateTime.Now.ToString("dddd, dd MMMM yyyy, HH-mm ss.fffffffK").Replace(":", "-") + "   " + DataGenerator.GenerateString(10) + "\\";
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        public static void SetDirectory(string directory)
        {
            reportDirectory = directory;
        }

        static ExtentManager()
        {
            var htmlReporter = new ExtentHtmlReporter(reportDirectory);
            htmlReporter.Config.DocumentTitle = "Extent/NUnit Samples";
            htmlReporter.Config.ReportName = "Extent/NUnit Samples";
            htmlReporter.Config.Theme = Theme.Standard;

            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}