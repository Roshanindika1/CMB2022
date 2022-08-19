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


            //Option 1
           // Assert.That(actualCode.Text == "CMB2022", "Actual Code and expected code not match");
           // Assert.That(actualMCode.Text == "M", "Actual Material code and expected code not match");
           // Assert.That(actualDescription.Text == "CMB2022", "Actual Description and expected description not match");
           // Assert.That(actualPrice.Text == "$100.00", "Actual Price and expected Price not match");

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
        public string GetCode(IWebDriver mydriver)
        {
            IWebElement actualCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;
        }

        public string GetMCode(IWebDriver mydriver)
        {
            IWebElement actualMCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return actualMCode.Text;
        }

        public string GetActuaDescription(IWebDriver mydriver)
        {
            IWebElement actualDescription = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }
        public string GetactualPrice(IWebDriver mydriver)
        {
            IWebElement actualPrice = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }


        public void EditTM(IWebDriver mydriver, string mydescription, string code, string nprice)
        {
            //wait until entire TM page is displayed
            Wait.WaitForvisible(mydriver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");

            //Click on go to last page button
            IWebElement goToLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "CMB2022")
            {
                //Click on edit button
                IWebElement editButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

            }
            else
            {
                Assert.Fail("Record to be edited hasn't been find.");
            }

            //Edit code
            IWebElement codeTextBox = mydriver.FindElement(By.Id("Code"));
            codeTextBox.Clear();
            codeTextBox.SendKeys(code);

            // Identify the Description textbox and input 
            IWebElement description = mydriver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys(mydescription);

            // Identify and input Price textbox
            IWebElement priceTag = mydriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement price = mydriver.FindElement(By.Id("Price"));
            price.Clear();
            priceTag.Click();
            price.SendKeys(nprice);

            // IDentify and save
            IWebElement saveButton = mydriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Wait.WaitForvisible(mydriver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            // Goto lastpage button
            IWebElement gotoLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageButton.Click();

            //Check if the record create is present and has the expected value


        }


        public string getediteddescription(IWebDriver mydriver)
        {
            IWebElement actualDescription = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }

        public string geteditedcode(IWebDriver mydriver)
        {
            IWebElement actualCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;

        }

        
        public string geteditedprice (IWebDriver mydriver)
        {
            IWebElement actualPrice = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }

        //Option 1
        

        public void DeleteTM(IWebDriver mydriver)
        {
            //wait until entire TM page is displayed
            Wait.WaitForvisible(mydriver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");

            //Click on go to last page button
            IWebElement goToLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findEditedRecord = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "Edited CMB2022")
            {
                //Click on edit button
                IWebElement deleteButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[last()]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1000);

                mydriver.SwitchTo().Alert().Accept();

            }
            else
            {
                Assert.Fail("Record to be deleted hasn't been find. Record not created succefully");
            }


            //Assert that Time record has been deleted
            mydriver.Navigate().Refresh();
            Thread.Sleep(1000);


            
            // Goto lastpage button
            IWebElement gotoLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageButton.Click();

            //Check if the record create is present and has the expected value
            IWebElement actualCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualMCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement actualDescription = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement actualPrice = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));


            //Option 1
            Assert.That(actualCode.Text != "Edited CMB2022", "Actual Code record has been deleted");
            Assert.That(actualMCode.Text != "M", "Actual Material code record has been deleted");
            Assert.That(actualDescription.Text != "Edited CMB2022", "Actual Description record has been deleted");
            Assert.That(actualPrice.Text != "$200", "Actual Price record has been deleted");


        }

    }
}
