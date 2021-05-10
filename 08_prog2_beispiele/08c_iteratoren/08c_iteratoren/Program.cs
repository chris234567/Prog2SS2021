using System;
using Examples.Tools;

namespace Examples
{
	class Program
	{
		static void Main()
		{
			StringList stringList = new StringList();

			stringList.Prepend("iterator!");
			stringList.Prepend("my first ");
			stringList.Prepend("this is ");
			stringList.Prepend("Hello, ");
			
			foreach (string str in stringList)
			{
				Console.Write(str);
			}

			Console.WriteLine();
		}
	}
}
