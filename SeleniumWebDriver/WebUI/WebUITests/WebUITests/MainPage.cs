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
    class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "vaultFolders")]
        public IWebElement tree { get; set; }

        By vaultExplorer = By.CssSelector("[href='/vaultexplorer']");
        By projectsTab = By.CssSelector("[href='/projectsmanagement']");


        public void FindVaultExplorer()
        {
            driver.FindElement(vaultExplorer).Click();
        }
        public void FindProjects()
        {
            driver.FindElement(projectsTab).Click();
        }

        public void TryToOpenExplorerTab()
        {
            this.FindVaultExplorer();
        }
        public void TryToOpenProjectsTab()
        {
            this.FindProjects();
        }
    }
}
