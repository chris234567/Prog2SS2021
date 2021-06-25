using System;
using System.Collections.Generic;

namespace ProbeKlausurWS2020
{
    class Message
    {
        public String Text { get; set; }
        public String User { get; set; }
        public Message(string text, string user)
        {
            Text = text;
            User = user;
        }
    }
    class Server
    {
        public List<(string, string, Func<Message, bool>)> filter = new List<(string, string, Func<Message, bool>)>();

        public List<Message> messages = new List<Message>();
        public delegate void MessageDelegate(Message m);
        public delegate void SystemDelegate(string text);

        public static event MessageDelegate MessageLogger;
        public static event SystemDelegate SystemLogger;

        public void Store(Message m)
        {
            foreach (var triple in filter)
            {
                if (triple.Item3(m))
                {
                    SystemLogger(triple.Item1 + " " + triple.Item2);
                    return;
                }
            }
            MessageLogger(m);
            messages.Add(m);
        }
        public void RegisterReject(string name, string cause, Func<Message, bool> f) => filter.Add((name, cause, f));
        public void Print(Func<Message, bool> f)
        {
            Console.WriteLine();
            foreach(var message in messages)
            {
                if (f(message)) Console.WriteLine(message.Text);
            }
        }
    }
}
