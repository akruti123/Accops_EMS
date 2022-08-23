using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class  EmployeeFeatureStepDefinitions
    {
        private string email;
        private string password;
        private string departmentName;
        private string name;
        private string role;
        private string address;
        private string city;
        private string phoneNumber;
        private string state;
        private string zipCode;
        private string country;
        private ChromeDriver chromeDriver;
        public EmployeeFeatureStepDefinitions()=>chromeDriver = new ChromeDriver();

        [Given(@"the Employee is on the login page")]
        public void GivenTheEmployeeIsOnTheLoginPage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Home/Login");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("login"));
        }

        [When(@"the Employee inputs (.*) as email")]
         public void WhenTheEmployeeInputsAsEmail(String email)
        {
            this.email = email;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement emailInputbox = wait.Until(e => e.FindElement(By.Id("Email")));
            emailInputbox.SendKeys(this.email);
        }

        [When(@"the Employee inputs (.*) as password")]
        public void WhenTheEmployeeAsPassword(String password)
        {
            this.password = password;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement passwordInputbox = wait.Until(e => e.FindElement(By.Id("Password")));
            passwordInputbox.SendKeys(this.password);
        }

        [When(@"the Employee clicks the Login button")]
        public void WhenTheEmployeeClicksTheLoginButton()
        {
            var submitButton = chromeDriver.FindElement(By.Name("submit"));
            System.Threading.Thread.Sleep(3000);
            submitButton.Click();
        }

        [Then(@"the Employee should be redirected to their dashboard")]
        public void ThenTheEmployeeShouldBeRedirectedToTheirDashboard()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("employeehomepage"));
            chromeDriver.Close();
        }

        [Given(@"Employee is on the EmployeeHomePage")]
        public void GivenEmployeeIsOnTheAdminHomePage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Employee/EmployeeHomePage?Name=Anuradha&PhoneNumber=12233434&JoiningDate=11%2F12%2F2012%2011%3A30%3A00&Address=Basant%20Nagar&City=Gondia&State=Maharashtra&Zipcode=441614&Country=India&DepartmentId=1&UserId=1005&Email=anjali@gmail.com&Password=anju&Role=EMPLOYEE");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("employeehomepage"));
        }

        [When(@"the Employee clicks the Edit Button")]
        public void WhenTheEmployeeClicksTheEditButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            IWebElement editEmployeeButton = wait.Until(e => e.FindElement(By.Id("edit_1005")));
            editEmployeeButton.Click();
        }

        [Then(@"the Employee should be navigated to the Edit Page")]
        public void ThenTheEmployeeShouldBeNavigatedToTheEditPage()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("/employee/edit"));
        }

        [When(@"the Employee enters (.*) as Name")]
        public void WhenTheEmployeeEntersAkrutiAsName(string name)
        {
            this.name = name;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement nameInputbox = wait.Until(e => e.FindElement(By.Id("Name")));
            nameInputbox.Clear();
            nameInputbox.SendKeys(this.name);
        }

        [When(@"the Employee enters (.*) as City")]
        public void WhenTheEmployeeEntersPuneAsCity(string city)
        {
            this.city = city;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement cityInputbox = wait.Until(e => e.FindElement(By.Id("City")));
            cityInputbox.Clear();
            cityInputbox.SendKeys(this.city);
        }

        [When(@"the Employee clicks on Update Button")]
        public void WhenTheEmployeeClicksOnUpdateButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(200));
            Actions actions = new Actions(chromeDriver);
            IWebElement updateButton = wait.Until(e => e.FindElement(By.Id("submit")));
            actions.MoveToElement(updateButton);
            System.Threading.Thread.Sleep(5000);

            updateButton.Click();
        }
        [Then(@"the Employee should be redirected to the EmployeeHomePage")]
        public void ThenTheEmployeeShouldBeRedirectedToTheEmployeeHomePage()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("employeehomepage"));
        }




    }
}

