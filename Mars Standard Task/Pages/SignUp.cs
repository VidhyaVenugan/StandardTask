using Mars_Standard_Task.Global;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Mars_Standard_Task.Pages
{
    class SignUp
    {
        #region  Initialize Web Elements 
        //Finding the Join 
        private IWebElement Join => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));

        //Identify FirstName Textbox
        private IWebElement FirstName => GlobalDefinitions.driver.FindElement(By.Name("firstName"));

        //Identify LastName Textbox
        private IWebElement LastName => GlobalDefinitions.driver.FindElement(By.Name("lastName"));

        //Identify Email Textbox
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.Name("email"));

        //Identify Password Textbox
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.Name("password"));

        //Identify Confirm Password Textbox
        private IWebElement ConfirmPassword => GlobalDefinitions.driver.FindElement(By.Name("confirmPassword"));

        //Identify Term and Conditions Checkbox
        private IWebElement Checkbox => GlobalDefinitions.driver.FindElement(By.Name("terms"));

        //Identify join button
        private IWebElement JoinBtn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        #endregion

        internal void Register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(GlobalDefinitions.ReadJson(), "SignUp");
            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();

        }
    }
}
