using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Uebung02
{
    class _10FastFingers
    {
        public static void Game()
        {
			// Initialization:

			ValueQueue queue = new ValueQueue(countMax);
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			// Main loop:

			Console.WriteLine("Please press a key to start... (End with ESCAPE)");
			bool firstTime = true;

			while (Console.ReadKey().Key != ConsoleKey.Escape && !queue.Full)   // Use of property
			{
				if (firstTime)
					firstTime = false;

				else
					queue.Add(stopWatch.ElapsedMilliseconds);

				stopWatch.Restart();
			}

			// Summary:

			if (queue.Count > 0)
			{
				Console.WriteLine("\nSummary:");

				for (uint index = 0; index < queue.Count; index++)  // Use of property
					Console.WriteLine("{0}. Time span: {1} ms", index + 1, queue[index]);   // Use of indexer

				Console.WriteLine("Average time span: {0} ms", queue.Average());
			}
			else
				Console.WriteLine("\nNot enough values measured.");

			// Wait for ESCAPE:

			Console.WriteLine("Please quit application with ESCAPE...");
			while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
		}

		partial class ValueQueue
		{
			// Private datafields:

			private long[] values;

			// Constructor with one parameter:

			public ValueQueue(uint size)
			{
				if (size == 0)
					throw new ArgumentException("Invalid queue size!");

				values = new long[size];
			}

			// Methods:

			public void Add(long value)
			{
				values[Count++] = value;
			}
			public long Sum()
			{
				long sum = 0;

				foreach (uint value in values)
				{
					sum += value;
				}

				return sum;
			}
			public long Average() => Sum() / Count;

			// Read-only properties:

			public bool Full { get { return Count >= values.Length; } }

			// Auto-property:

			public uint Count { get; private set; }

			// Read-only indexer:

			public long this[uint index] => values[index]; 
		}
    }
}
