using System.Net.Sockets;
using TPVLib.Implementations;

namespace TPVLib
{
    public class TPV : ITPV
    {
        
        private IDatabase _db;

        private Dictionary<long, Product> _products = new();
        private Dictionary<long, Ticket> _tickets = new();
        private long _currentGeneratingId = 1;
        public int ProductCount => _products.Count;
        public int TicketCount => _tickets.Count;

        //Inyección de dependencias (Buscar)
        public TPV(IDatabase database)
        {
            _db = database;
        }

        /**public long AddProduct(Product product) => _db.AddProduct(product);
         * ...
         */
        public long AddProduct(Product product)//modificar
        {
            return _db.AddProduct(product);
        }

        public void RemoveProductWithId(long id)//Ver si se puede cambiar el key y el id del diccionario
        {
            _db.RemoveProductWithId(id);
        }

        public Product? GetProductWithId(long id)
        {
            return _db.GetProductWithId(id);
        }

        public void UpdateProductWithId(long id, Product product)
        {
            _db.UpdateProductWithId(id, product);
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            return _db.GetProducts(offset, limit);
        }

        public bool Contains(Product product)
        {
            if (product == null)
                return false;
            foreach (var p in _products)
            {
                if (p.Value.Id == product.Id) return true;
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

        public void SaveProducts(Product[] products, ITPV tpv)
        {
            if (products == null || tpv == null)
                throw new Exception("Incorrect data.");
            _products.Clear();
            int count = products.Length;
            for (int i = 0; i < count; i++)
            {
                _products.Add(1 + i, products[i]);
            }
        }

        public void SaveTickets(Ticket[] tickets, ITPV tpv)
        {
            if (tickets == null || tpv == null)
                throw new Exception("Incorrect data.");
            _tickets.Clear();
            int count = tickets.Length;
            for (int i = 0; i < count; i++)
            {
                _tickets.Add(1 + i, tickets[i]);
            }
        }

        //public void SaveProducts()
        //{
        //    Dictionary<long, Product> products = new();
        //    foreach (var product in _products)
        //        products.Add(product.Key, product.Value);
        //    _products.Clear();
        //    List<Product> saveProducts = _db.GetProducts(0, ProductCount);            
        //    for (int i = 0; i < ProductCount; i++)
        //    {
        //        _products.Add(1 + i, saveProducts[i]);
        //    }
        //}

        //public void SaveTickets()
        //{
        //    Dictionary<long, Ticket> tickets = new();
        //    foreach (var ticket in _tickets)
        //        tickets.Add(ticket.Key, ticket.Value);
        //    _tickets.Clear();
        //    List<Product> saveProducts = _db.GetProducts(0, TicketCount);
        //    for (int i = 0; i < ProductCount; i++)
        //    {
        //        _products.Add(1 + i, saveProducts[i]);
        //    }
        //}

        //public void AddTicket(Ticket ticket)
        //{
        //    try
        //    {
        //        _database!.BeginTransaction();

        //        long id = _database.AddTicket(ticket.Header!);
        //        foreach (var line in ticket.Body!.lines!)
        //        {
        //            _database.AddTicketLine(id, line);
        //        }

        //        _database.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        _database!.Rollback();
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public long AddTicket(Header header)
        //{
        //    try
        //    {
        //        _database.BeginTransaction();

        //        long id = _database.AddTicket(Ticket.Header);
        //        foreach (var line in Ticket.Body.Lines)
        //        {
        //            _database.AddTicketLine(id, line);
        //        }

        //        _database.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        _database.Rollback();
        //        throw new Exception(ex.Message);
        //    }
        //}
        /**public static void SaveTickets(Ticket[] tickets, ITPV tpv)
         * {
         *      try
         *      {
         *      _database.BeginTransaction();
         *       foreach(var line in Ticket.Body.Lines)
        //      {
        //         tpv.AddTicketLine(id, line);
        //      }   
         * 
         * 
         * 
         * }
         */
    }
}