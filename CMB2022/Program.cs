using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CMB2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //open chrome webdriver//

            IWebDriver mydriver = new ChromeDriver();
            mydriver.Manage().Window.Maximize();

            //launch turn up portal//

            mydriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //Goto username box input username//

            IWebElement usernameTextBox = mydriver.FindElement(By.Id("UserName"));
            usernameTextBox.SendKeys("hari");

            // goto password input password//

            IWebElement passwordTextBox = mydriver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("123123");

            //click on login button//

            IWebElement loginButton = mydriver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //check if the user login successfully//

            IWebElement Hellohari = mydriver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (Hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in succesfully, Test passed.");
            }
            else
            {
                Console.WriteLine("logged in failed, Test unsuccesful");
            }




            //create time and material record

            //go to TM page//
            IWebElement adminDropDown = mydriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminDropDown.Click();

            // go to TM page
            IWebElement tmOption = mydriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

            // go to create new button
            IWebElement createNew = mydriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNew.Click();

            // select material from Typecode dropdown
            IWebElement typeCode = mydriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCode.Click();
            Thread.Sleep(1000);

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
            Thread.Sleep(1000);


            // Goto lastpage button
            IWebElement gotoLastPageButton = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageButton.Click();

            //Check if the record create is present and has the expected value
            IWebElement actualCode = mydriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if(actualCode.Text == "CMB2022" )
            {
                Console.WriteLine("Material record created successfully");
            }

            else
            {
                Console.WriteLine("Test Failed");
            }

            





        }
    }
}
