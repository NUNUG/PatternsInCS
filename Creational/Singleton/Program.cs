using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
			string s1 = "There can be only one.";
            Clipboard.Instance.CopyTextToClipboard(s1);

			string s2 = Clipboard.Instance.PasteTextFromClipboard();
			Console.WriteLine(s2);
        }
    }
}
