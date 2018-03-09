using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
			p.Execute();
        }

		private IComponent GetOriginalComponent()
		{
			return new ConcreteComponent();
		}

		private IComponent GetDecoratedComponent()
		{
			return
				new UpperCaseDecorator(
					new AugmentingDecorator(
						new ConcreteComponent()));
		}

		private void Execute()
		{
			IComponent component = GetOriginalComponent();
			//IComponent component = GetDecoratedComponent();
			component.ShowData();
		}
	}

	public interface IComponent
	{
		void ShowData();
		string CreateData();
	}

	public class ConcreteComponent: IComponent
	{
		public void ShowData()
		{
			Console.WriteLine(CreateData());
		}

		public string CreateData()
		{
			Console.WriteLine("[Concrete component]");
			return "This is the original concrete object";
		}
	}

	public abstract class AbstractDecorator: IComponent
	{
		protected IComponent _component;
		
		public AbstractDecorator(IComponent component)
		{
			this._component = component;
		}

		// Notice that this is not an override because we DO NOT INHERIT the concrete class.
		// It is just an implementation of the method in IComponent.
		public void ShowData()
		{
			Console.WriteLine(CreateData());
		}

		public abstract string CreateData();
	}

	public class AugmentingDecorator: AbstractDecorator, IComponent
	{
		public AugmentingDecorator(IComponent component): base(component) { }
		public override string CreateData()
		{
			return $"{this._component.CreateData()}, which is augmented by {this.GetType().FullName}";
		}	
	}

	public class UpperCaseDecorator: AbstractDecorator, IComponent
	{
		public UpperCaseDecorator(IComponent component): base(component) { }
		public override string  CreateData()
		{
			return _component.CreateData().ToUpper();
		}
	}
}
