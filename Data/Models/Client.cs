using System;
using System.Collections.Generic;
using System.Text;

namespace HotelStructure.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}, {BirthDate.ToString("d")}, {PhoneNumber}";
        }

    }
}
