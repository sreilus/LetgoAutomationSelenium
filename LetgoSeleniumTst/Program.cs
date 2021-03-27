using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LetgoSeleniumTst
{
	public class Program
	{
		static void Main(string[] args)
		{
			LetgoTest letgoTest = new LetgoTest();
			letgoTest.StartSeleium();
			Console.WriteLine("Bitti");
		}
	}
}
