using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVLib.Implementations
{
    public class RAMDatabase : IDatabase
    {
        private Dictionary<long, Product> _products = new();
        private Dictionary<long, Ticket> _tickets = new();
        private long _currentGeneratingId = 1;
        public int ProductCount => _products.Count;
        public int TicketCount => _tickets.Count;
        //public void AddLineToTicketWithId(long id, TicketLine ticketLine)
        //{

        //}

        public long AddTicket(Header ticket)
        {
            if (ContainsTicket(ticket))
                throw new Exception("No se puede añadir");
            Ticket  newTicket = new Ticket();
            ticket.Id = _currentGeneratingId++;
            long id = ticket.Id;
            newTicket.Header = ticket;
            _tickets.Add(id, newTicket);
            return id;
        }

        public void AddTicketBodyWithId/*AddBodyToTicketWithId*/(long ticketId, Body body)
        {
            if (!_tickets.ContainsKey(ticketId))
                throw new Exception("The id doesn't exist.");
            _tickets[ticketId].Body = body;
        }

        public void AddTicketLineWithId/*AddLineToTicketWithId*/(long ticketId, TicketLine ticketLine)
        {
            if (!_tickets.ContainsKey(ticketId))
                throw new Exception("The id doesn't exist.");
            _tickets[ticketId].Body!.AddLine(ticketLine);
        }

        public TicketLine[] GetTicketLinesWithId(long ticketId)
        {//hacer un Contains
            if (!_tickets.ContainsKey(ticketId))
                throw new Exception("The id doesn't exist.");
            Ticket aux = _tickets[ticketId];
            int length = aux.Body!.Lines!.Length;
            TicketLine[] lines = new TicketLine[length];
            for (int i = 0; i < length; i++)
            {
                lines[i] = aux.Body!.Lines![i];
            }
           return lines;
        }

        public long AddProduct(Product product) 
        {
            if (ContainsProduct(product))
                throw new Exception("No se puede añadir");
            var cloneP = product.GetClone();
            cloneP.Id = _currentGeneratingId++;
            _products.Add(cloneP.Id, cloneP);
            return cloneP.Id;
        }

        public void RemoveProductWithId(long id)//Ver si se puede cambiar el key y el id del diccionario
        {
            if (id <= 0)
                throw new Exception("The id doesn't exist.");
            _products.Remove(id);
        }

        public Product? GetProductWithId(long id)
        {
            if (!_products.ContainsKey(id))
                throw new Exception("The id doesn't exist.");
            return _products[id].GetClone();
        }

        public void UpdateProductWithId(long id, Product product)
        {
            if (!_products.ContainsKey(id))
                throw new Exception("The id doesn't exist.");
            product.Id = _products[id].Id;
            // Javi: Clone
            _products[id] = product;
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            int startPos = offset - 1;
            int endPos = Math.Min(startPos + limit, ProductCount);

            if (offset < 0 || limit < 0 || startPos > endPos)
                throw new Exception("Valores incorrectos.");

            var products = new List<Product>();
            while (startPos < endPos)
            {
                startPos++;
                // Javi: Clone
                // Javi: Además, ..., aquí no estás haciendo lo que crees
                products.Add(_products[startPos]);
            }
            return products;
        }

        public bool ContainsProduct(Product product)
        {
            if (product == null)
                return false;
            // Javi: Mal, no usas bien el diccionario
            foreach (var p in _products)
            {
                if (p.Value.Id == product.Id) return true;
            }
            return false;
        }

        public bool ContainsTicket(Header ticket)
        {
            if (ticket == null)
                return false;
            // Javi: Lo mismo que arriba
            foreach (var t in _tickets)
            {
                if (t.Value.Header.Id == ticket.Id) return true;
            }
            return false;
        }

        public int IndexOf(Product product)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == product.Id)
                    return i;
            }
            return -1;
        }

        public Ticket GetTicketWithId(long ticketId)
        {
            if (!_tickets.ContainsKey(ticketId))
                throw new Exception("The id doesn't exist.");
            // Javi: Clone, no GetClone
            return _tickets[ticketId].GetClone();
        }

        public void UpdateTicketWithId(long ticketId, Ticket body)
        {
            if (!_tickets.ContainsKey(ticketId))
                throw new Exception("The id doesn't exist.");
            // Javi: Clone
            _tickets[ticketId] = body;
        }

        public void RemoveTicketWithId(long ticketId)
        {
            if (ticketId <= 0)
                throw new Exception("The id doesn't exist.");
            _products.Remove(ticketId);
        }

        //public void BeginTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Rollback()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
