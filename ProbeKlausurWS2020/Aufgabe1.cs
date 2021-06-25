using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeKlausurWS2020
{
    interface IWaterResistent 
    {
        public int LoadVolume { get; }
        public bool Motorized { get; }
    }
    abstract class Vehicle
    {
        private string numberPlate;
        private int vehicleID;
        private int permissibleTotalWeight;
        public Vehicle(string nP, int vId, int pTW)
        {
            numberPlate = nP;
            vehicleID = vId;
            permissibleTotalWeight = pTW;
        }
        public virtual string GetInfo() => $"({vehicleID})-({numberPlate})-({permissibleTotalWeight})";
    }
    abstract class LandVehicle : Vehicle 
    {
        private int numberWheels;
        private bool couplingDevice;
        public LandVehicle(int nW, bool cD, string nP, int vId, int pTW) : base(nP, vId, pTW)
        {
            numberWheels = nW;
            couplingDevice = cD;
        }
        public override string GetInfo() => $"({numberWheels})-({couplingDevice})-" + base.GetInfo();
    }
    abstract class WaterVehicle : Vehicle 
    {
        private int loadVolume;
        private bool motorized;
        public WaterVehicle(int lV, bool m, string nP, int vId, int pTW) : base(nP, vId, pTW)
        {
            loadVolume = lV;
            motorized = m;
        }
        public override string GetInfo() => $"({loadVolume})-({motorized})-" + base.GetInfo();
    }
    class Car : LandVehicle 
    {
        readonly int numberSeats;
        public Car(int nS, int nW, bool cD, string nP, int vId, int pTW) : base(nW, cD, nP, vId, pTW)
        {
            numberSeats = nS;
        }
    }
    class Truck : LandVehicle 
    {
        readonly int payload;
        public Truck(int p, int nW, bool cD, string nP, int vId, int pTW) : base(nW, cD, nP, vId, pTW)
        {
            payload = p;
        }
    }
    sealed class AmphibianVehicle : LandVehicle, IWaterResistent
    {
        public int LoadVolume { get; }
        public bool Motorized { get; }
        public AmphibianVehicle(int lV, bool m, int p, int nW, bool cD, string nP, int vId, int pTW) : base(nW, cD, nP, vId, pTW)
        {
            LoadVolume = lV;
            Motorized = m;
        }
    }
    class VehicleList
    {
        private List<Vehicle> vehicleFleet;
        public void AddLandVehicle(Vehicle v) 
        { 
            if (v is LandVehicle)
            {
                vehicleFleet.Add(v);  // (v as LandVehicle) ??
            }
            else
            {
                throw new System.ArgumentException("Not a land vehicle!");
            }
        }
        public void PrintVehicleInfo()
        {
            foreach (var vehicle in vehicleFleet)
            {
                System.Console.WriteLine(vehicle);
            }
        }
    }
}
