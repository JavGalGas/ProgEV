namespace TPVLib
{
    public class TicketLine
    {
        //public long TicketId {get; set; }
        public string? Details/*Concept*/ { get; set; }
        public double Quantity { get; set; }
        public Product? Product { get; set; }

    }

    //public class TicketLine
    //{
    //    public string Details { get; set; }
    //    public double Quantity {get; set;}
    //      public Product Product { get; set; }
    //}Se podría hacer con long ProductId, pero tendrías que hacer un query por cada producto
}
