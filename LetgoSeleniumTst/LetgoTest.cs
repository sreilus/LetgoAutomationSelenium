using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LetgoSeleniumTst
{
	public class LetgoTest
	{
		private IWebDriver driver;
		public string homeURL;
		public LetgoTest()
		{
			driver = new ChromeDriver("C:\\Users\\Muhammet\\Desktop\\Muhammet\\Letgo-Test");
		}
		public void StartSeleium()
		{
			homeURL = "emailCode";

			driver.Navigate().GoToUrl(homeURL);
			//UploadProducts();
			DeleteProducts();

			Console.WriteLine("Hello World!");
		}

		#region Product Delete
		public void DeleteProducts()
		{
			Thread.Sleep(new TimeSpan(0, 0, 10));
			driver.FindElement(By.XPath("//div[@data-test ='avatar-header']")).Click();
			Thread.Sleep(new TimeSpan(0, 0, 5));
			driver.FindElement(By.XPath("//li[@data-test ='profile-menu-item']"))?.Click();
			Thread.Sleep(new TimeSpan(0, 0, 10));
			driver.FindElement(By.XPath("//button[@data-test ='permission_button_close']"))?.Click();
			for (int i = 0; i < 5; i++)
			{
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("//button[@data-test ='more-options-button']"))?.Click();
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("//span[@data-test ='delete-item-button']"))?.Click();
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/div[1]/div"))?.Click();
			}
		}
		#endregion

		#region Product Upload
		public void UploadProducts()
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(new TimeSpan(0, 0, 5));
				wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']")));
				var element = driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']"));
				element.Click();

				// Elementin görünür olması beklenir
				Thread.Sleep(new TimeSpan(0, 0, 10));
				//element = driver.FindElement(By.XPath("//div[@data-test ='sell-your-stuff-button image-upload category-choice-fashion-accessories']"));
				element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div[6]"));
				element.Click();

				// send image file
				string image1Path = @"C:\Users\Muhammet\Pictures\sky.jpg";
				string image1Path2 = @"C:\Users\Muhammet\Pictures\sky2.jpg";
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[2]/div/input")).SendKeys(image1Path);
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[4]/div/input")).SendKeys(image1Path2);

				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("//input[@data-testid ='price']")).SendKeys($"{270 + (i * 10)}");
				driver.FindElement(By.XPath("//input[@data-test ='listing-title-field']")).SendKeys($"Product Title {i}");
				Thread.Sleep(new TimeSpan(0, 0, 2));
				driver.FindElement(By.XPath("//button[@data-test ='confirm-sell-button']")).Click();

				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("//button[@data-test ='close-posting-drawer']")).Click();
			}
		}
		#endregion

	}
}
