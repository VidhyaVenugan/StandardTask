using Mars_Standard_Task.Global;
using Mars_Standard_Task.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Mars_Standard_Task
{
    [TestClass]
    public class Program
    {
        
        [TestMethod]
        public void SignUp()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                SignUp newSignUp = new SignUp();
                newSignUp.Register();

            }
        }

        [TestMethod]
        public void SignIn()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();

            }
        }

        [TestMethod]
        public void Profile()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();
                Profile newProfile = new Profile();
                newProfile.ProfileSteps();

            }
        }

        [TestMethod]
        public void ShareSkill()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();
                ShareSkills newShareSkill = new ShareSkills();
                newShareSkill.EnterShareSkill();
                newShareSkill.EditShareSkill();
            }
        }

        [TestMethod]
        public void ManageListing()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();
                ManageListings newManageListing = new ManageListings();
                newManageListing.Listings();
            }
        }
    }
}
