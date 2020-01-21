using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class SpecialElementTextBox
{
    // Initializing chrome driver
    static IWebDriver driver = new ChromeDriver();
    static IWebElement textBox;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/text-input-field/";
        
        driver.Navigate().GoToUrl(url);
        // searching for the textbox with name locator username in the web-page
        textBox = driver.FindElement(By.Name("username"));
        // text to be entered in the text box
        textBox.SendKeys("Test text");

        Thread.Sleep(3000);
        // checking the maximum limit of the Text-Box
        Console.WriteLine(textBox.GetAttribute("maxlength"));

        Thread.Sleep(3000);
        
        driver.Quit();
    }

}