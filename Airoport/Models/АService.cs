using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airoport.Models
{
    public class AService
    {
        private static AService instance = new AService(); 
        private ClientContext dbClient = new ClientContext();
        private TicketContext dbTicket = new TicketContext();
        private CityContext dbCity = new CityContext();

        private AService() { }
        public static AService GetInstance()
        {
            return instance;
        }


        public ClientContext GetClientContext()
        {
            return dbClient;
        }
        public IEnumerable<Client> GetEnumerableForClientContext()
        {
            IEnumerable<Client> clientsEnumerable = dbClient.Clients;
            return clientsEnumerable;
        }
        public bool AddElementInClientContext(Client client)
        {
            try
            {
                dbClient.Clients.Add(client);
                dbClient.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
            
        }


        public TicketContext GetTicketContext()
        {
            return dbTicket;
        }
        public IEnumerable<Ticket> GetEnumerableForTicketContext()
        {
            IEnumerable<Ticket> ticketsEnumerable = dbTicket.Tickets;
            return ticketsEnumerable;
        }
        public bool AddElementInTicketContext(Ticket ticket)
        {
            try
            {
                dbTicket.Tickets.Add(ticket);
                dbTicket.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool RemoveElementOfTicketContext(Ticket ticket)
        {
            try
            {
                ticket = dbTicket.Tickets.Find(ticket.Id);
                if (ticket == null)
                {
                    return false;
                }
                dbTicket.Tickets.Remove(ticket);
                dbTicket.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public Ticket FindTicketById (int id)
        {
            return dbTicket.Tickets.Find(id);
        }

        public CityContext GetCityContext()
        {
            return dbCity;
        }
        public IEnumerable<City> GetEnumerableForCityContext()
        {
            IEnumerable<City> CitiesEnumerable = dbCity.Cities;
            return CitiesEnumerable
;
        }
        public SelectList GetSelectListForCities()
        {
            return new SelectList(dbCity.Cities, "Id", "Name");
        }
        public IEnumerable<SelectListItem> GetSelectListForCities(string kay)
        {
            return new SelectList(dbCity.Cities, "Name", kay);
        }

    }
}