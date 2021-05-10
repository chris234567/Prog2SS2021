using System;

namespace Demos
{
	class Program
	{
		interface IMyInterface1 
		{ 
			void MyMethod1();
			void MyAnotherMethod1(); 
		}

		interface IMyInterface2 
		{ 
			void MyMethod2(); 
		}

		interface IMyCombinedInterface : IMyInterface1, IMyInterface2 
		{ 
			void MyMethod3();
		}

		class MyClass : IMyCombinedInterface
		{
			public void MyMethod1()
			{
				Console.WriteLine("MyMethod1().");
			}
			public void MyAnotherMethod1()
			{
				Console.WriteLine("MyAnotherMethod1().");
			}

			public void MyMethod2()
			{
				Console.WriteLine("MyMethod2().");	
			}

			public void MyMethod3()
			{
				Console.WriteLine("MyMethod3().");
			}
		}
		
		static void Main()
		{
			MyClass myClass = new MyClass();

			myClass.MyMethod1();

			((IMyInterface1)myClass).MyAnotherMethod1();

			((IMyCombinedInterface)myClass).MyMethod2();

			myClass.MyMethod3();
		}
	}
}
