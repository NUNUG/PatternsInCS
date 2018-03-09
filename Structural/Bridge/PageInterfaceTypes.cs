using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
	interface IGoogleSearchPage: IAbstractSearchPage
	{
		void DoGoogleSearch();
	}

	interface IBingSearchPage: IAbstractSearchPage
	{
		void DoBingSearch();
	}

	interface IAbstractSearchPage: IFormWebPage
	{
		string GetSearchBarText();
	}

	interface IFormWebPage: IWebPage
	{
		void ClearForm();
		void SetButtonText(string buttonText);
	}

	interface IWebPage: IPage
	{
		string URL { get; set; }
	}
	interface IPage
	{
		void CreatePage();
	}

	
}