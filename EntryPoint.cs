using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class SpecialElementRadioButton
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement radioButton;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/radio-buttontest/";
        // We have 3 different radio button so keeping them in to an array So that we can iterate it through for loop
        string[] option = { "1", "3", "5" };

        driver.Navigate().GoToUrl(url);

        for (int i = 0; i < option.Length; i++)
        {
            // using CssSelector as it is fast compared to other locators and name selector has same name for all the radio button
            radioButton = driver.FindElement(By.CssSelector("#post-10 > div > form > p:nth-child(6) > input[type =\"radio\"]:nth-child(" + option[i] + ")"));

            // condition to check if the radio button is checked or not
            if (radioButton.GetAttribute("checked") == "true")
            {
                Console.WriteLine("The " + (i + 1) + " radio button is checked!");
            }
            else
            {
                Console.WriteLine("This is one of the unchecked radio buttons!");
            }
        }
        
        driver.Quit();
    }
}