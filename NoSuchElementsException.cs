using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class NoSuchElementsException
{
    static void Main(string[] args)
    {
        string url = "http://testing.todvachev.com/selectors/css-path/";
        // intentionally providing wrong css to see the exception
        string cssPath = "#post-108 > divfigure > img";
        string xPath = "//*[@id=\"post-108\"]/div/figure/img";

        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(url);
        IWebElement xPathElement = driver.FindElement(By.XPath(xPath));
        IWebElement cssPathElement;

        try
        {
            // Handling the exception here with try and catch
            cssPathElement = driver.FindElement(By.CssSelector(cssPath));
            if(cssPathElement.Displayed)
            {
                GreenMessage("I can see the css element");
            }

        }
        catch (NoSuchElementException)
        {
            RedMessage("I can not see the css element");
        }
        if (xPathElement.Displayed)
        {
            GreenMessage("I can see the xPath element");
        }
        else
        {
            RedMessage("I can not see the xPath element");
        }
        Thread.Sleep(5000);
        driver.Quit();
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
