using System;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HeaderNav
    {

    }

    public class HeaderNavMap
    {
        IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement CardsTabLink => _driver.FindElement(By.CssSelector("a[href='/cards']"));
    }

}