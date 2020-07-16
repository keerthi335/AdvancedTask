using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using MarsFramework.Global;


namespace MarsProject.Pages
{
    public class ProfilePage
    {
        //Elements

        //Profile DropDownBox
        private IWebElement ProfileDropDownBox => GlobalDefinitions.driver.FindElement(By.XPath("//span[@class='item ui dropdown link ']"));

        //Finding ManageListings Button
        private IWebElement ManageListingsTab => GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //Finding ShareSkill button
        private IWebElement ShareSkillButton => GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='ui basic green button']"));


        internal void ClickProfileDropDown()
        {
            ProfileDropDownBox.Click();
        }

        internal void ClickChangePassword()
        {
            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            IWebElement ChangePassword = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@tabindex=\"0\"]//a[contains(text(),'Change Password')]")));
            ChangePassword.Click();
        }

        public static bool ValidateChangePassword(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//button[text()='Sign Out']"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal void ClickShareSkillButton()
        {
            By WaitCondition = By.XPath("//a[@class='ui basic green button']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            ShareSkillButton.Click();
        }
        internal void ClickManageListingsTab()
        {
            By WaitCond = By.XPath("//a[@href='/Home/ListingManagement']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCond, 60);

            ManageListingsTab.Click();
        }
    }
}
