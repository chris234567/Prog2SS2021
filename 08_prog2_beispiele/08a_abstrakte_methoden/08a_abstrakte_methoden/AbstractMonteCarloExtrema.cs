using System;

namespace Examples
{
	namespace Tools
	{
		abstract class AbstractMonteCarloExtrema
		{
			public static uint IterationLimit = 1000;	// Maximal number of iterations

			public static double UnusedRatio = 0.5;	// Maximal ratio (w.r.t. IterationLimit) of unused iterations

			public string Description { get; private set; }
			
			public double DefinitionMin { get; private set; }
			public double DefinitionMax { get; private set; }

			public double FunctionMin { get; private set; }
			public double FunctionMax { get; private set; }

			protected AbstractMonteCarloExtrema(string description, double definitionMin, double definitionMax)
			{
				DefinitionMin = definitionMin;
				DefinitionMax = definitionMax;

				Description = description;
			}

			public abstract double Function(double x);

			public uint Update()
			{
				FunctionMin = double.MaxValue;
				FunctionMax = double.MinValue;
				
				Random random = new Random();

				uint iterations = 0;

				uint unusedIterations = 0;
						
				while(iterations < IterationLimit && unusedIterations < (uint)(UnusedRatio * IterationLimit))
				{
					double functionValue = Function(random.NextDouble() * (DefinitionMax - DefinitionMin) + DefinitionMin);

					if (FunctionMin > functionValue)
					{
						FunctionMin = functionValue;	// New minimum found						
						
						unusedIterations = 0;	// Reset unused iterations counter
					}
					else if (FunctionMax < functionValue)
					{
						FunctionMax = functionValue;	// New maximum found						

						unusedIterations = 0;	// Reset unused iterations counter
					}
					else
					{
						unusedIterations++;		// Unused iteration
					}

					iterations++;	// Increase iteration counter
				}

				return iterations;	// Return number of performed iterations
			}			
		}
	}
}
