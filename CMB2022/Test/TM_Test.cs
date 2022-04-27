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
          
        

        [Test, Order(1)]
        public void CreateTM_Test()
        {
           
            //Home page object initialization and difinition
            Homepage homePageOB = new Homepage();
            homePageOB.gotoTMpage(mydriver);
            
            
            //TM page object initialization and definition
            TMpage tmPageOb = new TMpage();
            tmPageOb.CreateTM(mydriver);


        }

        [Test ,Order(2)]
        public void EditTM_Test()
        {
            //Home page object initialization and difinition
            Homepage homePageOB = new Homepage();
            homePageOB.gotoTMpage(mydriver);
            
            //Edit TM
            TMpage tmPageOb = new TMpage();
            tmPageOb.EditTM(mydriver, "dummy");

        }

        [Test, Order(3)]
        public void DeleteTM_Test()
        {
            //Home page object initialization and difinition
            Homepage homePageOB = new Homepage();
            homePageOB.gotoTMpage(mydriver);
            
            //Delete TM
            TMpage tmPageOb = new TMpage();
            tmPageOb.DeleteTM(mydriver);
        }

        

    }
}
