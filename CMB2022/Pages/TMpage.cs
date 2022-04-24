using CMB2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMB2022.Pages
{
    internal class TMpage
    {
        public void CreateTM(IWebDriver mydriver)
        {  //create time and material record


            // go to create new button
            IWebElement createNew = mydriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNew.Click();

            // select material from Typecode dropdown
            IWebElement typeCode = mydriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCode.Click();
            Thread.Sleep(500);

            IWebElement materialoption = mydriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialoption.Click();

            // goto Code textbox

            IWebElement codeTextBox = mydriver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("CMB2022");

            // Identify the Description textbox and input 
            IWebElement description = mydriver.FindElement(By.Id("Description"));
            description.SendKeys("CMB2022");

            // Identify and input Price textbox
            IWebElement priceTag = mydriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement price = mydriver.FindElement(By.Id("Price"));
            price.SendKeys("100");

            // IDentify and save
            IWebElement saveButton = mydriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Thread.Sleep(1000);
            //Wait.WaitForclicable(mydriver, "Xpath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);
            Wait.WaitForvisible(mydriver, "Xpath" , "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]",2);

            
            // Goto lastpage button
            IWebElement gotoLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageButton.Click();

            //Check if the record create is present and has the expected value
            IWebElement actualCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //Option 1
            Assert.That(actualCode.Text == "CMB2022", "Actual Code and expected code not match");

            // Option 2
            //if (actualCode.Text == "CMB2022")
            // {
            //  Assert.Pass("Material record created successfully");
            // }

            // else
            // {
            //   Assert.Fail("Test Failed");
            // }



        }

        public void EditTM(IWebDriver mydriver)
        { }

        public void DeleteTM(IWebDriver mydriver)
        { }

    }
}
