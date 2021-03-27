using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
			homeURL = "https://www.letgo.com/tr-tr?passwordlessLogin=kLMW0WY3QjdZ7g%3D%3D.vWhdVXzwlqwCMCaAisMbR2Ee8%2BMbizuNXhoMwcy1TYHpEWoAJ8RmEJcKG0Rir0wXrgn8zPyu6Ga9HM2YzwjYGqJFkDeVBy6E4RjvCnay4JrD4jn1l9C%2FYwy17bOtUNiX77C7bWD6gosIIgyXPm%2Fsz3AfaLqOZyxqdk0WcDcQKw7cGNXDP8LABVv40Fzff1o0WTzDdsHb4DrVPAIve4lRq3uUzl%2BxJWFOzlzHGwBwPQEeMWSesPgf7mxthOKOwiz%2BO3mKk3ZKw3SC9%2Bd2MHPepNHw6RHKMfUmC%2FVmq24EoMfP3mvb6L5XJ%2FrZA9ulI1SRVMei4xOA2Usgi%2BYTEDelkQ%3D%3D.qNJysAAPcwVh3P6dZ2MnSKHLbeKvb4og6Ezuq5Kv8bcjF%2Fgqx9U41IpLUh10yOg8KwPkd%2B7NomnumIM5VKisoUix9oL4gWX77akGg%2BSDldnoqkmlxWOImrP0Gdig1TbhQvX1Q%2Fvlr35W7cKuceoa9kDI7dfxjPc42CMp4MV3UPB6mkmnp19fkd8eIiGnz1%2BJex7tf35Lwu4ndJFBhtYmGLwfUEPDpk8XSxyZ0csViDjBhGbRLWjQiKtIw7czyjeFKMizcoPA0UY6RYu84gIndPiB8xfbjVkKTdNDOYkMtJjBb5bUdc9rwj1v4pPJT%2Bm5fQAtkt31H1ZH4fB%2FiCzuMw%3D%3D&utm_source=email&utm_campaign=passwordless";   
			driver.Navigate().GoToUrl(homeURL);
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			//wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='login']")));
			//var element = driver.FindElement(By.XPath("//button[@data-test ='login']"));
			//element.Click();

			//wait.Until(driver => driver.FindElement(By.XPath("//button[@data-testid ='login-google']")));
			//element = driver.FindElement(By.XPath("//button[@data-testid ='login-google']"));
			//element.Click();

			wait.Until(driver => driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']")));
			var element = driver.FindElement(By.XPath("//button[@data-test ='sell-your-stuff-button']"));
			element.Click();

			// Elementin görünür olması beklenir
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-test ='sell-your-stuff-button image-upload category-choice-fashion-accessories']")));
			Thread.Sleep(new TimeSpan(0, 0, 10));
			Assert.IsTrue(driver.FindElement(By.XPath("//div[@data-test ='sell-your-stuff-button image-upload category-choice-fashion-accessories']")).Displayed);
			//Elementin tıklanabilir olması beklenir
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-test ='sell-your-stuff-button image-upload category-choice-fashion-accessories']")));
			element = driver.FindElement(By.XPath("//div[@data-test ='sell-your-stuff-button image-upload category-choice-fashion-accessories']"));
			element.Click();
			//IWebElement element =
			//	driver.FindElement(By.XPath("//a[@href='/beta/login']"));
			Console.WriteLine("Hello World!");
		}

		// login xpath: //*[@id="app"]/main/div[1]/header/div/div/div[4]/button
		// ButtonBase-sc-1y9qvfw-0 ButtonStyle-sc-15r21gz-0 koGjqV	
		// ButtonBase-sc-1y9qvfw-0 ButtonStyle-sc-15r21gz-0 koGjqV
		// data-test = sell-your-stuff-button
	}
}
