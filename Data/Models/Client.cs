using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patroymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{FirstName} - {SecondName} - {Patroymic} - {BirthDate} - {PhoneNumber}";
        }

    }
}
