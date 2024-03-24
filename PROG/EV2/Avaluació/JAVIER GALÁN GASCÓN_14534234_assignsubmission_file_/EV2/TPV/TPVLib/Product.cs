namespace TPVLib
{
    public enum TaxesType
    {
        IVA,                //21%
        NO_IVA,             //0%
        REDUCED_IVA,        //10%
        SUPER_REDUCED_IVA   //4%
    }
    public record Product
    {//Se trabaja con properties en c# y se respeta que las clases sean lo más POJO posible porque cuando se hace una consulta solo devuelve un objeto 
     //con las properties si tiene variables que no se devuelven.
        public long Id { get; set;}
        public string? Name { get; init;}
        public string? Description { get; init; }
        public double Price { get; init; }
        public int Stock { get; init; }
        //public var Image { get; init;}
        public double IVA { get; init; }
        public TaxesType TaxType { get; init; }

        public Product GetClone()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                Stock = Stock,
                //Image = Image,
                IVA = IVA,
                TaxType = TaxType
            };
        }
    }
}
