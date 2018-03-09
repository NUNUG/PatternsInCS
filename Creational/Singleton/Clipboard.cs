using System;

namespace Singleton
{
	public sealed class Clipboard
	{
		// This is the only instance of the class that should ever exist.
		// We make it static because... there can be only one.
		// We make it private so that we can... Keep it secret.  Keep it safe.
		private static Clipboard _instance = null;

		// Hide the constructor so we can control the creation of this object.
		// We do this by making it private.
		// Now WE run Bartertown.
		private Clipboard() { }

		// Since there is no accessible constructor, we provide this 
		// entry point which we can police.
		// Here, we are the keymasters.  Here, we are the gatekeepers. 
		public static Clipboard Instance
		{
			get 
			{
				// The first time we call this, there is no instance 
				// because this is a lazy implementation.
				// So we have to check for it.
				if (_instance == null)
					_instance = new Clipboard();
				return _instance;
			}
		}

		private string _text = string.Empty;
		public void CopyTextToClipboard(string text)
		{
			_text = text;
		}
		public string PasteTextFromClipboard()
		{
			return _text;
		}
	}
}
