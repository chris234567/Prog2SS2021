using System;

namespace Demos
{
	interface IMyInterface 
	{ 
		void MyInterfaceMethod(); 
		void MyNextInterfaceMethod();
	}

	interface IMyAnotherInterface 
	{ 
		void MyInterfaceMethod();
		void MyNextInterfaceMethod();
	}

	class MyClass : IMyInterface, IMyAnotherInterface
	{
		void IMyInterface.MyInterfaceMethod()	// No acesss modifier!
		{
			Console.WriteLine("This is MyInterfaceMethod(), declared in IMyInterface.");
		}

		void IMyAnotherInterface.MyInterfaceMethod()	// No acesss modifier!
		{ 
			Console.WriteLine("This is MyInterfaceMethod(), declared in IMyAnotherInterface.");
		}

		public void MyNextInterfaceMethod()	// But here with public!
		{
			Console.WriteLine("This is MyNextInterfaceMethod(), declared in both interfaces.");
		}
	}

	class Program
	{
		static void Main()
		{
			MyClass myClass = new MyClass();

			((IMyInterface)myClass).MyInterfaceMethod();

			((IMyAnotherInterface)myClass).MyInterfaceMethod();

			myClass.MyNextInterfaceMethod();
		}
	}
}
