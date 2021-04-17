using System;
namespace Uebung04
{
    class Simulator
    {
        Network.Token Token { get; set; }
        public Simulator(Network network, Network.Token token)
        {
            Token = token;
            Console.WriteLine("Starte Simulation...");

            if (network.Head is null) 
                throw new Exception("No valid network existent");

            token.Sender.Upload++;
            Console.WriteLine(
                $"Geraet {token.Sender.NetAddress} sendet Datenpaket (\"{token.Data}\"," +
                $" {token.Sender.NetAddress}, {token.Receiver.NetAddress})");

            Rout(token.Sender);
        }
        public void Rout(Network.Device device)
        {
            if (device.NetAddress.Equals(Token.Receiver.NetAddress))
            {
                device.Download++;
                Console.WriteLine(
                    $"Geraet {Token.Receiver.NetAddress} empfaengt Datenpaket (\"{Token.Data}\"," +
                    $" {Token.Sender.NetAddress}, {Token.Receiver.NetAddress})");

                return;
            } else 
            {
                if (device != Token.Sender)
                    Console.WriteLine(
                        $"Geraet {device.NetAddress} leitet Datenpaket (\"{Token.Data}\"," +
                        $" {Token.Sender.NetAddress}, {Token.Receiver.NetAddress}) weiter");

                Rout(device.Succesor);
            }
        }
    }
}
