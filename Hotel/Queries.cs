using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;

namespace Hotel
{
    public class Queries
    {  
        public IEnumerable<Client> GetAllClients()
        {
            return from client in DataContext.Clients
                   select client;   
        }
        
        public Array GetClientsReservation()
        {
            var result = from reservation in DataContext.Reservations
                         join client in DataContext.Clients on reservation.ClientId equals client.Id
                         join room in DataContext.Rooms on reservation.RoomId equals room.Id
                         select new
                         {
                             FirstName = client.FirstName,
                             SecondName = client.SecondName,
                             Room = room.Number,
                             ArrivalDate = reservation.ArrivalDate,
                             EvictionDate = reservation.EvictionDate
                         };
            return result.ToArray();
        }
        
}
