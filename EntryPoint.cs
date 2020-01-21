using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class SpecialElementAlertBox
{
    static IWebDriver driver = new ChromeDriver();
    static IAlert alert;
    static IWebElement image;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/alert-box/";

        driver.Navigate().GoToUrl(url);

        // Initializing the alert
        alert = driver.SwitchTo().Alert();

        // to get the text out of the alert
        Console.WriteLine(alert.Text);

        // when click on ok to dismiss the alert, we have to make use of Accept()
        alert.Accept();

        image = driver.FindElement(By.CssSelector("#post-119 > div > figure > img"));

        try
        {
            if (image.Displayed)
            {
                Console.WriteLine("The alert was successfuly accepted and I can see the image!");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Something went wrong!!");
        }

        Thread.Sleep(3000);

        driver.Quit();
    }
}