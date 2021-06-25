using System;
using System.Collections.Generic;

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

            server.RegisterReject("admin", "kein Marsianer", (Message m) => true ? m.Text.Contains("Mars") : false);

            server.Store(new Message("Hallo Mars", "test"));

            server.Print((Message m) => true);
            server.Print((Message m) => true ? m.Text.Length > 10 : false);
            server.Print((Message m) => true ? m.User == "test" : false);
        }
    }
}
