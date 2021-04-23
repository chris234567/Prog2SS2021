using System;

namespace Uebung04
{
    class Device
    {
        Device Succesor { get; set; }
        public int NetAdress { get; set; }
        int Upload { get; set; }
        int Download { get; set; }
        static int numberOfInstances;
        public Device()
        {
            NetAdress = numberOfInstances++;
        }
    }
}
