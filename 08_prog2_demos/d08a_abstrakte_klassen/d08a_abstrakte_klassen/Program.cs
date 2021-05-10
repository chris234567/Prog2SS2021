using System;

namespace Demos
{
	abstract class AbstractBase	// !
	{
		public int Data = 0;

		public void Method()
		{
			Console.WriteLine("Basic method with data = {0}", Data);
		}
	}

	class Derived : AbstractBase
	{
		public Derived()
		{
			Data = 23;
		}
	}

	class Program
	{
		static void Main()
		{
			AbstractBase abstractBase = null;

			// abstractBase = new AbstractBase();	// Comment out for compiler error!

			Derived derived = new Derived();

			abstractBase = derived;	// Ok, this is only a type conversion

			abstractBase.Method();
		}
	}
}
