using Mars_Standard_Task.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Mars_Standard_Task.Global.GlobalDefinitions;

namespace Mars_Standard_Task.Pages
{
    class ManageListings
    {
        //Click on Manage Listings Link
        private IWebElement manageListingsLink => GlobalDefinitions.driver.FindElement(By.LinkText("Manage Listings"));

        //View the listing 
        private IWebElement view => GlobalDefinitions.driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Delete the listing
        private IWebElement delete => GlobalDefinitions.driver.FindElement(By.XPath("//table[1]/tbody[1]"));

        //Edit the listing
        private IWebElement edit => GlobalDefinitions.driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Click on Yes or No
        private IWebElement clickActionsButton => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='actions']"));

        //Manage Listings
        private IWebElement skillPresent => GlobalDefinitions.driver.FindElement(By.XPath("//div[@id = 'listing-management-section']/div[2]"));

        //Going to Next Page
        private IWebElement nextPage => GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'>')]"));

        //Searching the skill
        private IList<IWebElement> searchSkill => GlobalDefinitions.driver.FindElements(By.XPath("//table[@class='ui striped table']"));


        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(GlobalDefinitions.ReadJson(), "ManageListings");
            Thread.Sleep(1000);
            //**************************************

            //Click on Manage Listings
            Thread.Sleep(1000);
            manageListingsLink.Click();
            Thread.Sleep(1000);

            //*************************************

            //Click on view the listing
            GlobalDefinitions.wait(1000);
            view.Click();
            Thread.Sleep(500);

            //*************************************

            ////Click on edit the listing
            GlobalDefinitions.driver.Navigate().Back();
            Thread.Sleep(1000);
            //edit.Click();
            //Thread.Sleep(500);
            //ShareSkill obj = new ShareSkill();
            //obj.EditShareSkill();
            //Thread.Sleep(1000);
            //Verification

            //try
            //{
            //    bool recordEdited = true;
            //    int i;
            //    while(recordEdited)
            //    {
            //        for (i = 0; i< 5;i++)
            //        {
            //            string ActualText = searchSkill.ElementAt(i).Text;
            //            string ExpectedText = GlobalDefinitions.ExcelLib.ReadData(2, "EditedTitle");
            //            Console.WriteLine(ActualText);
            //            if (ActualText==ExpectedText)
            //            {
            //                Console.WriteLine("Test Passed : Skill has been edited successfully");
            //                Thread.Sleep(1000);
            //                recordEdited = false;
            //                break;
            //            }

            //        }
            //        nextPage.Click();
            //        i = 0;
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("Test Failed : Skill has not been edited successfully");
            //}
            //***************************************

            //Click on delete the listing
            Thread.Sleep(2000);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(delete).Build().Perform();
            Thread.Sleep(3000);
            try
            {
                bool skillToBeDeleted = true;
                int i;
                while (skillToBeDeleted)
                {
                    IList<IWebElement> listings = delete.FindElements(By.XPath("//tr/td[8]/i[3]"));
                    int listingCount = listings.Count;
                    Console.WriteLine("Number of Listings : " + listingCount);

                    for (i = 0; i < listingCount; i++)
                    {
                        int j = i + 1;
                        var Name = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]/td[3]")).Text;
                        // var Name = RecordDetails.ElementAt(i).Text;
                        Console.WriteLine("Name is : " + Name);
                        if (Name.Equals(ExcelLib.ReadData(2, "Title")))
                        {
                            listings.ElementAt(i).Click();
                            Console.WriteLine("Clicking on delete icon has been successfully performed");
                            IList<IWebElement> clickAction = clickActionsButton.FindElements(By.TagName("button"));
                            //Indicating the number of buttons present
                            int clickActionCount = clickAction.Count;
                            Console.WriteLine("Number of Actions for Deleting : " + clickActionCount);
                            for (int k = 1; k <= clickActionCount; k++)
                            {
                                if (clickAction[k].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction"))
                                {
                                    clickAction[k].Click();
                                    Console.WriteLine("Test Passed : Action has been performed successfully");
                                    Thread.Sleep(500);
                                    skillToBeDeleted = false;
                                    break;
                                }

                            }
                            skillToBeDeleted = false;
                            i--;
                        }

                    }
                    nextPage.Click();
                    i = 0;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("No more next pages to search");
            }


            //*****************************************

            //Verifying if the deleted service is present in the list
            Thread.Sleep(3000);
            manageListingsLink.Click();
            try
            {
                bool serviceFound = true;
                int i;
                while (serviceFound)
                {
                    IList<IWebElement> listings = delete.FindElements(By.XPath("//tr/td[8]/i[3]"));
                    int listingCount = listings.Count;
                    Console.WriteLine("Number of Listings : " + listingCount);
                    for (i = 0; i < listingCount; i++)
                    {
                        if (listingCount == 0)
                        {
                            string expectedValue = "You do not have any service listings!";
                            string afterDeleting = GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(),'You do not have any service listings!')]")).Text;
                            if (afterDeleting == expectedValue)
                            {
                                serviceFound = false;
                                Console.WriteLine("Test Passed: Service is deleted successfully");
                            }
                        }
                        else
                        {
                            IList<IWebElement> listingsAfterDeleting = skillPresent.FindElements(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr/td[3]"));
                            int listingsAfterDeletingCount = listingsAfterDeleting.Count;
                            Console.WriteLine("Number of Listings : " + listingsAfterDeletingCount);
                            for (int l = 0; l < listingsAfterDeletingCount; l++)
                            {
                                int j = l + 1;
                                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]/parent::div/div/table/tbody/tr[" + j + "]/td[3]")).Text;
                                Console.WriteLine("Name is : " + Name);
                                if (Name.Contains(ExcelLib.ReadData(2, "Title")))
                                {
                                    serviceFound = true;
                                    Console.WriteLine("Test Failed : Service is not deleted successfully");
                                    break;
                                }
                                else
                                {
                                    serviceFound = false;
                                    Console.WriteLine("Test Passed : Service has been deleted successfully");
                                    break;
                                }
                            }

                        }
                    }
                    serviceFound = true;
                    nextPage.Click();
                    i = 0;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Searched all the pages and skill is not present");
            }

        }
    }
}
    



