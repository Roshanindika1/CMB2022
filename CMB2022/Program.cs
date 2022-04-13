using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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


        }

        //create time and material record//
        
        //go to TM page//

    }
}
