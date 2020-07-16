using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using MarsFramework.Global;
using MarsFramework.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;
using MarsFramework.Config;
using TechTalk.SpecFlow;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports.Model;
using OpenQA.Selenium;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class BaseHooks : Base
    {
        #region Before Scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/");

            #region Initialise Reports
            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(projectPath + "XMLFile.xml");

            #endregion
        }    

            #endregion
               
        

        [AfterScenario]
        public void AfterScenario()
        {
            //Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test = extent.StartTest("Mars Reports - Advanced task");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
           
            // Close the driver           
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
    }
}
