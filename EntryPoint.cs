using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class SelectElementDropDownMenu
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement dropDownMenu;
    static IWebElement elementFromTheDropDownMenu;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/drop-down-menu-test/";
        // we can switch the number from 1 to 4(since we have only 4 value in the dropdown) to get the next dropdown element
        // here we are only checking the value of 3rd element in the drop down list
        string dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(3)";

        driver.Navigate().GoToUrl(url);

        dropDownMenu = driver.FindElement(By.Name("DropDownTest"));

        // this will give us the current selected value from the dropdown
        Console.WriteLine("The selected value is: " + dropDownMenu.GetAttribute("value"));

        elementFromTheDropDownMenu = driver.FindElement(By.CssSelector(dropDownMenuElements));
        // this will select the 3rd option from the dropdown and print it on the console window
        Console.WriteLine("The third option from the drop down menu is: " + elementFromTheDropDownMenu.GetAttribute("value"));

        elementFromTheDropDownMenu.Click();

        Console.WriteLine("The selected value is: " + dropDownMenu.GetAttribute("value"));
        Thread.Sleep(3000);

        // we are looping through to check all the value in the dropdown
        for (int i = 1; i <= 4; i++)
        {
            dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(" + i + ")";
            elementFromTheDropDownMenu = driver.FindElement(By.CssSelector(dropDownMenuElements));
            // it will give us the number of current option, and we can verify if it is correct or not
            Console.WriteLine("The " + i + " option from the drop down menu is: " + elementFromTheDropDownMenu.GetAttribute("value"));
        }

        Thread.Sleep(15000);

        driver.Quit();
    }
}