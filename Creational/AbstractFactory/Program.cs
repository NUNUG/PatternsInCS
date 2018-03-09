using System;
using System.Collections.Generic;

namespace AbstractFactory
{
	public enum OSType { Windows10, OSX };

    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
        }

		public Program() 
		{
			var os = GetOS();
			var widgetFactory = GetWidgetFactory(os);
			widgetFactory.CreateForm().Paint();
			widgetFactory.CreateButton().Paint();
			widgetFactory.CreateEditBox().Paint();
		}

		public WidgetFactory GetWidgetFactory(OSType os)
		{
			if (os == OSType.Windows10)
				return new Windows10WidgetFactory();
			else if (os == OSType.OSX)
				return new OSXWidgetFactory();
			else
				throw new Exception($"Unsupported GUI ({os.ToString()})");
		}

		private OSType GetOS() 
		{	
			return OSType.OSX;
		}
    }

	// This should be abstract IRL, but I'm cheating on the implementation of Paint().
	public class Widget
	{
		public virtual void Paint()
		{
			Console.WriteLine($"Painting widget ({this.GetType().FullName})");
		}
	}

	public class Windows10Button: Widget { }
	public class Windows10Form: Widget { }
	public class Windows10EditBox: Widget { }
	public class OSXButton: Widget { }
	public class OSXForm: Widget { }
	public class OSXEditBox: Widget { }

	public abstract class WidgetFactory
	{
		public abstract Widget CreateButton();
		public abstract Widget CreateForm();
		public abstract Widget CreateEditBox();
	}

	public class Windows10WidgetFactory: WidgetFactory 
	{

		public override Widget CreateButton() { return new Windows10Button(); }
		public override Widget CreateForm() { return new Windows10Form(); }
		public override Widget CreateEditBox() { return new Windows10EditBox(); }
	}

	public class OSXWidgetFactory: WidgetFactory 
	{
		public override Widget CreateButton() { return new OSXButton(); }
		public override Widget CreateForm() { return new OSXForm(); }
		public override Widget CreateEditBox() { return new OSXEditBox(); }
	}
}
