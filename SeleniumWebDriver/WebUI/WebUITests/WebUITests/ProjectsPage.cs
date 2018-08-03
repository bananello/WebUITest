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
    class ProjectsPage
    {
        IWebDriver driver;
        public ProjectsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By addProject = By.ClassName("pull-right");
        public void AddProject()
        {
            driver.FindElement(addProject).Click();
        }
        public void TryToAddProject()
        {
            this.AddProject();
        }
    }
}
