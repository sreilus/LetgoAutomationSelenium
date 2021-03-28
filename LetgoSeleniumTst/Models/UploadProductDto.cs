using System;
using System.Collections.Generic;
using System.Text;

namespace LetgoSeleniumTst.Models
{
	public class UploadProductDto
	{
		public decimal Price { get; set; }
		public string Title { get; set; }
		public string ProductFolderPath { get; set; }
	}
}
