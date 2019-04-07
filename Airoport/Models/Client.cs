using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class Man
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public Man() { }

        public Man(string _surname, string _name)
        {
            Surname = _surname;
            Name = _name;
        }
    }

    public class Client : Man
    {
        public int Id { get; set; }
        public int[] TicketListId { get; set; }
        public DateTime DateRegistration { get; set; } // readonly

        public Client() { }

        public Client(string _surname, string _name) :
            base(_surname, _name)
        {
            DateRegistration = DateTime.Now;
        }
    }
}