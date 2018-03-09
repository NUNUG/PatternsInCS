using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {

			/*
			Bridge pattern provides a "ladder" of interface and concrete types in a chain of inheritance.
			Our example looks like this:
				[ Page ] ---------------------> [ IPage ]
				  ^                               ^
				  |                               |
				[ WebPage ] ------------------> [ IWebPage ]
				  ^                               ^
				  |                               |
				[ FormWebPage ] --------------> [ IFormWebPage ]
				  ^                               ^
				  |                               |
				[ AbstractSearchPage ] -------> [ IAbstractSearchPage ]
				  ^                               ^
				  |                               |
				[ GoogleSearchPage ] ---------> [ IGoogleSearchPage ]

			 */

            Program p = new Program();
			try{
				p.Execute();
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
        }

		private void Execute()
		{
			Console.WriteLine("-----------------------------------------------Google Search");
			var google = new GoogleSearchPage() as IGoogleSearchPage;
			google.DoGoogleSearch();


			Console.WriteLine();
			Console.WriteLine("-----------------------------------------------Bing Search");
			var bing = new BingSearchPage() as IBingSearchPage;
			bing.DoBingSearch();
		}
	}
}
