namespace TPVLib
{
    public interface IDatabase
    {

        //Tan cercana a la BD como sea posible
        //void BeginTransaction();
        /**void Comit();
         * void Rollback();
         */

        long AddProduct(Product product);
        void RemoveProductWithId(long id);
        Product? GetProductWithId(long id);
        void UpdateProductWithId(long id, Product product);
        public void RemoveProduct(Product product)
        {
            if (product != null)
                RemoveProductWithId(product.Id);
        }
        List<Product> GetProducts(int offset, int limit);

        public long AddTicket(Header ticket);
        public void AddTicketLineWithId(long ticketId, TicketLine ticketLine);
        public void AddTicketBodyWithId(long ticketId, Body body);
        TicketLine[] GetTicketLinesWithId(long ticketId);
        public Ticket GetTicketWithId(long ticketId);
        public void UpdateTicketWithId(long ticketId, Ticket body);
        public void RemoveTicketWithId(long ticketId);

        //public void AddLineToTicketWithId(long id, TicketLine ticketLine);
        //todas las funciones ADD
    }
}
