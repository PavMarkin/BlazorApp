using OpenQA.Selenium;

namespace BlazorPetProjectUITests
{

    public class Tests
    {
        IWebDriver driver;

        //XPath 
        public static string CounterPageUrl = "https://localhost:7146/counter";
        public static readonly By CounterValueFieldLocator = By.XPath("//p[@qa-id='CounterValue']");
        public static readonly By PlusOneButtonLocator = By.XPath("//button[@qa-id='IncreaseByOne']");
        public static readonly By PlusTwoButtonLocator = By.XPath("//button[@qa-id='IncreaseByTwo']");
        public static readonly By PlusThreeButtonLocator = By.XPath("//button[@qa-id='IncreaseByThree']");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(CounterPageUrl);
        }

        [Test]
        public void ClickPlusOneButton()
        {
            IsAtUrl(CounterPageUrl);
            Assert.IsTrue(GetCounterValue() == 0);
            driver.FindElement(PlusOneButtonLocator).Click();
            Assert.IsTrue(GetCounterValue() == 1);
        }

        [Test]
        public void ClickPlusTwoButton()
        {
            IsAtUrl(CounterPageUrl);
            Assert.IsTrue(GetCounterValue() == 0);
            driver.FindElement(PlusTwoButtonLocator).Click();
            Assert.IsTrue(GetCounterValue() == 2);
        }

        [Test]
        public void ClickPlusThreeButton()
        {
            IsAtUrl(CounterPageUrl);
            Assert.IsTrue(GetCounterValue() == 0);
            driver.FindElement(PlusThreeButtonLocator).Click();
            Assert.IsTrue(GetCounterValue() == 3);
        }

        public bool IsAtUrl(string url)
        {
            return driver.Url.Equals(url);
        }

        public int GetCounterValue()
        {
            return Int32.Parse(driver.FindElement(CounterValueFieldLocator).Text.Replace("Current count: ", ""));
        }

    }
}

