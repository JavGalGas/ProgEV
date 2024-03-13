using System.Diagnostics;
using System.Xml.Linq;

namespace TPVLib
{
    public class Ticket
    {
        //Product[] _products = new Product[0];
        public Header Header { get; set; } = new Header();
        public Body Body { get; set; } = new Body();
        public double TotalPrice { get; set; }

        public Ticket GetClone()
        {
            return new Ticket()
            {
                Header = Header,
                Body = Body,
                TotalPrice = TotalPrice
            };
        }

    }
}
