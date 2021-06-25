using System;
using System.IO;
using System.Collections;

namespace Uebung11b
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Directory.GetCurrentDirectory(); // Directory for the watcher

            watcher.NotifyFilter = NotifyFilters.FileName |
            NotifyFilters.DirectoryName; // Type of notfications (See NotifyFilters
                                         // in .NET documentation for more)
            watcher.Filter = ""; // Filter for the watcher (Empty string = Watch all)
            watcher.Renamed += MyRenameEvent; // Register own event handlers

            watcher.Created += MyCreatedEvent;
            watcher.Deleted += MyDeletedEvent;

            watcher.EnableRaisingEvents = true; // Start watching
            Console.WriteLine("Starting watcher in directory \"" + watcher.Path + "\"");
            Console.WriteLine("Please press a key to quit...");
            Console.ReadKey(true);*/

            Calc(x => x, -3, 3, 1);
            Calc(x => .5 * x * x + 1, -3, 3, 1);
            Calc(x => Math.Sin(x), -3, 3, 1);
        }
        delegate void MyD<T>(T obj) where T : ICloneable;
        static void MyRenameEvent(object sender, RenamedEventArgs args) 
        {
            Console.WriteLine(args.OldName + " was renamed to " + args.Name);
        }
        static void MyCreatedEvent(object sender, FileSystemEventArgs args) 
        {
            Console.WriteLine(args.Name + " was created");
        }
        static void MyDeletedEvent(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine(args.Name + " was deleted");
        }
        static void Calc(Func<double, double> f, double lower, double upper, double step)
        {
            for (double x = lower; x <= upper; x += step)
            {
                Console.Write(" x: " + x + " y: " + f(x));
            }
            Console.WriteLine();
        }
    }
}
