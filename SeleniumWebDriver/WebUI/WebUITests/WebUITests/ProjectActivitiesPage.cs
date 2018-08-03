using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace WebUITests
{
    class ProjectActivitiesPage
    {
        IWebDriver driver;
        public ProjectActivitiesPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By projectHeader = By.ClassName("project-name-inline");
        public String getNameProjectName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(driver => driver.FindElement(projectHeader));            
            return driver.FindElement(projectHeader).Text;
        }
    }
}
