using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
	public class GoogleSearchPage: AbstractSearchPage, IGoogleSearchPage
	{
		public void DoGoogleSearch()
		{
			string searchExpression = GetSearchBarText();

			IList<string> results = new List<string>() as IList<string>;
			for (int j = 0; j < 9; j++)
			{
				results.Add($"Result #{j.ToString()}: Blah blah blah");
			}

			Console.WriteLine($"Google returned {results.Count.ToString()} results for search expression '{searchExpression}': ");
			results.ToList().ForEach(s => Console.WriteLine(s));
		}
	}

	public class BingSearchPage: AbstractSearchPage, IBingSearchPage
	{
		public void DoBingSearch()
		{
			string searchExpression = GetSearchBarText();

			Console.WriteLine("Bing returned 0 results.  There was actually an internal error in our server, but we won't tell you that.  But it doesn't matter.  You never had the bandwidth to download the results anyway because Bing users are probably still using a dialup modem and we wasted your time and bandwidth downloading a giant, colorful, feel-good hippy background picture before you ever entered your search criteria because that's what Bing users really want anyway.  A pretty picture to look at. Remember.  Have fun, but try to stay inside the lines.");
		}
	}

	public class AbstractSearchPage: FormWebPage, IAbstractSearchPage
	{
		public string GetSearchBarText()
		{
			Console.WriteLine("Enter search expression: ");
			string searchExpression = Console.ReadLine();
			return searchExpression;
		}
	}

	public class FormWebPage: WebPage, IFormWebPage
	{
		protected string _buttonText;

		public void ClearForm()
		{
			Console.WriteLine($"* ClearForm()");
		}
		public void SetButtonText(string buttonText)
		{
			Console.WriteLine($"* SetButtonText({buttonText})");
			this._buttonText = buttonText;
		}
	}

	public class WebPage: Page, IWebPage
	{
		public string URL { get; set; }
	}
	public class Page: IPage
	{
		public void CreatePage()
		{
			// Pretend we output some HTML here.
			Console.WriteLine("* CreatePage()");
		}
	}

	
}