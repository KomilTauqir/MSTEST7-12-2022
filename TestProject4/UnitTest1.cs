using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
            driver.FindElement(By.Id("forename")).SendKeys("komal here");
            driver.FindElement(By.Id("submit")).Click();
       

        }

        [TestMethod]
        public void EneterName_popuptest()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
            driver.FindElement(By.Id("forename")).SendKeys("komal here");
            driver.FindElement(By.Id("submit")).Click();
            var popup = driver.FindElement(By.ClassName("popup-message"));
            //System.Threading.Thread.Sleep(500);
            new WebDriverWait (driver,TimeSpan.FromMilliseconds(500)).Until(d=>popup.Displayed);
            Assert.AreEqual(expected: "Hello komal here", actual: popup.Text);



        }



        [TestMethod]
        public void ClickDown_movesDown()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
            IWebElement button = driver.FindElement(By.ClassName("anibtn"));
            button.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000)).Until(d => button.Text != "CLICK ME DOWN!");   
            Assert.AreEqual(expected: "CLICK ME UP!", actual: button.Text);
         }


        [TestMethod]
        public void ClickUp_movesUp()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            IWebElement button = driver.FindElement(By.ClassName("anibtn"));
            if (button.Text == "CLICK ME DOWN!")
            {
                button.Click();
            }
            else
            { 
            }
            button.Click();
            System.Threading.Thread.Sleep(500);
            button.Click();

     

            //driver.FindElement(By.XPath("//*[contains(text(),'Click me')]")).Click();
            var clickmemsg = driver.FindElement(By.XPath("//*[contains(text(),'Click me')]")).Text;
            System.Threading.Thread.Sleep(500);
            // new WebDriverWait(driver, TimeSpan.FromMilliseconds(500)).Until(d => clickmemsg);
            Assert.AreEqual(expected: "CLICK ME DOWN!", actual: clickmemsg);


        }
    }

}