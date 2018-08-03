using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace WebUITests
{
    class LoginPage
    {
        IWebDriver driver;
        By homePageHeader = By.XPath("/html/body/div[1]/div/div/div/div/h2"); //header location

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By userName = By.Id("UserName");
        By password = By.Id("Password");
        By signin = By.CssSelector("#formLogin > div:nth-child(8) > div > button");
        public void setUserName(String strUserName)
        {
            driver.FindElement(userName).SendKeys(strUserName);
        }

        public void setPassword(String strPassword)
        {
            driver.FindElement(password).SendKeys(strPassword);
        }
        public void clickLogin()
        {
            driver.FindElement(signin).Click();
        }
        public void tryLoginToServer(String strUserName, String strPassword)
        {
            this.setUserName(strUserName);
            this.setPassword(strPassword);
            this.clickLogin();
        }
        public String getLoginPageHeader()
        {
            return driver.FindElement(homePageHeader).Text;
        }
    }
}
