using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;


namespace App
{
    public static class Viewer
    {
        public static void ShowAllClients(IEnumerable<Client> clients)
        {
            Console.WriteLine("All clients:");

            foreach (var client in clients)
                Console.WriteLine("\t" + client);
        }

        public static void ShowAllClientsReservation(Array clients)
        {
            Console.WriteLine("All clients:");

            foreach (var client in clients)
                Console.WriteLine("\t" + client);
        }
    }
}
