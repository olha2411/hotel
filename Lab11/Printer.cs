﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Models.Enums;
using Hotel.ViewModels;


namespace Lab11
{
    public static class Printer
    {
        public static void PrintAllClients(IEnumerable<Client> clients)
        {            
            Console.WriteLine("All Clients:");

            foreach (var item in clients)
                Console.WriteLine("\t" + item);
            Console.WriteLine();
        }

        public static void PrintAllReservations(IEnumerable<ReservationViewModel> reservations)
        {            
            Console.WriteLine("All Reservations:");

            foreach (var reservation in reservations)
            {
                Console.WriteLine($"\t{reservation.Reservation} | {reservation.Room}, {reservation.RoomType} | {reservation.Client}");
            }
            Console.WriteLine();
        }
       
        public static void PrintAllReservationsGroupedByClient()
        {            
            Console.WriteLine("All Reservations With Room Info Grouped By Client, Sorted By Client Surname And CheckIn Date:");

            foreach (var client in query)
            {
                Console.WriteLine("\t" + client.Key);
                foreach (var reservation in client)
                    Console.WriteLine($"\t\t{reservation.Reservation} | {reservation.Room}, {reservation.RoomType}");
            }
            Console.WriteLine();
        }

        public static void PrintAllRoomsWithTheirTypes(IEnumerable<RoomTypeViewModel> rooms)
        {           
            Console.WriteLine("Rooms With Their Types:");

            foreach (var room in rooms)
            {
                Console.WriteLine($"\t{room.Room}, {room.RoomType}");
            }
            Console.WriteLine();
        }
       
        public static void PrintRoomsGroupedByType(Dictionary<RoomType, IEnumerable<Room>> rooms)
        {            
            Console.WriteLine("Rooms Grouped By Type:");

            foreach (var type in rooms)
            {
                Console.WriteLine($"\t{type.Key}");
                foreach (var room in type.Value)
                    Console.WriteLine($"\t\t{room}");
            }
            Console.WriteLine();
        }

        public static void PrintClientsWithFewReservations(IEnumerable<Client> reservations)
        {        
            Console.WriteLine("Clients With More Than 1 Reservation:");

            foreach (var client in reservations)
                Console.WriteLine($"\t{client}");
            Console.WriteLine();
        }
        
        public static void PrintDeluxeRooms(IEnumerable<Room> rooms)
        {           
            Console.WriteLine("Deluxe Rooms:");

            foreach (var room in rooms)
            {
                Console.WriteLine($"\t{room}");
            }
            Console.WriteLine();
        }
        
        public static void GetClientsWithReservationsCount()
        {
            
            Console.WriteLine("Clients With Reservations Count:");

            foreach (var item in query)
            {
                Console.WriteLine($"\t{item.Client}, {item.Count}");
            }
            Console.WriteLine();

        }

        public static void PrintRoomsWithReservations()
        {
            
            Console.WriteLine("Rooms With Reservations, Sorted By CheckIn Date:");

            foreach (var room in query)
            {
                Console.WriteLine($"\t{room.Key}");
                foreach (var reservation in room)
                    Console.WriteLine($"\t\t{reservation}");
            }
            Console.WriteLine();
        }

        public static void PrintOccupiedRooms()
        {
            
            Console.WriteLine("Currently Occupied Rooms:");

            foreach (var room in query)
            {
                Console.WriteLine($"\t{room.Room}, {room.RoomType}");
            }
            Console.WriteLine();
        }

        public static void PrintAdultClients(IEnumerable<Client> clients)
        {            
            Console.WriteLine("Client Who Are More Than 21:");

            foreach (var client in clients)
                Console.WriteLine($"\t{client}");
            Console.WriteLine();
        }

        public static void PrintUnoccupiedRooms(IEnumerable<RoomTypeViewModel> rooms)
        {            
            Console.WriteLine("Currently Unoccupied Rooms: ");

            foreach (var room in rooms)
                Console.WriteLine($"\t{room.Room}, {room.RoomType}");
            Console.WriteLine();
        }

        public static void PrintClientsWithPatroymic(IEnumerable<Client> clients)
        {            
            Console.WriteLine("Clients With Patroymic:");

            foreach (var client in clients)
                Console.WriteLine($"\t{client}");
            Console.WriteLine();
        }

        public static void PrintAllRoomOptions(IEnumerable<Options> options)
        {            
            Console.WriteLine("All Room Options:");

            foreach (var option in options)
            {
                Console.WriteLine($"\t{option}");
            }
            Console.WriteLine();
        }

        public static void PrintRoomsWithRefrigerator(IEnumerable<RoomTypeViewModel> rooms)
        {            
            Console.WriteLine("Rooms With Refrigerator:");

            foreach (var room in rooms)
                Console.WriteLine($"\t{room.Room}, {room.RoomType}");
            Console.WriteLine();
        }

    }
}