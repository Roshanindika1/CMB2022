using CMB2022.Pages;
using CMB2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CMB2022.Tests
{

    [TestFixture]
    internal class TM_Test: CommonDrivers
    {
        
    
        [OneTimeSetUp]
        public void LoginFunction()
        {
            //open chrome webdriver//

            mydriver = new ChromeDriver();
            mydriver.Manage().Window.Maximize();

            //login page object initialization and definition
            Loginpage loginPageOb = new Loginpage();
            loginPageOb.loginSteps(mydriver);

            //Home page object initialization and definition
            Homepage homePageOb = new Homepage();
            homePageOb.gotoTMpage(mydriver);


        }

        [Test]
        public void CreateTM_Test()
        {
            //TM page object initialization and definition
            TMpage tmPageOb = new TMpage();
            tmPageOb.CreateTM(mydriver);


        }

        [Test]
        public void EditTM_Test()
        {
            //Edit TM
            TMpage tmPageOb = new TMpage();
            tmPageOb.EditTM(mydriver);

        }

        [Test]
        public void DeleteTM_Test()
        {
            //Delete TM
            TMpage tmPageOb = new TMpage();
            tmPageOb.DeleteTM(mydriver);
        }

        [TearDown]
        public void CloseTestRun()
        {

        }

    }
}
