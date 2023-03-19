
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace SpecFlowProject2.Pages
{
    public class Page
    {
     //   public IWebDriver webDriver { get; }

        public IWebDriver WebDriver { get; }
        public Page(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public IWebElement Username => WebDriver.FindElement(By.XPath("//input[@id='username']"));
        public IWebElement Password => WebDriver.FindElement(By.Id("password"));

        public IWebElement LoginButton => WebDriver.FindElement(By.Id("submit"));

        public IWebElement ResourcesMenu => WebDriver.FindElement(By.LinkText("Resources"));

        public IWebElement FirstBlog => WebDriver.FindElement(By.XPath("//div//article[1]"));

        public IWebElement H1Element => WebDriver.FindElement(By.XPath("//div//h1"));

        public IWebElement MetaTitle => WebDriver.FindElement(By.XPath("//meta[contains(@property, 'title')]"));

        public IWebElement MetaDescription => WebDriver.FindElement(By.XPath("//meta[contains(@property, 'description')]"));

        public List<IWebElement> H2Elements => WebDriver.FindElements(By.XPath("//div//h2")).ToList();

        public List<IWebElement> PElements => WebDriver.FindElements(By.XPath("//div//p")).ToList();


     //   public IWebDriver WebDriver { get; }

        public void ClickLogInButton() => LoginButton.Click();

        public void ClickResourcesMenu() => ResourcesMenu.Click();
        public void ClickFirstBlog() => FirstBlog.Click();

        public string H1Content() => H1Element.Text;

        public string MetaTitleContent() => MetaTitle.GetAttribute("content");

        public string MetaDescriptionContent() => MetaDescription.GetAttribute("content");

        public List<string> H2Contents()
        {
            List<string> H2S = new List<string>() { };
            foreach (var H2 in H2Elements)
            {
                H2S.Add(H2.Text);
            }
            return H2S;
        }

        public List<string> PContents()
        {
            List<string> PS = new List<string>() { };
            foreach (var P in PElements)
            {
                PS.Add(P.Text);
            }
            return PS;
        }

        public void MaximizeBrowserWindow() => WebDriver.Manage().Window.Maximize();
        public void QuitBrowser() => WebDriver.Quit();

    }
}
