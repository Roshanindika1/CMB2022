using CMB2022.Pages;
using CMB2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CMB2022
{
    [Binding]
    public class Feature1StepDefinitions :CommonDrivers
    {
        [Given(@"I logged in to turn up portal successfully")]
        public void GivenILoggedInToTurnUpPortalSuccessfully()
        {
            //open chrome webdriver//

            mydriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            mydriver.Manage().Window.Maximize();

            //login page object initialization and definition
            Loginpage loginPageOb = new Loginpage();
            loginPageOb.loginSteps(mydriver);


        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page object initialization and difinition
            Homepage homePageOB = new Homepage();
            homePageOB.gotoTMpage(mydriver);
                        
        }

        [When(@"I create a new time and materail record")]
        public void WhenICreateANewTimeAndMaterailRecord()
        {
            //TM page object initialization and definition
            TMpage tmPageOb = new TMpage();
            tmPageOb.CreateTM(mydriver);


        }

        [Then(@"The record should be create successfully")]
        public void ThenTheRecordShouldBeCreateSuccessfully()
        {
            TMpage tmPageOB = new TMpage();
            string newCode = tmPageOB.GetCode(mydriver);
            string newMCode = tmPageOB.GetMCode(mydriver);
            string newDescription = tmPageOB.GetActuaDescription(mydriver);
            string newPrice = tmPageOB.GetactualPrice(mydriver);

            Assert.That(newCode == "CMB2022", "Actual code and expected code do not match");
            Assert.That(newMCode == "M", "Actual Mcode and expected Mcode do not match");
            Assert.That(newDescription == "CMB2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$100.00", "Actual price and expected price do not match");

        }

        [When(@"I update '([^']*)' on exsisting time and materail record")]
        public void WhenIUpdateOnExsistingTimeAndMaterailRecord(string P0)
        {
            //TM page object initialization and definition
            TMpage tmPageOb = new TMpage();
            tmPageOb.EditTM(mydriver, P0);

        }

        [Then(@"The record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string P0)
        {
            TMpage tmPageOB = new TMpage();
            string newEditeddescription = tmPageOB.GetActuaDescription(mydriver);
            Assert.That(newEditeddescription == P0, "Actual description and expected description do not match");


        }

    }
}
