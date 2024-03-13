using System.ComponentModel.DataAnnotations;

namespace TPVLib
{
    public class Body
    {
        public TicketLine[] Lines { get; set; } = new TicketLine[0];

        public void AddLine(TicketLine line)
        {
            if (line == null)
                return;

            int count = Lines.Length;
            TicketLine[] aux= new TicketLine[++count];
            for (int i = 0; i < count; i++)
            {
                aux[i] = Lines[i];
            }
            aux[count-1] = line;
            Lines = aux;
        }

    }
}