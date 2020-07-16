using MarsFramework.Global;
using MarsProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class ProfileFeaturesMarsProjectSteps
    {
        [Given(@"I logged in the system and click on Profile DropDown box")]
        public void GivenILoggedInTheSystemAndClickOnProfileDropDownBox()
        {
            //Logging into Mars Project 
            SignInMarsProject Login = new SignInMarsProject();
            Login.LoginSteps();

            //Clicking on Profile DropDownBox 
            ProfilePage profile = new ProfilePage();

            By WaitCondition = By.XPath("//span[@tabindex='0']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            profile.ClickProfileDropDown();
        }

        [Given(@"Click on ChangePassword Button")]
        public void GivenClickOnChangePasswordButton()
        {
            //Clicking on ChangePassword Button 
            ProfilePage profile = new ProfilePage();
            profile.ClickChangePassword();
        }
        
        [When(@"I provide the value for fields '(.*)', '(.*)' and '(.*)'")]
        public void WhenIProvideTheValueForFieldsAnd(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            //Sending Old Password
            GlobalDefinitions.driver.FindElement(By.Name("oldPassword")).SendKeys(OldPassword);

            //Sending New Password
            GlobalDefinitions.driver.FindElement(By.Name("newPassword")).SendKeys(NewPassword);

            //Sending Confirm Password
            GlobalDefinitions.driver.FindElement(By.Name("confirmPassword")).SendKeys(ConfirmPassword);

            //Click on Save button
            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button ui teal button']")).Click();
        }

        [Then(@"the password should change successfully by returning to home page")]
        public void ThenThePasswordShouldChangeSuccessfullyByReturningToHomePage()
        {
            bool result = ProfilePage.ValidateChangePassword(GlobalDefinitions.driver);
            Assert.IsTrue(result);
        }
    }
}
