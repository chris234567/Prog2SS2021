using System;

namespace Examples
{
	namespace Tools
	{
		interface IFunction
		{
			string Description { get; }
			double Value(double x);
		}

		interface IInterval
		{
			double LimitMin { get; }
			double LimitMax { get; }
		}

		interface ILimitedFunction : IFunction, IInterval
		{
		}

		interface IProblem
		{
			string Description { get; }
			double InitialValue { get; }
			bool Decide(double thisValue, double anotherValue);
		}

		class MonteCarloSolver
		{
			public static ulong IterationLimit = 1000;	// Maximal number of iterations

			public static ulong UnusedLimit = 500;	// Maximal number of unused iterations

			public double ResultValue { get; private set; }

			public double ResultParameter { get; private set; }
			
			public ulong Update(ILimitedFunction function, IProblem problem)
			{
				ResultValue = problem.InitialValue;
				
				ResultParameter = 0.0;
				
				Random random = new Random();

				ulong iterations = 0;

				ulong unusedIterations = 0;
						
				while (iterations < IterationLimit && unusedIterations <= UnusedLimit)
				{
					double functionParameter = random.NextDouble() * (function.LimitMax - function.LimitMin) + function.LimitMin;
					
					double functionValue = function.Value(functionParameter);

					if (problem.Decide(functionValue, ResultValue))	// Is "functionValue" better?
					{
						ResultValue = functionValue;	// Remember better function value

						ResultParameter = functionParameter;	// Remember corresponding function parameter

						unusedIterations = 0;	
					}
					else
					{
						unusedIterations++;						
					}

					iterations++;
				}

				return iterations;
			}			
		}
	}
}
