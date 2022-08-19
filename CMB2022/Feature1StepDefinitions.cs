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

        //Page object initialization
        Loginpage loginPageOb = new Loginpage();
        Homepage homePageOB = new Homepage();
        TMpage tmPageOb = new TMpage();



        [Given(@"I logged in to turn up portal successfully")]
        public void GivenILoggedInToTurnUpPortalSuccessfully()
        {
            //open chrome webdriver//

            mydriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            mydriver.Manage().Window.Maximize();

            //login page object initialization and definition
            loginPageOb.loginSteps(mydriver);


        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page object initialization and difinition
            homePageOB.gotoTMpage(mydriver);
                        
        }

        [When(@"I create a new time and materail record")]
        public void WhenICreateANewTimeAndMaterailRecord()
        {
            //TM page object initialization and definition
            tmPageOb.CreateTM(mydriver);


        }

        [Then(@"The record should be create successfully")]
        public void ThenTheRecordShouldBeCreateSuccessfully()
        {
            string newCode = tmPageOb.GetCode(mydriver);
            string newMCode = tmPageOb.GetMCode(mydriver);
            string newDescription = tmPageOb.GetActuaDescription(mydriver);
            string newPrice = tmPageOb.GetactualPrice(mydriver);

            Assert.That(newCode == "CMB2022", "Actual code and expected code do not match");
            Assert.That(newMCode == "M", "Actual Mcode and expected Mcode do not match");
            Assert.That(newDescription == "CMB2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$100.00", "Actual price and expected price do not match");

        }

        [When(@"I update '([^']*)','([^']*)' and '([^']*)' on exsisting time and materail record")]
        public void WhenIUpdateAndOnExsistingTimeAndMaterailRecord(string P0, string P1, string P2)
        {
            tmPageOb.EditTM(mydriver, P0,P1,P2);

        }

        [Then(@"The record should have the updated '([^']*)','([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string P0, string P1, string P2 )
        {
            string editeddescription = tmPageOb.getediteddescription(mydriver);
            string editedcode = tmPageOb.geteditedcode(mydriver);
            string editedprice = tmPageOb.geteditedprice(mydriver);

            Assert.That(editeddescription == P0, "Edited description and expected description does not match");
            Assert.That(editedcode == P1, "Edited code and expected code does not match");
            Assert.That(editedprice == P2, "Edited price and expected price does not match");

        }


    }
}
