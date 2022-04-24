using CMB2022.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMB2022.Pages
{
    internal class Homepage
    {
        public void gotoTMpage(IWebDriver mydriver)
        { //go to TM page//
            IWebElement adminDropDown = mydriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminDropDown.Click();

            Wait.WaitForclicable(mydriver, "Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 2);

            // go to TM page
            IWebElement tmOption = mydriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
        }
    }
}
