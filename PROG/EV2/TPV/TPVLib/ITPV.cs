namespace TPVLib
{
    public interface ITPV
    {
        //IDatabase database { get; }
        int ProductCount { get; }

        static ITPV CreateNewTPV(IDatabase db)
        {
            return new TPV(db);
        }

        long AddProduct(Product product);
        void RemoveProductWithId(long id);
        Product? GetProductWithId(long id);
        void UpdateProductWithId(long id, Product product);
        public void RemoveProduct(Product product)
        {
            if(product != null)
                RemoveProductWithId(product.Id);
        }
        List<Product> GetProducts(int offset, int limit);

        //public void AddTicket(Ticket ticket);

        // Modelo de Negocios            Modelo de Datos
        //      ITPV                        IDatabase
        //  AddTicket(Ticket)               AddProduct(product)
        //                                  ...
        //                                  AddTicketHeader(...)
        //                                  AddTicketLine(...)
        //                                  ...

        //CRUD - Tickets
        //No es infinita
        //Mostrar todo


    }
}
