using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Data
{
    public static class DispatcherContextExtensions
    {
        public static void EnsureDatabaseSeeded(this DispatcherContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Flights.Any())
            {
                context.Flights.AddRange(new List<Flight>
                {
                   new Flight{Number=1111,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,10,18,23,0),Destination="London",DestinationTime=new DateTime(2018,07,11,18,23,0) },
                   new Flight{Number=2222,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,11,18,23,0),Destination="Tokio",DestinationTime=new DateTime(2018,07,12,18,0,0)},
                   new Flight{Number=3333,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,12,18,23,0),Destination="Moskow",DestinationTime=new DateTime(2018,07,13,18,23,0)}
                });
                context.SaveChanges();
            }

            if (!context.Tickets.Any())
            {            
                    context.Tickets.AddRange(new List<Ticket>
                    {
                        new Ticket{Price=100,FlightNumber=1111,FlightId=1},
                        new Ticket{Price=120,FlightNumber=2222,FlightId=2},
                        new Ticket{Price=130,FlightNumber=3333,FlightId=3}
                    });
                context.SaveChanges();
            }

            if (!context.Pilots.Any())
            {
                context.Pilots.AddRange(new List<Pilot>
                    {
                        new Pilot{FirstName="Tom",LastName="Piton",BirthDate=DateTime.Parse("12.07.1998"),Experience=1},
                        new Pilot{FirstName="Ted",LastName="Pen",BirthDate=DateTime.Parse("28.03.1990"),Experience=2},
                        new Pilot{FirstName="Pavlo",LastName="Toden",BirthDate=DateTime.Parse("12.06.1994"),Experience=3}
                    });
                context.SaveChanges();
            }

            if (!context.Crews.Any())
            {
                context.Crews.AddRange(new List<Crew>
                    {
                        new Crew{PilotId=1},
                        new Crew{PilotId=2},
                        new Crew{PilotId=3}
                    });
                context.SaveChanges();
            }

            if (!context.Stewardesses.Any())
            {
                context.Stewardesses.AddRange(new List<Stewardess>
                    {
                        new Stewardess{FirstName="Anna",LastName="Piton",BirthDate=DateTime.Parse("12.07.1998"),CrewId=1},
                        new Stewardess{FirstName="Oly",LastName="Pen",BirthDate=DateTime.Parse("28.03.1990"),CrewId=2},
                        new Stewardess{FirstName="Hana",LastName="Toden",BirthDate=DateTime.Parse("12.06.1994"),CrewId=3}
                    });
                context.SaveChanges();
            }

            if (!context.PlaneTypes.Any())
            {
                context.PlaneTypes.AddRange(new List<PlaneType>
                    {
                        new PlaneType{Model="Passenger's",Seats=80,Carrying=47000},
                        new PlaneType{Model="Passenger's",Seats=120,Carrying=106000},
                        new PlaneType{Model="Passenger's",Seats=140,Carrying=156000}
                    });
                context.SaveChanges();
            }

            if (!context.Planes.Any())
            {
                context.Planes.AddRange(new List<Plane>
                    {
                       new Plane{Name="T-145",PlaneTypeId=1,ReleaseDate=DateTime.Parse("12.07.2000"),LifetimeTicks=(new DateTime(2020,07,12)-DateTime.Parse("12.07.2000")).Ticks},
                       new Plane{Name="AN-15",PlaneTypeId=2,ReleaseDate=DateTime.Parse("12.07.2001"),LifetimeTicks=(new DateTime(2020,07,12)-DateTime.Parse("12.07.2001")).Ticks},
                       new Plane{Name="LY-287",PlaneTypeId=3,ReleaseDate=DateTime.Parse("12.07.2002"),LifetimeTicks=(new DateTime(2020,07,12)-DateTime.Parse("12.07.2002")).Ticks}
                    });
                context.SaveChanges();
            }

            if (!context.Departures.Any())
            {
                context.Departures.AddRange(new List<Departure>
                    {
                        new Departure{FlightNumber=1111,Time=new DateTime(2018,07,10,19,23,0),CrewId=1,PlaneId=1,FlightId=1},
                        new Departure{FlightNumber=2222,Time=new DateTime(2018,07,11,18,23,0),CrewId=2,PlaneId=2,FlightId=2},
                        new Departure{FlightNumber=3333,Time=new DateTime(2018,07,12,18,23,0),CrewId=3,PlaneId=3,FlightId=3}
                    });
                context.SaveChanges();
            }

        }
    }
}
