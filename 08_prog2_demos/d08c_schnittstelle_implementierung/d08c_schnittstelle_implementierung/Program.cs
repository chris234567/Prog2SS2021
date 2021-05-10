using System;

namespace Demos
{
	class MyBaseClass
	{
		public virtual void MyBaseMethod()
		{
			Console.WriteLine("This is the base method.");
		}
	}

	interface IMyInterface
	{
		 void MyInterfaceMethod();
	}

	class MyClass : MyBaseClass, IMyInterface
	{
		public override void MyBaseMethod()
		{
			Console.WriteLine("This is the base method implemented in MyClass.");
		}

		public void MyInterfaceMethod()
		{
			Console.WriteLine("This is the interface method implemented in MyClass.");
		}
	}
		
	class Program
	{
		static void WriteAgain(MyBaseClass myBC, IMyInterface myI)
		{
			myBC.MyBaseMethod();
			myI.MyInterfaceMethod();

			// myBC.MyInterfaceMethod();	// Comment out for a compiler error!
			// myI.MyBaseMethod();	// Comment out for a compiler error!
		}

		static void Main()
		{
			MyClass myClass = new MyClass();

			myClass.MyBaseMethod();
			myClass.MyInterfaceMethod();

			Console.WriteLine();

			MyBaseClass myBaseClass = myClass;
			IMyInterface myInterface = myClass;

			WriteAgain(myBaseClass, myInterface);
		}
	}
}
