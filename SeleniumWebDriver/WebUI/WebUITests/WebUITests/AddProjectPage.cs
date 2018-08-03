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
    class AddProjectPage
    {
        IWebDriver driver;
        public AddProjectPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //[FindsBy(How = How.CssSelector, Using = "#projectType")]
        //public IWebElement t { get; set; }
       
        By projectName = By.CssSelector("#Name");
        By projectDescription = By.CssSelector("#Description");
        By additionalFields = By.CssSelector("#details-switch");
        By projectType = By.CssSelector("#projectType"); 
        By repositoryType = By.CssSelector("#RepositoryGuid");
        By saveButton = By.XPath("//button[contains(text(), 'Save')]");
        public void setProjectName(String strProjectName)
        {
            driver.FindElement(projectName).SendKeys(Keys.Control + "a");
            driver.FindElement(projectName).SendKeys(strProjectName);
        }
        public void setProjectDescription(String strProjectDescription)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(projectDescription));
            driver.FindElement(projectDescription).SendKeys(strProjectDescription);
        }
        public void showAdditionalFields()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(additionalFields));
            driver.FindElement(additionalFields).Click();
        }
        public void selectProjectType()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(projectType));
            IWebElement element = driver.FindElement(projectType);
            SelectElement select = new SelectElement(element);
            driver.FindElement(projectType).Click();
            select.SelectByText("PcbProject");           
        }
        public void selectRepositoryType()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(repositoryType));
            IWebElement element = driver.FindElement(repositoryType);
            SelectElement select = new SelectElement(element);
            driver.FindElement(repositoryType).Click();
            select.SelectByText("Versioned Storage");
        }
        public void saveProject()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(saveButton));
            driver.FindElement(saveButton).Click();
        }
        public void TryToAddProject(String strProjectName, String strProjectDescription)
        {
            this.setProjectName(strProjectName);
            this.setProjectDescription(strProjectDescription);
            this.showAdditionalFields();
            this.selectProjectType();
            this.selectRepositoryType();
            this.saveProject();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(saveButton));
        }
    }
}
