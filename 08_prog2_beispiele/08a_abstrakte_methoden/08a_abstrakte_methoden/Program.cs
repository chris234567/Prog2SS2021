using System;
using Examples.Tools;

namespace Examples
{
	class MonteCarloExtrema1 : AbstractMonteCarloExtrema
	{
		public MonteCarloExtrema1() : base("f1(x) = x", 0.0, 3.0) { }	// Initialize function description, definition minimum and maximum (via base constructor)
		public override double Function(double x) { return x; }	// Define function by overriding the abstract method from the base class
	}

	class MonteCarloExtrema2 : AbstractMonteCarloExtrema
	{
		public MonteCarloExtrema2() : base("f2(x) = 1/2 * x² - 1", -2.0, 2.0) { }
		public override double Function(double x) { return 0.5 * x * x - 1.0; }
	}

	class MonteCarloExtrema3 : AbstractMonteCarloExtrema
	{
		public MonteCarloExtrema3() : base("f3(x) = sin(x)", 0.0, 2.0 * Math.PI ) { }
		public override double Function(double x) { return Math.Sin(x); }
	}

	class Program
	{
		static void UpdateAndWrite(AbstractMonteCarloExtrema extrema)
		{
			uint iterations = extrema.Update();	// Execute Monte Carlo search
			
			Console.WriteLine("Function: " + extrema.Description);
			
			Console.WriteLine("Definition range = [{0:f5}, {1:f5}]", extrema.DefinitionMin, extrema.DefinitionMax);

			Console.WriteLine("Resultiung function extrema = [{0:f5}, {1:f5}]", extrema.FunctionMin, extrema.FunctionMax);

			Console.WriteLine("Performed iterations = {0}\n", iterations);
		}

		static void Main(string[] args)
		{
			// AbstractMonteCarloExtrema.IterationLimit = 10000000;	// Comment out for more iterations (higher precision)

			// AbstractMonteCarloExtrema.UnusedRatio = 0.1;	// Comment out for earlier termination (higher performance)

			UpdateAndWrite(new MonteCarloExtrema1());

			UpdateAndWrite(new MonteCarloExtrema2());

			UpdateAndWrite(new MonteCarloExtrema3());
		}
	}
}
