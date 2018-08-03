using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace Demo
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:9780");

            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("admin");            

            IWebElement password = driver.FindElement(By.Id("Password")); 
            password.SendKeys("admin");

            IWebElement signin = driver.FindElement(By.CssSelector("#formLogin > div:nth-child(8) > div > button"));
            signin.Click();

            IWebElement header =  body > div.outer - wrapper > div > div > div > div > h2

        }
    }
}
