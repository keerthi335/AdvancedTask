using MarsFramework.Global;
using MarsFramework.Pages;
using MarsProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class ShareSkillMarsProjectSteps
    {
        [Given(@"I am logged into the profile and clicked the ShareSkill button")]
        public void GivenIAmLoggedIntoTheProfileAndClickedTheShareSkillButton()
        {
            //Logging into Mars Project 
            SignInMarsProject Login = new SignInMarsProject();
            Login.LoginSteps();


            //Clicking on ShareSkill Button 
            ProfilePage profile = new ProfilePage();
            profile.ClickShareSkillButton();
        }

        [When(@"I entered the skill details")]
        public void WhenIEnteredTheSkillDetails()
        {
            By WaitCondition1 = By.XPath("//input[@name='title']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            ShareSkill shareSkill = new ShareSkill();
            shareSkill.EnterShareSkill();
        }
        
        [Then(@"the new skill should be added in the ManageListings tab")]
        public void ThenTheNewSkillShouldBeAddedInTheManageListingsTab()
        {
            bool Result = ShareSkill.ValidateShareSkillPage();
            Assert.IsTrue(Result);
        }
    }
}
