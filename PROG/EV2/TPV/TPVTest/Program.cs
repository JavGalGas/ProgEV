namespace TPVTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product()// id en Product o en el Key????
            {
                Id = 1,
                Name = "Coca-Cola",
                Stock = 40,
                Description = "Test",
                Price = 1,
                IVA = 20.2
            };
            Product product2 = new Product()
            {
                Id = 1,
                Name = "Pepsi",
                Stock = 40,
                Description = "Test2",
                Price = 1,
                IVA = 20.2
            };
            Console.WriteLine(tpv.AddProduct(product));
            Console.WriteLine(tpv.AddProduct(product2));
            Product product3 = new Product()
            {
                Id = -2,
                Name = "Fanta",
                Stock = 40,
                Description = "Test3",
                Price = 1,
                IVA = 20.2
            };
            Console.WriteLine(tpv.AddProduct(product3));
        }
    }
}