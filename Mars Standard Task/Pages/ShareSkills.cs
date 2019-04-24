using AutoItX3Lib;
using Mars_Standard_Task.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mars_Standard_Task.Pages
{
    class ShareSkills
    {
        //Click on ShareSkill Button
        private IWebElement ShareSkillButton => GlobalDefinitions.driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title in textbox
        private IWebElement Title => GlobalDefinitions.driver.FindElement(By.Name("title"));

        //Enter the Description in textbox
        private IWebElement Description => GlobalDefinitions.driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        private IWebElement CategoryDropDown => GlobalDefinitions.driver.FindElement(By.Name("categoryId"));

        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => GlobalDefinitions.driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        private IWebElement Tags => GlobalDefinitions.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //Select the Service type
        private IWebElement ServiceTypeOptions => GlobalDefinitions.driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));

        //Select the Location Type
        private IWebElement LocationTypeOption => GlobalDefinitions.driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => GlobalDefinitions.driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => GlobalDefinitions.driver.FindElement(By.Name("endDate"));

        //Storing the table of available days
        private IWebElement Days => GlobalDefinitions.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));

        //Storing the starttime
        private IWebElement StartTime => GlobalDefinitions.driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on StartTime dropdown
        private IWebElement StartTimeDropDown => GlobalDefinitions.driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on EndTime dropdown
        private IWebElement EndTimeDropDown => GlobalDefinitions.driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Click on Skill Trade option
        private IWebElement SkillTradeOption => GlobalDefinitions.driver.FindElement(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Enter Skill Exchange
        private IWebElement SkillExchange => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Enter the amount for Credit
        private IWebElement CreditAmount => GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Upload work samples
        private IWebElement workSamples => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        //Click on Active/Hidden option
        private IWebElement ActiveOption => GlobalDefinitions.driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Save button
        private IWebElement Save => GlobalDefinitions.driver.FindElement(By.XPath("//input[@value='Save']"));

        //Manage Listings
        private IWebElement skillPresent => GlobalDefinitions.driver.FindElement(By.XPath("//div[@id = 'listing-management-section']/div[2]"));

        internal void EnterShareSkill()
        {
            //Click on Share Skill button
            Thread.Sleep(1000);
            ShareSkillButton.Click();
            Thread.Sleep(1000);
        }
        internal void EditShareSkill()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(GlobalDefinitions.ReadJson(), "ShareSkill");
            Thread.Sleep(1000);

            //**********************************
            //Enter the Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Console.WriteLine("Title has been successfully entered");

            //********************************************
            //Enter the Description
            Thread.Sleep(1000);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Console.WriteLine("Description has been successfully entered");

            //******************************************
            //Select the Category option
            Thread.Sleep(1500);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(CategoryDropDown).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> ServiceCategory = CategoryDropDown.FindElements(By.TagName("option"));
            int count = ServiceCategory.Count;
            Console.WriteLine("Number of Category : " + count);
            for (int i = 0; i < count; i++)
            {
                if (ServiceCategory[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    ServiceCategory[i].Click();
                    Console.WriteLine("Category has been successfully selected");
                    break;
                }
            }

            //****************************************
            //Select the subcategory
            Thread.Sleep(2000);
            action.MoveToElement(SubCategoryDropDown).Build().Perform();
            Thread.Sleep(1500);
            IList<IWebElement> SubCategory = SubCategoryDropDown.FindElements(By.TagName("option"));
            int subcategorycount = SubCategory.Count;
            Console.WriteLine("Number of Sub Category : " + subcategorycount);
            for (int i = 0; i < subcategorycount; i++)
            {
                if (SubCategory[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"))
                {
                    SubCategory[i].Click();
                    Console.WriteLine("Sub Category has been successfully selected");
                    break;
                }
            }

            //**************************************
            //Enter Tag name
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Console.WriteLine("Tag name has been succesfully enetered");

            //************************************
            //Service Type Option
            Thread.Sleep(2000);
            action.MoveToElement(ServiceTypeOptions).Build().Perform();
            Thread.Sleep(3000);
            // Storing all the elements under category of 'Service Type' in the list of WebLements
            IList<IWebElement> ServiceType = ServiceTypeOptions.FindElements(By.XPath("//div/input[@name='serviceType']"));
            //Indicating the number of buttons present
            int servicetypecount = ServiceType.Count;
            Console.WriteLine("Number of Service type : " + servicetypecount);
            for (int i = 0; i < servicetypecount; i++)
            {
                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = ServiceType.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[" + j + "]/div/label")).Text;
                //Checking if Name equals the "name" attribute - "ServiceType"
                if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")) && Value.Equals("" + i))
                {
                    ServiceType.ElementAt(i).Click();
                    Console.WriteLine("Service Type has been succesfully selected");
                    break;
                }
                
            }

            //*****************************************
            //Location Type Option
            Thread.Sleep(2000);
            action.MoveToElement(LocationTypeOption).Build().Perform();
            Thread.Sleep(3000);
            // Storing all the elements under category of 'Location Type' in the list of WebLements
            IList<IWebElement> LocationType = LocationTypeOption.FindElements(By.XPath("//div/input[@name='locationType']"));
            //Indicating the number of buttons present
            int locationtypecount = LocationType.Count;
            Console.WriteLine("Number of Location type : " + locationtypecount);
            for (int i = 0; i < locationtypecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = LocationType.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "LocationType"
                if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")) && Value.Equals("" + i))
                {
                    LocationType.ElementAt(i).Click();
                    Console.WriteLine("Location Type has been succesfully selected");
                    break;
                }
                
            }

            //******************************************
            //Entering start date
            Thread.Sleep(1000);
            StartDateDropDown.SendKeys(Keys.Delete);
            Thread.Sleep(2000);
            Console.WriteLine("Start date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            //1st Method using DateTime Class
            //====================================
            var dateTime = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
            Console.WriteLine("Date is : " + dateTime);
            /*DateTime parsedDate = DateTime.Parse(dateTime);
            Console.WriteLine("Parsed Date is : " + parsedDate);
            //var dateTimeNow = DateTime.Now; Return 00/00/0000 00:00:00
            //Console.WriteLine("Date Time Now : " + dateTimeNow);
            //var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
            //Console.WriteLine("Date only string is : " + dateOnlyString);
            var dateOnlyString = parsedDate.ToShortDateString(); //To convert string to DateTime format Return 00/00/0000 00:00:00
            Console.WriteLine("Date only string is : " + dateOnlyString);
            StartDateDropDown.SendKeys(dateOnlyString);*/

            //2nd Method using string split
            //==============================
            string[] splitDate = dateTime.Split(' ');
            int countSplitDate = splitDate.Count();
            Console.WriteLine("The count of date string is : " + countSplitDate);
            Console.WriteLine($"String 1 is : {splitDate[0]} ");
            Console.WriteLine($"String 2 is : {splitDate[1]} ");
            Console.WriteLine($"String 3 is : {splitDate[2]} ");
            StartDateDropDown.SendKeys(splitDate[0]);

            Thread.Sleep(2000);
            StartDateDropDown.SendKeys(Keys.Tab);
            Console.WriteLine("Start Date has succesfully been edited");

            //******************************************
            //Entering End date
            Thread.Sleep(1000);
            //Console.Out.Write("End Date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            Console.WriteLine("End Date read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            var endDate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            DateTime parsedEndDate = DateTime.Parse(endDate);
            var endDateonly = parsedEndDate.ToShortDateString();
            EndDateDropDown.SendKeys(endDateonly);
            Thread.Sleep(500);
            EndDateDropDown.SendKeys(Keys.Tab);
            Console.WriteLine("End Date has succesfully been edited");

            //***************************************
            //Selecting the day
            Thread.Sleep(1000);
            action.MoveToElement(Days).Build().Perform();
            Thread.Sleep(2000);
            IList<IWebElement> allDays = Days.FindElements(By.XPath("//div/div/div/input[@name = 'Available']"));
            int allDaysCount = allDays.Count;
            Console.WriteLine("Number of Days : " + allDaysCount);
            for (int i = 0; i < allDaysCount; i++)
            {

                int j = i + 2;
                var day = GlobalDefinitions.driver.FindElement(By.XPath("//div[" + j + "]/div[1]/div[1]/label")).Text;

                if (day.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")))
                {
                    allDays.ElementAt(i).Click();
                    Console.WriteLine("Day has been succesfully selected");
                    break;
                }

            }

            //*****************************************
            //Entering the starttime 
            Thread.Sleep(1000);
            Console.WriteLine("Start time read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            var startTime = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
            DateTime parsedStartTime = DateTime.Parse(startTime);
            var startTimeString = parsedStartTime.ToString("hh:mmtt");
            //var startTimeString = parsedStartTime.ToShortTimeString();
            Console.WriteLine("Start Time String is : " + startTimeString);
            Thread.Sleep(500);
            StartTimeDropDown.SendKeys(startTimeString);
            StartTimeDropDown.SendKeys(Keys.Tab);
            //*****************************************
            //Entering the endtime
            Thread.Sleep(1000);
            GlobalDefinitions.wait(5);
            Console.WriteLine("End time read from excel is : " + GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            var endTime = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            DateTime parsedEndTime = DateTime.Parse(endTime);
            var endTimeString = parsedEndTime.ToString("hh:mmtt");
            Console.WriteLine("End Time String is : " + endTimeString);
            Thread.Sleep(1000);
            EndTimeDropDown.SendKeys(endTimeString);

            //******************************************
            //Skill Trade Option
            Thread.Sleep(2000);
            action.MoveToElement(SkillTradeOption).Build().Perform();
            Thread.Sleep(3000);

            // Storing all the elements under category of 'Skill Trade' in the list of WebLements
            IList<IWebElement> SkillTrade = SkillTradeOption.FindElements(By.XPath("//div/input[@name='skillTrades']"));

            //Indicating the number of buttons present
            int skilltradecount = SkillTrade.Count;
            Console.WriteLine("Number of Skill Trade : " + skilltradecount);

            for (int i = 0; i < skilltradecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = SkillTrade.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")))
                {
                    SkillTrade.ElementAt(i).Click();
                    Console.WriteLine("Skill Trade - Skill Exchange has been succesfully selected");
                    //****************************************
                    //Enter Skill-Exchange Tag name
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Console.WriteLine("Skill-Exchange Tag name has been succesfully enetered");

                    //**************************************
                    break;
                }
                else if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")))
                {
                    SkillTrade.ElementAt(i).Click();
                    Console.WriteLine("Skill Trade - Credit has been succesfully selected");
                    //****************************************
                    //Enter Credit Amount
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
                    Console.WriteLine("Credit amount has been succesfully enetered");

                    //**************************************
                    break;
                }
                else
                {
                    Console.WriteLine("Test Failed : Skill Trade mentioned is not valid");
                }
            }

            //Work Samples

            //Thread.Sleep(1000);
            //workSamples.Click();
            //AutoItX3 fileUpload = new AutoItX3();
            //fileUpload.WinActivate("Open");
            //fileUpload.Send(@"C:\Users\Vidhya\Desktop\" + GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample"));
            //Thread.Sleep(4000);
            //fileUpload.Send("{ENTER}");
            //Thread.Sleep(5000);
            //Console.WriteLine("File has been uploaded successfully");


            //**********************************************

            //Active Option
            Thread.Sleep(2000);
            action.MoveToElement(ActiveOption).Build().Perform();
            Thread.Sleep(3000);

            // Storing all the elements under category of 'Active' in the list of WebLements
            IList<IWebElement> Active = ActiveOption.FindElements(By.XPath("//div/input[@name='isActive']"));

            //Indicating the number of buttons present
            int activecount = Active.Count;
            Console.WriteLine("Number of Active : " + activecount);

            for (int i = 0; i < activecount; i++)
            {

                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = Active.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "Active Option"
                if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Active")) && Value.Equals("" + i))
                {
                    Active.ElementAt(i).Click();
                    Console.WriteLine("Services option has been succesfully selected");
                    break;
                }
               
            }
            //************************************

            //Save the page

            Thread.Sleep(1000);
            Save.Click();

            //****************************************

            //Verifying whether the service added is present in the listings

            Thread.Sleep(2000);
            GlobalDefinitions.wait(5000);
            bool serviceFound = false;
            IList<IWebElement> listings = skillPresent.FindElements(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr/td[3]"));
            int listingCount = listings.Count;
            Console.WriteLine("Number of Listings : " + listingCount);
            for (int i = 0; i < listingCount; i++)
            {
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr[" + j + "]/td[3]")).Text;
                Console.WriteLine("Name is : " + Name);
                if (Name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                {
                    serviceFound = true;
                    Console.WriteLine("Service has been added successfully");
                    break;
                }
                else
                {
                    serviceFound = false;
                    Console.WriteLine("Test Failed : Service has not been added successfully");
                    break;
                }
            }

        }

    }
}
