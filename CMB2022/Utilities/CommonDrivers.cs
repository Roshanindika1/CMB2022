using CMB2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMB2022.Utilities
{
    public class CommonDrivers
    {
        public static IWebDriver mydriver;

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
       
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            mydriver.Quit();
        }

    }
}
