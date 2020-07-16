using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class SignInMarsProject
    {
        
            //Click on Sign In Tab
           private IWebElement SignIntab => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));
           // SignIntab.Click();

            // Email field
            private IWebElement Email => GlobalDefinitions.driver.FindElement(By.Name("email"));
            
            //Password field
            private IWebElement Password => GlobalDefinitions.driver.FindElement(By.Name("password"));
            

            //Clicking on Login Button
            private IWebElement LoginBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        
        public void LoginSteps()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            
            //Click on Sign In Tab
            SignIntab.Click();

            //Passing id and password
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            
            //Click on LogIn Button
            LoginBtn.Click();


        }
    }
}
