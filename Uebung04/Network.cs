using System;

namespace Uebung04
{
    class Network
    {
        public class Device
        {
            public Device Succesor { get; set; }
            public int NetAddress { get; set; }
            public int Upload { get; set; }
            public int Download { get; set; }
            public static int numberOfInstances; // should not get decreased if instance gets removed to maintain the unambiguity of a NetAddress
            public Device(Network network) 
            {
                NetAddress = numberOfInstances++;
                network.Size++;
            }
            public Device(int netAddress) { NetAddress = netAddress;  }
            public void Add(Network network)
            {
                if (Succesor == network.Head)
                {
                    Succesor = new Device(network);
                    Succesor.Succesor = network.Head;
                    return;
                }
                Succesor.Add(network);
            }
            public void Insert(Network network, int netAddress)
            {
                if (NetAddress != netAddress)
                {
                    if (network.CheckOverflow()) throw new Exception("Addresse konnte nicht gefunden werden");
                    Succesor.Insert(network, netAddress);
                }
                else
                {
                    var tmp = new Device(network);
                    tmp.Succesor = Succesor;
                    Succesor = tmp;
                }
                network.RunLength = 0; // reset
                return;
            }
            public void Pop(Network network, int netAddress)
            {
                if (network.CheckOverflow()) throw new Exception("Addresse konnte nicht gefunden werden");

                if (!Succesor.NetAddress.Equals(netAddress)) 
                    Succesor.Pop(network, netAddress);
                else 
                    Succesor = Succesor.Succesor;

                network.Size--;
                network.RunLength = 0; // reset
            }
            public Device GetDevice(int netAddress, Network network)
            {
                if (network.CheckOverflow()) 
                    throw new Exception("Packet konnte nicht zugestellt werden");
                if (!NetAddress.Equals(netAddress)) 
                    return this.Succesor.GetDevice(netAddress, network);

                network.RunLength = 0; // reset
                return this;
            }
            public void Print(Device head = null)
            {
                if (head is null) head = this;
                Console.WriteLine($"Geraet mit Addresse {NetAddress}: Anzahl Uploads/Downloads = {Upload}/{Download}");
                if (!Succesor.Equals(head)) Succesor.Print(head);
            }
        }
        public class Token
        {
            public string Data { get; set; }
            public Device Sender { get; set; }
            public Device Receiver { get; set; }
            public Token(string data, int sender, int receiver, Network n)
            {
                Data = data;
                Sender = n.Head.GetDevice(sender, n);
                Receiver = n.Head.GetDevice(receiver, n);
            }
        }
        public Network() => Head = null;
        public Device Head { get; set; }
        public int Size { get; set; }
        int RunLength { get; set; }
        public void Add(int netAddress = -1)
        {
            if (netAddress.Equals(-1))
            {
                if (Head != null) Head.Add(this);
                else
                {
                    Head = new Device(this);
                    Head.Succesor = Head;
                }
            }
            else Head.Insert(this, netAddress);
        }
        // remove on specific location
        public void Remove(int netAddress)
        {
            Head.Pop(this, netAddress);
        }
        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine("Leer");
                return;
            }
            Head.Print();
        }
        public bool CheckOverflow()
        {
            RunLength++;
            if (RunLength > Size) return true;
            return false;
        }
    }
}
