using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Hotel.ViewModels;


namespace Lab11
{
    public static class Viewer
    {
        public static void ShowAllClients(IEnumerable<Client> clients)
        {
            Console.WriteLine("All clients:");

            foreach (var client in clients)
                Console.WriteLine("\t" + client);
        }

        public static void ShowAllClientsReservation(IEnumerable<ReservationViewModel> clients)
        {
            Console.WriteLine("All clients:");

            foreach (var item in clients)
                Console.WriteLine("\t" + item.Client.FirstName + "\t" + item.Reservation.ArrivalDate);
        }

        public static void ShowClientSurnameInfo(IEnumerable<Client> ClientInfo)
        {
            Console.WriteLine("Client Info:");

            foreach (var client in ClientInfo)
                Console.WriteLine("\t" + client.FirstName + "\t" + client.SecondName + "\t" + client.PhoneNumber);
        }

        public static void ShowRoomTypes(IEnumerable<RoomTypeViewModel> RoomTypes)
        {
            Console.WriteLine("RoomTypes:");

            foreach (var item in RoomTypes)
                Console.WriteLine("\t" + item.Room.Number + "\t" + item.RoomType.Type);
        }


        public static void ShowRoomReservations(Dictionary<int, IEnumerable<Reservation>> reservations)
        {
            Console.WriteLine("All clients:");

            foreach (var item in reservations)
                Console.WriteLine("\t" + item.RoomId);
        }


    }
}

