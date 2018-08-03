using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebUITests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        LoginPage objLogin;
        LoginPage objHomePage;
        MainPage objMainPage;
        ExplorerPage objExplorerPage;
        ProjectsPage objprojectsPage;
        AddProjectPage objAddProjectPage;
        ProjectActivitiesPage objCurrentProjectPage;
        Random random;
        string projectName;

        [TestInitialize]
        public void setup()
        {
            driver = new ChromeDriver();                       
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://localhost:9780");
            random = new Random();
        }

        /*public void RightMouseClick (IWebElement target)
        {
            var builder = new Actions(target.Click.RightMou);
            builder.ContextClick(target);
            builder.Perform();
        }*/


        [TestMethod] //Login to server by admin user
        public void LoginToServer()
        {
            objLogin = new LoginPage(driver);
            objLogin.tryLoginToServer("admin", "admin");
            objHomePage = new LoginPage(driver);
            Assert.AreEqual(objHomePage.getLoginPageHeader(), "Altium NEXUS Server");
        }


        [TestMethod] //Create top level folder in VE
        public void CreateFolderVE()
        {
            objLogin = new LoginPage(driver);
            objLogin.tryLoginToServer("admin", "admin");
            objMainPage = new MainPage(driver);
            objMainPage.TryToOpenExplorerTab();
            objExplorerPage = new ExplorerPage(driver);
            objExplorerPage.TryToCreateFolder("TopLevelFolder");                  
        }

        [TestMethod] //Create project
        public void CreateProject()
        {
            projectName = "Project_" + random.Next(1, 1000);
            objLogin = new LoginPage(driver);
            objLogin.tryLoginToServer("admin", "admin");
            objMainPage = new MainPage(driver);
            objMainPage.TryToOpenProjectsTab();
            objprojectsPage = new ProjectsPage(driver);
            objprojectsPage.TryToAddProject();
            objAddProjectPage = new AddProjectPage(driver);
            objAddProjectPage.TryToAddProject(projectName, "Test Description");
            Thread.Sleep(5000);
            objCurrentProjectPage = new ProjectActivitiesPage(driver);
            Assert.AreEqual(objCurrentProjectPage.getNameProjectName(), projectName);            
        }


            /*IWebDriver driver;
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:9780");

            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("admin");
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("admin");
            IWebElement signin = driver.FindElement(By.CssSelector("#formLogin > div:nth-child(8) > div > button"));
            signin.Click();
            //Thread.Sleep(2000);
            //IWebElement header = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/h2"));

            //Assert.AreEqual("Altium NEXUS Server", header.Text);
            //driver.Close();

            IWebElement vaultexplorer = driver.FindElement(By.CssSelector("[href='/vaultexplorer']"));
            vaultexplorer.Click();

            Actions context_menu = new Actions(driver);
            IWebElement rmc = driver.FindElement(By.ClassName("vaultFolders"));
            Thread.Sleep(1000);
            context_menu.ContextClick(rmc).Perform();

            IWebElement add_folder = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(1)"));
            // Thread.Sleep(2000);
            add_folder.Click();

            IWebElement folder_name = driver.FindElement(By.Id("folderName"));
            folder_name.SendKeys("TopLevelFolder");

            IWebElement save_button = driver.FindElement(By.CssSelector("#editFolderProperties > div > div > div.modal-footer > button"));
            save_button.Click();*/




            /////----------------------------------------------------------------/////
            ///<summary>Cteate subfolder for all content types
            ///</summary>

            /*Actions context_menu_from_folder = new Actions(driver);
            IWebElement add_subfolder = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder.ContextClick(add_subfolder).Perform();
            IWebElement create_subfolder = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder.Click();
            IWebElement subfolder_name = driver.FindElement(By.Id("folderName"));
            subfolder_name.SendKeys("ComponentsFolder");
            IWebElement folder_type = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type.Click();
            SelectElement select = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options = select.Options;
            select.SelectByText("Components");
            save_button.Click();

            Actions context_menu_from_folder1 = new Actions(driver);
            IWebElement add_subfolder1 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder1.ContextClick(add_subfolder1).Perform();
            IWebElement create_subfolder1 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder1.Click();
            IWebElement subfolder_name1 = driver.FindElement(By.Id("folderName"));
            subfolder_name1.SendKeys("FootprintsFolder");
            IWebElement folder_type1 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type1.Click();
            SelectElement select1 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options1 = select.Options;
            select.SelectByText("Footprints");
            save_button.Click();

            Actions context_menu_from_folder2 = new Actions(driver);
            IWebElement add_subfolder2 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder2.ContextClick(add_subfolder2).Perform();
            IWebElement create_subfolder2 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder2.Click();
            IWebElement subfolder_name2 = driver.FindElement(By.Id("folderName"));
            subfolder_name2.SendKeys("SymbolsFolder");
            IWebElement folder_type2 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type2.Click();
            SelectElement select2 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options2 = select.Options;
            select.SelectByText("Symbols");
            save_button.Click();

            Actions context_menu_from_folder3 = new Actions(driver);
            IWebElement add_subfolder3 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder3.ContextClick(add_subfolder3).Perform();
            IWebElement create_subfolder3 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder3.Click();
            IWebElement subfolder_name3 = driver.FindElement(By.Id("folderName"));
            subfolder_name3.SendKeys("BinaryFilesFolder");
            IWebElement folder_type3 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type3.Click();
            SelectElement select3 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options3 = select.Options;
            select.SelectByText("Binary Files");
            save_button.Click();

            Actions context_menu_from_folder4 = new Actions(driver);
            IWebElement add_subfolder4 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder4.ContextClick(add_subfolder4).Perform();
            IWebElement create_subfolder4 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder4.Click();
            IWebElement subfolder_name4 = driver.FindElement(By.Id("folderName"));
            subfolder_name4.SendKeys("3DModelsFolder");
            IWebElement folder_type4 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type4.Click();
            SelectElement select4 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options4 = select.Options;
            select.SelectByText("3D Models");
            save_button.Click();

            Actions context_menu_from_folder5 = new Actions(driver);
            IWebElement add_subfolder5 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder5.ContextClick(add_subfolder5).Perform();
            IWebElement create_subfolder5 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder5.Click();
            IWebElement subfolder_name5 = driver.FindElement(By.Id("folderName"));
            subfolder_name5.SendKeys("SimulationModelsFolder");
            IWebElement folder_type5 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type5.Click();
            SelectElement select5 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options5 = select.Options;
            select.SelectByText("Simulation Models");
            save_button.Click();

            Actions context_menu_from_folder6 = new Actions(driver);
            IWebElement add_subfolder6 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder6.ContextClick(add_subfolder6).Perform();
            IWebElement create_subfolder6 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder6.Click();
            IWebElement subfolder_name6 = driver.FindElement(By.Id("folderName"));
            subfolder_name6.SendKeys("ManagedSchematicSheetsFolder");
            IWebElement folder_type6 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type6.Click();
            SelectElement select6 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options6 = select.Options;
            select.SelectByText("Managed Schematic Sheets");
            save_button.Click();

            Actions context_menu_from_folder7 = new Actions(driver);
            IWebElement add_subfolder7 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder7.ContextClick(add_subfolder7).Perform();
            IWebElement create_subfolder7 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder7.Click();
            IWebElement subfolder_name7 = driver.FindElement(By.Id("folderName"));
            subfolder_name7.SendKeys("LayerstacksFolder");
            IWebElement folder_type7 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type7.Click();
            SelectElement select7 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options7 = select.Options;
            select.SelectByText("Layerstacks");
            save_button.Click();

            Actions context_menu_from_folder8 = new Actions(driver);
            IWebElement add_subfolder8 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder8.ContextClick(add_subfolder8).Perform();
            IWebElement create_subfolder8 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder8.Click();
            IWebElement subfolder_name8 = driver.FindElement(By.Id("folderName"));
            subfolder_name8.SendKeys("SchematicTemplatesFolder");
            IWebElement folder_type8 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type8.Click();
            SelectElement select8 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options8 = select.Options;
            select.SelectByText("Schematic Templates");
            save_button.Click();

            Actions context_menu_from_folder9 = new Actions(driver);
            IWebElement add_subfolder9 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder9.ContextClick(add_subfolder9).Perform();
            IWebElement create_subfolder9 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder9.Click();
            IWebElement subfolder_name9 = driver.FindElement(By.Id("folderName"));
            subfolder_name9.SendKeys("ProjectTemplatesFolder");
            IWebElement folder_type9 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type9.Click();
            SelectElement select9 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options9 = select.Options;
            select.SelectByText("Project Templates");
            save_button.Click();

            Actions context_menu_from_folder10 = new Actions(driver);
            IWebElement add_subfolder10 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder10.ContextClick(add_subfolder10).Perform();
            IWebElement create_subfolder10 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder10.Click();
            IWebElement subfolder_name10 = driver.FindElement(By.Id("folderName"));
            subfolder_name10.SendKeys("BOMTemplatesFolder");
            IWebElement folder_type10 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type10.Click();
            SelectElement select10 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options10 = select.Options;
            select.SelectByText("BOM Templates");
            save_button.Click();

            Actions context_menu_from_folder11 = new Actions(driver);
            IWebElement add_subfolder11 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder11.ContextClick(add_subfolder11).Perform();
            IWebElement create_subfolder11 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder11.Click();
            IWebElement subfolder_name11 = driver.FindElement(By.Id("folderName"));
            subfolder_name11.SendKeys("OutputJobsFolder");
            IWebElement folder_type11 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type11.Click();
            SelectElement select11 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options11 = select.Options;
            select.SelectByText("Output Jobs");
            save_button.Click();

            Actions context_menu_from_folder12 = new Actions(driver);
            IWebElement add_subfolder12 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder12.ContextClick(add_subfolder12).Perform();
            IWebElement create_subfolder12 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder12.Click();
            IWebElement subfolder_name12 = driver.FindElement(By.Id("folderName"));
            subfolder_name12.SendKeys("ScriptsFolder");
            IWebElement folder_type12 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type12.Click();
            SelectElement select12 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options12 = select.Options;
            select.SelectByText("Scripts");
            save_button.Click();

            Actions context_menu_from_folder13 = new Actions(driver);
            IWebElement add_subfolder13 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder13.ContextClick(add_subfolder13).Perform();
            IWebElement create_subfolder13 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder13.Click();
            IWebElement subfolder_name13 = driver.FindElement(By.Id("folderName"));
            subfolder_name13.SendKeys("AltiumDesignerPreferencesFolder");
            IWebElement folder_type13 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type13.Click();
            SelectElement select13 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options13 = select.Options;
            select.SelectByText("Altium Designer Preferences");
            save_button.Click();

            Actions context_menu_from_folder14 = new Actions(driver);
            IWebElement add_subfolder14 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder14.ContextClick(add_subfolder14).Perform();
            IWebElement create_subfolder14 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder14.Click();
            IWebElement subfolder_name14 = driver.FindElement(By.Id("folderName"));
            subfolder_name14.SendKeys("ProjectCatalogFolder");
            IWebElement folder_type14 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type14.Click();
            SelectElement select14 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options14 = select.Options;
            select.SelectByText("Project Catalog");
            save_button.Click();

            Actions context_menu_from_folder15 = new Actions(driver);
            IWebElement add_subfolder15 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder15.ContextClick(add_subfolder15).Perform();
            IWebElement create_subfolder15 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder15.Click();
            IWebElement subfolder_name15 = driver.FindElement(By.Id("folderName"));
            subfolder_name15.SendKeys("DraftsmanTemplatesFolder");
            IWebElement folder_type15 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type15.Click();
            SelectElement select15 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options15 = select.Options;
            select.SelectByText("Draftsman Templates");
            save_button.Click();

            Actions context_menu_from_folder16 = new Actions(driver);
            IWebElement add_subfolder16 = driver.FindElement(By.CssSelector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultExplorer.splitter.ui-widget.ui-widget-content > div.vaultFolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            Thread.Sleep(1000);
            context_menu_from_folder16.ContextClick(add_subfolder16).Perform();
            IWebElement create_subfolder16 = driver.FindElement(By.CssSelector("body > div.context-menu > ul > li:nth-child(2)"));
            create_subfolder16.Click();
            IWebElement subfolder_name16 = driver.FindElement(By.Id("folderName"));
            subfolder_name16.SendKeys("ComponentTemplatesFolder");
            IWebElement folder_type16 = driver.FindElement(By.CssSelector("#EditRoleForm > div.form-group.row > div.col-sm-6.pull-right > select"));
            folder_type16.Click();
            SelectElement select16 = new SelectElement(folder_type);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options16 = select.Options;
            select.SelectByText("Component Templates");
            save_button.Click();*/

            //for (int i = 0; i < 17; i++)
            //{
            //    actions context_menu_from_folder100 = new actions(driver);
            //    iwebelement add_subfolder100 = driver.findelement(by.cssselector("body > div.outer-wrapper > div > div > div.inner-wrap > div > div.vaultexplorer.splitter.ui-widget.ui-widget-content > div.vaultfolders.splitter-pane > altium-tree-view > div > tree-view > div > ul > li:nth-child(6) > span.hand"));
            //    thread.sleep(1000);
            //    context_menu_from_folder100.contextclick(add_subfolder100).perform();
            //    iwebelement create_subfolder100 = driver.findelement(by.cssselector("body > div.context-menu > ul > li:nth-child(2)"));
            //    create_subfolder100.click();
            //    iwebelement subfolder_name100 = driver.findelement(by.id("foldername"));
            //    subfolder_name100.sendkeys("componentsfolder");
            //    iwebelement folder_type100 = driver.findelement(by.cssselector("#editroleform > div.form-group.row > div.col-sm-6.pull-right > select"));
            //    folder_type100.click();
            //    selectelement select100 = new selectelement(folder_type);
            //    system.collections.generic.ilist<openqa.selenium.iwebelement> options100 = select.options;
            //    select100.selectbytext("components");
            //    save_button.click();
            //    i++;
            //}
        //}
    }
}
