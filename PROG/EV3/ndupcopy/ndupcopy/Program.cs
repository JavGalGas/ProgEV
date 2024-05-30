using System.Text.Json;

namespace ndupcopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[]
            {
                //"-i", @"C:\Users\javie\Desktop\1 DAM\PROGRAMACION\ProgEV\PROG\EV3\ndupcopy\paths\entry1",
                //"-i", @"C:\Users\javie\Desktop\1 DAM\PROGRAMACION\ProgEV\PROG\EV3\ndupcopy\paths\entry2",
                //"-i", @"C:\Users\javie\Desktop\1 DAM\PROGRAMACION\ProgEV\PROG\EV3\ndupcopy\paths\entry3",
                //"-o", @"C:\Users\javie\Desktop\1 DAM\PROGRAMACION\ProgEV\PROG\EV3\ndupcopy\paths\exit"

                "-i", @"C:\Users\javgalgas\Desktop\ProgEV\PROG\EV3\ndupcopy\paths\entry1",
                "-i", @"C:\Users\javgalgas\Desktop\ProgEV\PROG\EV3\ndupcopy\paths\entry2",
                "-i", @"C:\Users\javgalgas\Desktop\ProgEV\PROG\EV3\ndupcopy\paths\entry3",
                "-o", @"C:\Users\javgalgas\Desktop\ProgEV\PROG\EV3\ndupcopy\paths\exit"
            };
            DuplicateCleaner.RunProgram(args);
        }
    }
}
