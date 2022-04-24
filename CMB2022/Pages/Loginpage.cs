using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMB2022.Pages
{
    internal class Loginpage
    {

        public void loginSteps(IWebDriver mydriver)

        { 
            //launch turn up portal//

            mydriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            
            try
            {
                //Goto username box input username//

                IWebElement usernameTextBox = mydriver.FindElement(By.Id("UserName"));
                usernameTextBox.SendKeys("hari");

                // goto password input password//

                IWebElement passwordTextBox = mydriver.FindElement(By.Id("Password"));
                passwordTextBox.SendKeys("123123");

                //click on login button//

                IWebElement loginButton = mydriver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();

               
            }
            catch (Exception ex)
            {
                Assert.Fail("Turnup portal page does not launch", ex.Message);

            }
            //check if the user login successfully//

            IWebElement Hellohari = mydriver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));



        }
    }
}
