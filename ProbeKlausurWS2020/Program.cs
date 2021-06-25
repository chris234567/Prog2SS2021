using System;

namespace ProbeKlausurWS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();

            Server.MessageLogger += (message) => Console.WriteLine($"Message Log: Nutzer {message.User} hat {message.Text} gesendet");
            Server.SystemLogger += (text) => Console.WriteLine($"System Message: {text}");

            server.Store(new Message("Hallo Welt", "test"));
            server.Store(new Message("Hallo Venus", "test"));
            server.Store(new Message("Hallo Merkur", "test"));

            server.RegisterReject("admin", "kein Marsianer", (Message m) => m.Text.Contains("Mars"));

            server.Store(new Message("Hallo Mars", "test"));

            server.Print((Message m) => true);
            server.Print((Message m) => m.Text.Length > 10);
            server.Print((Message m) => m.User == "test");
        }
    }
}
