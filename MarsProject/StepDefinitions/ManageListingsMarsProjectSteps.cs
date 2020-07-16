using MarsFramework.Pages;
using MarsProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class ManageListingsMarsProjectSteps
    {
        [Given(@"I am logged into the profile and click on ManageListings tab")]
        public void GivenIAmLoggedIntoTheProfileAndClickOnManageListingsTab()
        {
            //Logging into Mars Project 
            SignInMarsProject Login = new SignInMarsProject();
            Login.LoginSteps();

            //Clicking on ManageListings tab
            ProfilePage profile = new ProfilePage();
            profile.ClickManageListingsTab();
        }
        
        [Given(@"click the Edit button of '(.*)'")]
        public void GivenClickTheEditButtonOf(string editskill)
        {
            ManageListingsPage ManageListings = new ManageListingsPage();
            ManageListings.ClickEditListings(editskill);
        }
        
        [Given(@"click the Delete button of '(.*)'")]
        public void GivenClickTheDeleteButtonOf(string deleteskill)
        {
            ManageListingsPage ManageListings = new ManageListingsPage();
            ManageListings.ClickDeleteListings(deleteskill);
        }
        
        [When(@"I entered the details of skill")]
        public void WhenIEnteredTheDetailsOfSkill()
        {
            ShareSkill EditSkillInstance = new ShareSkill();
            EditSkillInstance.EnterShareSkill();
        }
        
        [Then(@"the '(.*)' item should be added in the ManageListings tab")]
        public void ThenTheItemShouldBeAddedInTheManageListingsTab(string validateEdit)
        {
            bool result = ManageListingsPage.ValidateEdit(validateEdit);
            Assert.IsTrue(result);
        }
        
        [Then(@"the '(.*)' should be removed from ManageListings tab")]
        public void ThenTheShouldBeRemovedFromManageListingsTab(string validateDelete)
        {
            bool result = ManageListingsPage.ValidateDelete(validateDelete);
            Assert.IsTrue(result);
        }
    }
}
