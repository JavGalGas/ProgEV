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

        // Javi: Pon las funciones default al final
        // Javi: No hace falta el public
        public void RemoveProduct(Product product)
        {
            if(product != null)
                RemoveProductWithId(product.Id);
        }
        List<Product> GetProducts(int offset, int limit);

        // Javi: Esto está muy sucio, no lo pongas
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
