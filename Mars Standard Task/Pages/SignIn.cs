using Mars_Standard_Task.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mars_Standard_Task.Pages
{
    class SignIn
    {
        // Finding the SignIn link
        private IWebElement SignIntab => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));

        // Finding the Email Field
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.Name("password"));

        //Finding the Login Button
        private IWebElement LoginBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        internal void LoginSteps()
        {
            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(GlobalDefinitions.ReadJson(),"SignIn");

            //Navigate to the Url
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            GlobalDefinitions.driver.Manage().Window.Maximize();
            Thread.Sleep(500);
            //Click on Sign In tab
            SignIntab.Click();
            Thread.Sleep(500);

            //Enter the data in Username textbox
            Email.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Thread.Sleep(500);

            //Enter the password 
            Password.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            LoginBtn.Click();
            Thread.Sleep(2000);

            string text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]")).Text;

            if (text == "Mars Logo")
            {
                Console.WriteLine("Login Successful");
            }
            else
                Console.WriteLine("Login Unsuccessful");

        }
    }
}
