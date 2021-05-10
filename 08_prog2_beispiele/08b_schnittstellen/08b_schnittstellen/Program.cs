using System;
using Examples.Tools;

namespace Examples
{
	class Function1 : ILimitedFunction
	{
		public string Description { get { return "f1(x) = x"; } }
		public double Value(double x) { return x; }

		public double LimitMin { get { return 0.0; } }
		public double LimitMax { get { return 3.0; } }
	}

	class Function2 : ILimitedFunction
	{
		public string Description { get { return "f2(x) = 1/2 * x² - 1"; } }
		public double Value(double x) { return 0.5 * x * x - 1.0; }

		public double LimitMin { get { return -2.0; } }
		public double LimitMax { get { return 2.0; } }
	}

	class Function3 : ILimitedFunction
	{
		public string Description { get { return "f3(x) = sin(x)"; } }
		public double Value(double x) { return Math.Sin(x); }

		public double LimitMin { get { return 0.0; } }
		public double LimitMax { get { return 2.0 * Math.PI; } }
	}

	class MinimumProblem : IProblem
	{
		public string Description { get { return "Minimum"; } }
		public double InitialValue { get { return double.MaxValue; }  }
		public bool Decide(double thisValue, double anotherValue) { return thisValue < anotherValue; }
	}

	class MaximumProblem : IProblem
	{
		public string Description { get { return "Maximum"; } }
		public double InitialValue { get { return double.MinValue; } }
		public bool Decide(double thisValue, double anotherValue) { return thisValue > anotherValue; }
	}

	class ZeroProblem : IProblem
	{
		public string Description { get { return "Zero"; } }
		public double InitialValue { get { return double.MaxValue; } }
		public bool Decide(double thisValue, double anotherValue) { return Math.Abs(thisValue) < anotherValue; }
	}

	class Program
	{
		static void WriteFunction(ILimitedFunction function)
		{
			Console.WriteLine("Function: " + function.Description);

			Console.WriteLine("  Definition range = [{0:f5}, {1:f5}]", function.LimitMin, function.LimitMax);
		}

		static void WriteProblemAndResult(ILimitedFunction function, IProblem problem, MonteCarloSolver solver)
		{
			ulong iterations = solver.Update(function, problem);

			Console.WriteLine("Problem: " + problem.Description);
						
			Console.WriteLine("  Result = {0:f5} (at parameter {1:f5})", solver.ResultValue, solver.ResultParameter);

			Console.WriteLine("    Performed iterations = {0:0,0}", iterations);
		}

		static void Main(string[] args)
		{
			// MonteCarloSolver.IterationLimit = 10000000;	// Comment to change change precision (and performance)

			// MonteCarloSolver.UnusedLimit = 1000000;	// Comment out to change (mainly) performance

			MonteCarloSolver solver = new MonteCarloSolver();
			
			ILimitedFunction[] functions = new ILimitedFunction[] 
			{ 
				new Function1(), new Function2(), new Function3()
			};			
			
			IProblem[] problems = new IProblem[]
			{
				new MinimumProblem(), new MaximumProblem(), new ZeroProblem()
			};

			foreach (ILimitedFunction function in functions)
			{
				WriteFunction(function);

				foreach (IProblem problem in problems)
				{
					WriteProblemAndResult(function, problem, solver);
				}

				Console.WriteLine();
			}
		}
	}
}
