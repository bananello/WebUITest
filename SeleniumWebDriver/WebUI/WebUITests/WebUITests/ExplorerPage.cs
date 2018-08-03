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
    class ExplorerPage
    {
        IWebDriver driver;

        public ExplorerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By navigateTreeFolders = By.ClassName("vaultFolders");
        By addFolder = By.CssSelector("body > div.context-menu > ul > li:nth-child(1)");
        By folderName = By.Id("folderName");
        By saveButton = By.CssSelector("#editFolderProperties > div > div > div.modal-footer > button");


        public void RmcClick()
        {
            Actions context_menu = new Actions(driver);
            driver.FindElement(navigateTreeFolders);
            Thread.Sleep(1000);
            MainPage mPage = new MainPage(driver);
            context_menu.ContextClick(mPage.tree).Perform();
        }

        public void AddFolderToVe()
        {
            driver.FindElement(addFolder).Click();
        }

        public void SetFolderNeme(String strFolderName)
        {
            driver.FindElement(folderName).SendKeys(strFolderName);
        }

        public void SaveFolder()
        {
            driver.FindElement(saveButton).Click();
        }

        public void TryToCreateFolder(String strFolderName)
        {
            this.RmcClick();
            this.AddFolderToVe();
            this.SetFolderNeme(strFolderName);
            this.SaveFolder();
        }
    }
}
