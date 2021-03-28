using LetgoSeleniumTst.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
			homeURL = "https://www.letgo.com/en-tr?passwordlessLogin=EhP218yQo0JunA%3D%3D.fqqWMzdu8jQPRCPkbcG1DeYo5v9DMAZ9yTZ7m%2BgnVKDXHToe3zSB1EPILjfet2vltxNMeepFL%2FEp0unvEO2S8ph6UUK9D8G3%2BPq62BfKdcMQ4dMLYae7vWClCi8tIANOv4GE6StWvPGkxDmY9DLkanSkEDWpYhUbFBDHg8ecn4PZv6qrYMZKdM9Lt9e40Ox%2F8RTtOVzLrO13l8ZlOlI6uPEaWKfzrfnUh02WwMq1c9%2BAIGpsCg3E%2FAs7pB4LU30sR5xcLSNBT1Y7Zeftq16nfzTJ31H4sK%2FiihkyhfZy8llg7ZW0lq%2B3zzMt7y3TsuoiffaTluYsR4K3b2bNo%2F92ZA%3D%3D.KnKStqqoknBWroI%2FNSdugXsi9CHvjIbRJSqfKCjChQvCNd2eRsA42X%2FrxcJWMJcDQinOU1JmpiEMRT37K7R1bnTPmgWbthOSUCT%2Fi6IJLORHZtD8sedACrBawfGR3C%2FJicJWIKAZjY0K0s3u3igFP2JMtwzAxcBlpGNKleYnNeurJBuqgaeeArw1%2FlARCgqJKtqt3wC2Ujs6HjIcnv64Y4V3ZTqQkVofOlpASBMEg8owhkPnmHolabStK5W1j4EC1k4QgRLRrgODsjelL2FkbXMHlRFN3E4zYSk401JVOxhO%2BRIG89IV5XSBujR0ftU37vTQQAVlWitAVFZ0fUoaXw%3D%3D&utm_source=email&utm_campaign=passwordless";

			driver.Navigate().GoToUrl(homeURL);
			string folderPath = @"C:\Users\Muhammet\Desktop\Letgo\Letgo-Stuff";
			var directories = Directory.GetDirectories(folderPath);
			List<UploadProductDto> notUploadedProducts = new List<UploadProductDto>();
			List<UploadProductDto> failedPrdoucts = new List<UploadProductDto>();
			for (int i = 0; i < directories.Length; i++)
			{
				var directory = directories[i];
				var directorySplited = directory.Split("\\");
				var directoryName = directorySplited[directorySplited.Length - 1];
				var title = directoryName.Split("Title-")[1].Split("-")[0];
				var priceText = directoryName.Split("Price-")[1].Split("-")[0];
				decimal.TryParse(priceText, out decimal price);
				notUploadedProducts.Add(new UploadProductDto
				{
					Title = title,
					Price = price,
					ProductFolderPath = directory
				});
			}
			//DeleteProducts(80);
			// 53 numaraları ürün
			foreach (var product in notUploadedProducts.Skip(60).ToList())
			{
				try
				{
					UploadProducts(product);
				}
				catch (Exception ex)
				{
					failedPrdoucts.Add(product);
				}
			}

			foreach (var product in failedPrdoucts)
			{
				UploadProducts(product);
			}

			Console.WriteLine("Hello World!");
		}

		#region Product Delete
		public void DeleteProducts(int productCount)
		{
			Thread.Sleep(new TimeSpan(0, 0, 15));
			driver.FindElement(By.XPath("//div[@data-test ='avatar-header']")).Click();
			Thread.Sleep(new TimeSpan(0, 0, 5));
			driver.FindElement(By.XPath("//li[@data-test ='profile-menu-item']"))?.Click();
			Thread.Sleep(new TimeSpan(0, 0, 10));
			driver.FindElement(By.XPath("//button[@data-test ='permission_button_close']"))?.Click();
			for (int i = 0; i < productCount; i++)
			{
				Thread.Sleep(new TimeSpan(0, 0, 10));
				driver.FindElement(By.XPath("//button[@data-test ='more-options-button']"))?.Click();
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("//span[@data-test ='delete-item-button']"))?.Click();
				Thread.Sleep(new TimeSpan(0, 0, 5));
				driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/div[1]/div"))?.Click();
			}
		}
		#endregion

		#region Product Upload
		public void UploadProducts(UploadProductDto product)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			Thread.Sleep(new TimeSpan(0, 0, 8));
			//wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']")));
			var element = driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']"));
			element.Click();

			// Elementin görünür olması beklenir
			Thread.Sleep(new TimeSpan(0, 0, 10));
			//wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div[6]")));
			element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div/div/div[6]"));
			element.Click();

			// send image file
			string[] imagePaths = Directory.GetFiles(product.ProductFolderPath, "*.jpg");
			//string image1Path = @"C:\Users\Muhammet\Pictures\sky.jpg";
			//string image1Path2 = @"C:\Users\Muhammet\Pictures\sky2.jpg";

			for (int i = 0; i < imagePaths.Length; i++)
			{
				if (i == 0)
				{
					Thread.Sleep(new TimeSpan(0, 0, 10));
					//wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[2]/div/input")));
					driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[2]/div/input")).SendKeys(imagePaths[i]);
				}
				else
				{
					Thread.Sleep(new TimeSpan(0, 0, 10));
					//wait.Until(driver => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[4]/div/input")));
					driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[4]/div/input")).SendKeys(imagePaths[i]);
				}
			}

			Thread.Sleep(new TimeSpan(0, 0, 5));
			//wait.Until(driver => driver.FindElement(By.XPath("//input[@data-testid ='price']")));
			driver.FindElement(By.XPath("//input[@data-testid ='price']")).SendKeys(product.Price.ToString());
			driver.FindElement(By.XPath("//input[@data-test ='listing-title-field']")).SendKeys(product.Title);
			Thread.Sleep(new TimeSpan(0, 0, 2));
			//wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='confirm-sell-button']")));
			driver.FindElement(By.XPath("//button[@data-test ='confirm-sell-button']")).Click();

			Thread.Sleep(new TimeSpan(0, 0, 5));
			//wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='close-posting-drawer']")));
			driver.FindElement(By.XPath("//button[@data-test ='close-posting-drawer']")).Click();
		}
		#endregion

	}
}


