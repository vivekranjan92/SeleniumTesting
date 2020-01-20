using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Implementation of all the locators in selenium using C#
class SelectorInSelenium
{
    public static void testPrintMessage(IWebElement val, string token)
    {

        if (val.Displayed)
        {
            GreenMessage("Element with "+ token+ " is visible");
        }
        else
        {
            RedMessage("Element with " + token + " is not visible");
        }

        Thread.Sleep(3000);
    }

    public static void testMethod(string token)
    {
        const string url = "http://testing.todvachev.com/selectors";
        IWebDriver driver = new ChromeDriver();

        switch (token)
        {

            case "name":
                var nameUrl = url + "/" + token;
                driver.Navigate().GoToUrl(nameUrl);
                IWebElement nameElement = driver.FindElement(By.Name("myName"));
                testPrintMessage(nameElement, token);
                break;

            case "id":
                var idUrl = url + "/" + token;
                driver.Navigate().GoToUrl(idUrl);
                IWebElement idElement = driver.FindElement(By.Id("testImage"));
                testPrintMessage(idElement, token);
                break;

            case "class-name":
                var classNameUrl = url + "/" + token;
                driver.Navigate().GoToUrl(classNameUrl);
                IWebElement classNameElement = driver.FindElement(By.ClassName("testClass"));
                Console.WriteLine(classNameElement.Text);
                break;

            case "xpath":
                var xPathUrl = url + "/" + token;
                driver.Navigate().GoToUrl(xPathUrl);
                IWebElement xPathElement = driver.FindElement(By.XPath("//*[@id=\"post-109\"]/div/figure/img"));
                // 
                testPrintMessage(xPathElement, token);
                break;

            case "css-path":
                var cssSelectorUrl = url + "/" + token;
                driver.Navigate().GoToUrl(cssSelectorUrl);
                IWebElement cssElement = driver.FindElement(By.CssSelector("#post-108 > div > figure > img"));
                testPrintMessage(cssElement, token);
                break;

        }
        driver.Quit();
    }
    static void Main(string[] args)
    {
        var testStrings = new string[]
        {
            "id",
            "name",
            "css-path",
            "class-name",
            "xpath"
        };

        foreach (var token in testStrings)
        {
            testMethod(token);
        }
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
