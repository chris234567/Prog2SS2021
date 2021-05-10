using System;

namespace Demos
{
	abstract class AbstractGreetings
	{
		public void Greet()
		{
			Console.WriteLine("Hello {0}!", Name());
		}

		abstract protected string Name();	// !
	}

	class GreetingsPeter : AbstractGreetings
	{
		protected override string Name()
		{
			return "Peter";
		}
	}

	abstract class AbstractGreetingsGoodbye : AbstractGreetings	// Must also be abstract!
	{
		public void SayGoodbye()
		{
			Console.WriteLine("Goodbye.");
		}
	}

	class GreetingsGoodbyeSarah : AbstractGreetingsGoodbye
	{
		protected override string Name()
		{
			return "Sarah";
		}
	}

	class Program
	{
		static void Main()
		{
			GreetingsPeter greetingsPeter = new GreetingsPeter();

			greetingsPeter.Greet();

			// AbstractGreetingsGoodbye abstractGreetingsGoodbye = new AbstractGreetingsGoodbye();	// Comment out for compiler error!

			GreetingsGoodbyeSarah greetingsGoodbyeSarah = new GreetingsGoodbyeSarah();

			greetingsGoodbyeSarah.Greet();

			greetingsGoodbyeSarah.SayGoodbye();
		}
	}
}
