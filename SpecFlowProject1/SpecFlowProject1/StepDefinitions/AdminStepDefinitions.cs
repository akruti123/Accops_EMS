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
    public class AdminFeatureStepDefinitions
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
        public AdminFeatureStepDefinitions()=>chromeDriver = new ChromeDriver();

        [Given(@"the Admin is on the login page")]
        public void GivenTheAdminIsOnTheLoginPage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Home/Login");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("login"));
        }

        [When(@"the Admin inputs (.*) as email")]
         public void WhenTheAdminInputsAsEmail(String email)
        {
            this.email = email;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement emailInputbox = wait.Until(e => e.FindElement(By.Id("Email")));
            emailInputbox.SendKeys(this.email);
        }

        [When(@"the Admin inputs (.*) as password")]
        public void WhenTheAdminAsPassword(String password)
        {
            this.password = password;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement passwordInputbox = wait.Until(e => e.FindElement(By.Id("Password")));
            passwordInputbox.SendKeys(this.password);
        }

        [When(@"the Admin clicks the Login button")]
        public void WhenTheAdminClicksTheLoginButton()
        {
            var submitButton = chromeDriver.FindElement(By.Name("submit"));
            System.Threading.Thread.Sleep(3000);
            submitButton.Click();
        }

        [Then(@"the Admin should be redirected to their dashboard")]
        public void ThenTheAdminShouldBeRedirectedToTheirDashboard()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
            chromeDriver.Close();
        }
        [Given(@"Admin is on the Admin Home Page")]
        public void GivenAdminIsOnTheAdminHomePage()
        {
            //System.Threading.Thread.Sleep(3000);
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Admin/AdminHomePage");
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
        }
        [When(@"the Admin clicks the Add New Department button")]
        public void WhenTheAdminClicksTheAddNewDepartmentButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            IWebElement addNewDepartmentButton = wait.Until(e => e.FindElement(By.Id("add_department")));
     
                addNewDepartmentButton.Click();  
        }

        [Then(@"the Admin is navigated to AddNewDepartment Page")]
        public void ThenTheAdminIsNavigatedToAddNewDepartmentPage()
        {
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adddepartment"));
        }

        [When(@"the Admin inputs (.*) as DepartmentName")]
        public void WhenTheAdminInputsAsDepartmentName(String departmentName)
        {
            this.departmentName = departmentName;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement emailInputbox = wait.Until(e => e.FindElement(By.Id("DepartmentName")));
            emailInputbox.SendKeys(this.departmentName);
        }

        [When(@"the Admin clicks on AddNewDepartment Button")]
        public void WhenTheAdminClicksOnAddNewDepartmentButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(100));
            IWebElement createButton = wait.Until(e => e.FindElement(By.Id("add_department")));
            System.Threading.Thread.Sleep(5000);
            try {
                createButton.Click();
            }
            
            catch 
            {
                Assert.Fail("Duplicate department found");
            }
        }
        [Then(@"the Admin should be redirected to the AdminHomePage")]
        public void ThenTheAdminShouldBeRedirectedToTheAdminHomePage()
        {
            System.Threading.Thread.Sleep(5000);
            // After search is complete the keyword should be present in url as well as page title`
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
            chromeDriver.Close();  
        }
        [Given(@"The Admin is on the Admin Home Page")]
        public void TheGivenAdminIsOnTheAdminHomePage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Admin/AdminHomePage");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
        }

        [When(@"the Admin clicks the AddNewEmployee button")]
        public void WhenTheAdminClicksTheAddNewEmployeeButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            IWebElement addNewEmployeeButton = wait.Until(e => e.FindElement(By.Id("create")));
            addNewEmployeeButton.Click();
        }

        [Then(@"the Admin is navigated to Create Page")]
        public void ThenTheAdminIsNavigatedToCreatePage()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("create"));
        }

        [When(@"the Admin enters (.*) as email")]
        public void WhenTheAdminEntersAsEmailId(String email)
        {
            this.email = email;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement emailInputbox = wait.Until(e => e.FindElement(By.Id("Email")));
            emailInputbox.SendKeys(this.email);
        }

        [When(@"the Admin  enters (.*) as password")]
        public void WhenTheAdminEntersAsPassword(string password)
        {
            this.password = password;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement passwordInputbox = wait.Until(e => e.FindElement(By.Id("Password")));
            passwordInputbox.SendKeys(this.password);
        }

        [When(@"the Admin inputs (.*) as name")]
        public void WhenTheAdminInputsAnuradhaAsName(string name)
        {
            this.name = name;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement passwordInputbox = wait.Until(e => e.FindElement(By.Id("Name")));
            passwordInputbox.SendKeys(this.name);
        }

        [When(@"the Admin inputs (.*) as role")]
        public void WhenTheAdminInputsEMPLOYEEAsRole(String role)
        {
            this.role = role;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement passwordInputbox = wait.Until(e => e.FindElement(By.Id("Role")));
            passwordInputbox.SendKeys(this.role);
        }

        [When(@"the Admin selects department Id")]
        public void WhenTheAdminInputsHRAsDepartmentId()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement se = wait.Until(e => e.FindElement(By.Id("DepartmentId")));
            se.Click();
        }

        [When(@"the Admin inputs joining date")]
        public void WhenTheAdminInputsPMAsJoiningDate()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement dt = wait.Until(e => e.FindElement(By.Id("JoiningDate")));
            dt.SendKeys("12112012");
            dt.SendKeys(Keys.ArrowRight);
            dt.SendKeys("1130P");
        }

        [When(@"the Admin inputs (.*) as address")]
        public void WhenTheAdminInputsBasantNagarAsAddress(string address)
        {
            this.address = address;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement addressInputBox = wait.Until(e => e.FindElement(By.Id("Address")));
            addressInputBox.SendKeys(this.address);
        }

        [When(@"the Admin inputs (.*) as city")]
        public void WhenTheAdminInputsGondiaAsCity(string city)
        {
            this.city = city;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement cityInputBox = wait.Until(e => e.FindElement(By.Id("City")));
            cityInputBox.SendKeys(this.city);
        }

        [When(@"the Admin inputs (.*) as phoneNumber")]
        public void WhenTheAdminInputsAsPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement cityInputBox = wait.Until(e => e.FindElement(By.Id("PhoneNumber")));
            cityInputBox.SendKeys(this.phoneNumber);
        }

        [When(@"the Admin inputs (.*) as state")]
        public void WhenTheAdminInputsMaharashtraAsState(string state)
        {
            this.state = state;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement stateInputBox = wait.Until(e => e.FindElement(By.Id("State")));
            stateInputBox.SendKeys(this.state);
        }

        [When(@"the Admin inputs (.*) as zipcode")]
        public void WhenTheAdminInputsAsZipcode(string zipCode)
        {
            this.zipCode = zipCode;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement zipInputBox = wait.Until(e => e.FindElement(By.Id("Zipcode")));
            zipInputBox.SendKeys(this.zipCode);
        }

        [When(@"the Admin inputs (.*) as country")]
        public void WhenTheAdminInputsIndiaAsCountry(string country)
        {
            this.country = country;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement countryInputBox = wait.Until(e => e.FindElement(By.Id("Country")));
            countryInputBox.SendKeys(this.country);
        }

        [When(@"the Admin clicks on Create Button")]
        public void WhenTheAdminClicksOnCreateButton()
        {
            /*var submitButton = chromeDriver.FindElement(By.Id("submit"));
            submitButton.Click();*/
            //System.Threading.Thread.Sleep(3000);
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(1000));
            IWebElement createButton = wait.Until(e => e.FindElement(By.Id("submit")));
            System.Threading.Thread.Sleep(4000);
            try
            {
                createButton.Click();
            }
            catch
            {
                Assert.Fail("Duplicate Details found");
            }
            finally { 
                chromeDriver.Close();
            }
        }
        [Given(@"User is on the AdminHomePage")]
        public void GivenUserIsOnTheAdminHomePage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Admin/AdminHomePage");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
        }

        [When(@"the Admin clicks the Edit Button")]
        public void WhenTheAdminClicksTheEditButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            IWebElement editEmployeeButton = wait.Until(e => e.FindElement(By.Id("edit_1004")));
            editEmployeeButton.Click();
        }

        [Then(@"the Admin should be navigated to the Edit Page")]
        public void ThenTheAdminShouldBeNavigatedToTheEditPage()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("/admin/edit"));
        }

        [When(@"the Admin enters (.*) as Name")]
        public void WhenTheAdminEntersAkrutiAsName(string name)
        {
            this.name = name;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement nameInputbox = wait.Until(e => e.FindElement(By.Id("Name")));
            nameInputbox.Clear();
            nameInputbox.SendKeys(this.name);
        }

        [When(@"the Admin enters (.*) as City")]
        public void WhenTheAdminEntersPuneAsCity(string city)
        {
            this.city = city;
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            IWebElement cityInputbox = wait.Until(e => e.FindElement(By.Id("City")));
            cityInputbox.Clear();
            cityInputbox.SendKeys(this.city);
        }

        [When(@"the Admin clicks on Update Button")]
        public void WhenTheAdminClicksOnUpdateButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(200));
            Actions actions = new Actions(chromeDriver);
            IWebElement updateButton = wait.Until(e => e.FindElement(By.Id("submit")));
            actions.MoveToElement(updateButton);
            System.Threading.Thread.Sleep(5000);
           
            updateButton.Click();
            chromeDriver.Close();
        }
        [Given(@"Admin is on the Admin_HomePage")]
        public void GivenAdminIsOnTheAdmin_HomePage()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:7009/Admin/AdminHomePage");
            chromeDriver.Manage().Window.Maximize();
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("adminhomepage"));
        }

        [When(@"the Admin clicks on the Delete Button")]
        public void WhenTheAdminClicksOnTheDeleteButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            IWebElement deleteButton = wait.Until(e => e.FindElement(By.Id("delete_1004")));
            deleteButton.Click();
        }

        [Then(@"the Admin is navigated to Delete Page")]
        public void ThenTheUserIsNavigatedToDeletePage()
        {
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("/admin/delete"));
        }
        [When(@"the Admin clicks the Delete Button")]
        public void WhenTheAdminClicksTheDeleteButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(100));
            IWebElement deleteButton = wait.Until(e => e.FindElement(By.Id("submit")));
            System.Threading.Thread.Sleep(5000);
            deleteButton.Click();
        }

    }
}

