using Mars_Standard_Task.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mars_Standard_Task.Pages
{
    class Profile
    {
        //Find  profile tab
        private IWebElement profileTab => GlobalDefinitions.driver.FindElement(By.LinkText("Profile"));
        
        //Find profile picture
        private IWebElement image => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='image']/img"));
        
        //Find Name Dropdown
        private IWebElement nameDropDown => GlobalDefinitions.driver.FindElement(By.XPath("//i[1][@class='dropdown icon']"));
        
        //Find first name 
        private IWebElement firstName => GlobalDefinitions.driver.FindElement(By.Name("firstName"));
        
        //Find Last name
        private IWebElement lastName => GlobalDefinitions.driver.FindElement(By.Name("lastName"));
        
        //Find Name save button
        private IWebElement nameSave => GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Save')]"));
        
        //Find Availability Edit button
        private IWebElement availEdit => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='extra content']/div/div[2]/div/span/i"));
        
        //Find Availability subdropdown
        private IWebElement availDropDown => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='right floated content']/span/select"));
        
        // Find availablity option
        //private IWebElement Availoption => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
        
        //Find Hours edit button
        private IWebElement hoursEdit => GlobalDefinitions.driver.FindElement(By.XPath("(//div[@class='right floated content'])[3]/span/i"));
        
        //Find hours dropdown
        private IWebElement hoursDropDown => GlobalDefinitions.driver.FindElement(By.XPath("(//div[@class='right floated content'])[3]/span/select"));
        
        //Find hours option
        //private IWebElement hoursoption => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[3]"));
        
        //Find Earn Target edit button
        private IWebElement earnEdit => GlobalDefinitions.driver.FindElement(By.XPath("(//div[@class='right floated content'])[4]/span/i"));
        
        //Find Earn Target dropdown
        private IWebElement earnDropDown => GlobalDefinitions.driver.FindElement(By.XPath("(//div[@class='right floated content'])[4]/span/select"));
        
        //Find Earn Target option
        //private IWebElement earnoption => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]"));
        
        //Find Description Edit icon
        private IWebElement descriptionEdit => GlobalDefinitions.driver.FindElement(By.XPath("//h3/span/i"));

        //Clear the description textbox
        private IWebElement descriptionClear => GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name='value']"));
        
        //Find Description textbox
        private IWebElement enterDescription => GlobalDefinitions.driver.FindElement(By.Name("value"));
        
        //Find Description save button
        private IWebElement descriptionSave => GlobalDefinitions.driver.FindElement(By.XPath("(//button[contains(text(),'Save')])[2]"));
        
        //Find language tab
        private IWebElement languageTab => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
        
        //Find Add New Language button
        private IWebElement newLanguage => GlobalDefinitions.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]"));

        //Find Add language textbox
        private IWebElement addLanguage => GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //Find for choose language dropdown
        private IWebElement languageDropDown => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='fields']/div[2]/select"));
        
        //Find xpath for  any option from dropdown
      //  private IWebElement SelectLanguage => GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        
        //Find add button
        private IWebElement add => GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Add']"));
        
        
        public void ProfileSteps()
        {
                        
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(GlobalDefinitions.ReadJson(), "Profile");

            //Click on profile tab
            profileTab.Click();
                       
            //Enter FirstName and LastName
            nameDropDown.Click(); //Click on Profile Name drop Down
            Thread.Sleep(1500);

            firstName.Clear(); //Clear text from First name textbox
            Thread.Sleep(1500);

            firstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));//Enter first name in textbox1
            Thread.Sleep(1500);

            lastName.Clear();//Clear last name textbox
            Thread.Sleep(1500);

            lastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));//Enter last name in textbox 2
            nameSave.Click();//Click on save button to save Profile Name
            Thread.Sleep(1500);
            
            string ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Changed Profile Name"); 
            string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='title']")).Text;
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Changed Profile Name"), ActualValue);
            Thread.Sleep(500);
            if (ExpectedValue == ActualValue)
            {
                Console.WriteLine("Test Passed : Profile Name Changed Successfully");
            }

            else
                Console.WriteLine("Test Failed : Profile not changed");

            //Click on Edit Availability Icon
            availEdit.Click();//Click on avaliability icon button
            Thread.Sleep(1500);
            availDropDown.Click(); //Click on availability dropdown
            Thread.Sleep(1500);
            //Availoption.Click();//Select availability option from dropdown
            IList<IWebElement> availableTime = availDropDown.FindElements(By.TagName("option"));
            int count = availableTime.Count;
            Console.WriteLine("Number of available time : " + count);
            for (int i = 0; i < count; i++)
            {
                if (availableTime[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Availability"))
                {
                    availableTime[i].Click();
                    Console.WriteLine("Time has been successfully selected");
                    break;
                }
            }

            //Click on Hours edit icon button
            hoursEdit.Click();
            Thread.Sleep(1500);
            hoursDropDown.Click();
            Thread.Sleep(1500);
            IList<IWebElement> hours = hoursDropDown.FindElements(By.TagName("option"));
            int hoursCount = hours.Count;
            Console.WriteLine("Number of hours : " + hoursCount);
            for (int i = 0; i < hoursCount; i++)
            {
                if (hours[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Hours"))
                {
                    hours[i].Click();
                    Console.WriteLine("Hours has been successfully selected");
                    break;
                }
            }

            //Click on earn target icon button
            earnEdit.Click();
            Thread.Sleep(1500);
            earnDropDown.Click();
            Thread.Sleep(1500);
            IList<IWebElement> earnTarget = earnDropDown.FindElements(By.TagName("option"));
            int earnCount = earnTarget.Count;
            Console.WriteLine("Number of earn target : " + earnCount);
            for (int i = 0; i < earnCount; i++)
            {
                if (earnTarget[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Earn Target"))
                {
                    earnTarget[i].Click();
                    Console.WriteLine("Earn Target has been successfully selected");
                    break;
                }
            }

            //Enter Description
            Thread.Sleep(1500);
            descriptionEdit.Click();
            Thread.Sleep(1500);
            descriptionClear.Clear();
            Thread.Sleep(1500);
            enterDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(1500);
            descriptionSave.Click();
            Thread.Sleep(1500);

            //Add a language
            languageTab.Click();
            Thread.Sleep(1500);

            newLanguage.Click();
            Thread.Sleep(1500);

            addLanguage.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
            Thread.Sleep(1500);

            languageDropDown.Click();
            Thread.Sleep(1500);
            IList<IWebElement> languageLevel = languageDropDown.FindElements(By.TagName("option"));
            int languageLevelCount = languageLevel.Count;
            Console.WriteLine("Number of language levels : " + languageLevelCount);
            for (int i = 0; i < languageLevelCount; i++)
            {
                if (languageLevel[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Language Level"))
                {
                    languageLevel[i].Click();
                    Console.WriteLine("Language level has been successfully selected");
                    break;
                }
            }

            add.Click();
            Thread.Sleep(1000);
            bool languageFound = true;
            string beforeXpath = "//tbody[";
            string afterXpath = "]/tr/td[1]";
            string ExpectedValue1 = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
            IList<IWebElement> languageList = GlobalDefinitions.driver.FindElements(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
            int languageCount = languageList.Count;
            Console.WriteLine("Number of languages in the table : " + languageCount);
            for (int i = 1; i <= languageCount; i++)
            {
                string ActualValue1 = GlobalDefinitions.driver.FindElement(By.XPath(beforeXpath + i + afterXpath)).Text;
                if (ActualValue1.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "Language")))
                {
                    if (ExpectedValue1 == ActualValue1)
                    {
                        languageFound = true;
                        Console.WriteLine("Test Passed : Langugae added successfully");
                        break;
                    }
                    else
                        Console.WriteLine("Test Failed : Language not added");
                }
                else
                {
                    languageFound = false;
                    
                }

            }
        }

        }
    }

