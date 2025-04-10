using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Zynergy.Hooks
{
    [Binding]
    class report_hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName +
     Path.DirectorySeparatorChar + "Reports"
    + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            Directory.CreateDirectory(reportpath);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Path.Combine(reportpath, "test.html"));
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);

        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            //context.Set("node", scenario);
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext context)
        {
            step = scenario;
            //context.Set("step", step);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else
            {
                step.Log(Status.Fail, context.TestError.Message);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }


    }
}
