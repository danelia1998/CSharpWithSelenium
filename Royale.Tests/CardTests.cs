using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }


        [Test]
        public void Ice_Spirit_Is_On_Cards_Page()
        {
            //1. go to statsroyale.com 
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com";


            //2. click Cards link in header nav
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // wait.Until( d => driver.FindElements(By.CssSelector("a[href='/cards']")).Count > 0 );
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            //3. Assert ice spirit is displayed
            // wait.Until( d => driver.FindElements(By.CssSelector("s[href[href*='/Ice+Spirit']")).Count > 0 );
            var iceSpirit = driver.FindElement(By.CssSelector("s[href[href*='/Ice+Spirit']"));
            Assert.That(iceSpirit.Displayed);

        }


        [Test]
        public void Ice_Spirit_Header_Are_correct_On_Card_Details_Page()
        {
            //1. go to statsroyale.com 
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com";


            //2. click Cards link in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            //3. Go To ice spirit
            driver.FindElement(By.CssSelector("s[href[href*='Ice+Spirit']")).Click();
            //4. Assert basic header ststs 
            var cardName = driver.FindElement(By.CssSelector("[class*='cardName']")).Text;
            var cardCategory = driver.FindElement(By.CssSelector(".card__rarity")).Text.Split(", ");
            var cardType = cardCategory[0];
            var cardArena = cardCategory[1];
            var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}