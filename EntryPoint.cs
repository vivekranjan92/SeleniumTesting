using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class SpecialElementCheckBox
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement element;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/check-button-test-3/";
        // When we have multiple checkbox but we have to select some specific checkbox
        string option = "2";
        driver.Navigate().GoToUrl(url);

        // using XPath as the all the check box has same name,
        element = driver.FindElement(By.XPath("//*[@id=\"post-33\"]/div/p[7]/input[" + option + "]"));

        // converting the specified string representation of a logical value to its Boolean equivalent
        bool.TryParse(element.GetAttribute("checked"), out bool isChecked);

        if (isChecked)
        {
            Console.WriteLine("This checkbox is already checked!");
        }
        else
        {
            Console.WriteLine("We forgot to select the checkbox, lets check it!");
            element.Click();
        }

        driver.Quit();
    }

}