using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            driver.Manage().Window.Maximize();
            driver.Url = "https://statsroyale.com";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }


        [Test]
        public void Ice_Spirit_Is_On_Cards_Page()
        {
            var cardPage = new CardsPage(driver);
            var iceSpirit = cardPage.Goto().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }


        [Test]
        public void Ice_Spirit_Header_Are_correct_On_Card_Details_Page()
        {

            //2. click Cards link in header nav
            // driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            //3. Go To ice spirit
            // driver.FindElement(By.CssSelector("s[href[href*='Ice+Spirit']")).Click();
            new CardsPage(driver).Goto().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            //4. Assert basic header ststs 
            var cardName = cardDetails.Map.CardName.Text;

            var cardRarity = cardDetails.Map.CardRarity.Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}