using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowProject2.Pages;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow.CommonModels;
using Newtonsoft.Json;
using System.Reflection;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private Page Page;
        private IWebDriver WebDriver;
        private string URL;

        [Given(@"I navigate to cozy fairy netlify")]
        public void GivenINavigateToCozyFairyNetlify()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl("https://cozy-fairy-5394bc.netlify.app/");

            WebDriver.Manage().Window.Maximize();
            Page = new Page(WebDriver);
        }

        [When(@"I enter the login credentials")]
        public void WhenIEnterTheLoginCredentials()
        {
            Page.Username.SendKeys("gainchanger");
            Page.Password.SendKeys("justdoit");
        }


        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            Page.ClickLogInButton();
        }

        [Then(@"I would be redirected to gainchanger site")]
        public void IWwouldBeRedirectedToGainchangerSite()
        {
            URL = WebDriver.Url;
            Assert.AreEqual(URL, "https://www.gainchanger.com/");
            
        }

        [Then(@"I navigate to the resources menu")]
        public void INavigateToTheResourcesMenu()
        {
            WebDriver.Navigate().GoToUrl("https://www.gainchanger.com/resources/");
            
        }

        [Then(@"I access the first blog in the list of blogs")]
        public void IAccessTheFirstBlogInTheListOfBlogs()
        {
            //    Page.ClickResourcesMenu();
            Page.ClickFirstBlog();
        }


        [Then(@"I extract the fields")]
        public void IExtractTheFields()
        {
            // Extracting H1, MetaTitle, MetaDescription, H2 Elements, and P Elements
            string H1Content = Page.H1Content();
            // Console.WriteLine(H1Content);

            string MetaTitle = Page.MetaTitleContent();
            // Console.WriteLine(MetaTitle);

            string MetaDescription = Page.MetaDescriptionContent();
            // Console.WriteLine(MetaDescription);


            List<string> H2Contents = Page.H2Contents();
            /*    
            for(int i = 0; i < H2Contents.Count; i++)
            {
                Console.WriteLine("h2-" + i + ":" + H2Contents[i]);
            }
            */
            List<string> PContents = Page.PContents();
            /*  
            for(int i = 0; i < PContents.Count; i++)
            {
                Console.WriteLine("p-" + i + ":" + PContents[i]);
            }
            */

            // Exporting H1, MetaTitle, MetaDescription, H2 Elements, and P Elements 
            GainChanger GainChangerInstance = new GainChanger
            {
                H1 = H1Content,
                MetaTitle = MetaTitle,
                MetaDescription = MetaDescription,
                H2S = H2Contents,
                PS = PContents
            };

            // Serialize the extracted elements  
            string serializedJson = JsonConvert.SerializeObject(GainChangerInstance, Formatting.Indented);
            // Getting the current project path
            string projPath = Path.GetFullPath(@"..\..\..\");
            Console.WriteLine(projPath);

            // Exporting the fields in a file in JSON format
            File.WriteAllText(projPath + "\\ExtractedFields.JSON", serializedJson);

        }

        [Then(@"I quit the browser")]
        public void IQuitTheBrowser()
        {
            Page.QuitBrowser();
        }

    }
}
