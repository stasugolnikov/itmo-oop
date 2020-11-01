using System;
using System.Collections.Generic;
using Lab3.Interfaces;

namespace Lab3.Races
{
    public class GroundRace : IRace
    {
        public List<IVehicle> Vehicles { get; }
        public double Distance { get; }

        public GroundRace(double distance)
        {
            Distance = distance;
            Vehicles = new List<IVehicle>();
        }

        public void AddVehile(IVehicle vehicle)
        {
            if (!(vehicle is IGroundVehicle))
            {
                throw new VehicleTypeException("Wrong vehicle type");
            }
            Vehicles.Add(vehicle);
        }

        public IVehicle RunRace()
        {
            IVehicle winner = null;
            double winnerTime = Double.MaxValue;
            foreach (var vehicle in Vehicles)
            {
                double time = vehicle.DistanceTime(Distance);
                if (time <= winnerTime)
                {
                    winnerTime = time;
                    winner = vehicle;
                }
            }

            return winner;
        }
    }
}