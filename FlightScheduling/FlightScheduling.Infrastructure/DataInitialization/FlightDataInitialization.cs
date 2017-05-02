using FlightScheduling.Core.DomainModel;
using System;
using System.Collections.Generic;

namespace FlightScheduling.Infrastructure.DataInitialization
{
    public static class FlightDataInitialization
    {
        public static List<FlightModel> FlightData(int gateId)
        {
            List<FlightModel> flightModelData = new List<FlightModel>();
            for (int i = 1; i <= 10; i++)
            {
                flightModelData.Add(new FlightModel
                {
                    FlightID = (gateId * 100) + i,
                    FlightName = "Flight " + ((gateId * 100) + i),
                    GateID = gateId,
                    DepartureTime = DateTime.Now.AddMinutes((30 * i) + 29),
                    ArrivalTime = DateTime.Now.AddMinutes((30 * i)),
                    CancellationStatus = (i == 10) ? true : false,
                    Rescheduled = false
                });
            }
            return flightModelData;
        }
    }
}
