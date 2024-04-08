namespace ndupcopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> entryRoutes = args.Take(args.Length - 1).ToList();
            string exitRoute = args[args.Length - 1];

            for (int i = 0; i < entryRoutes.Count; i++)
            {
                entryRoutes[i] = Path.GetFullPath(entryRoutes[i]);
            }

            foreach (string route in entryRoutes)
            {
                Console.WriteLine(route);
            }

            //RemoveDuplicates(ref args);


            //Para poder cambiar el nombre de la imagen copiada

            //string filePath = @"C:\Users\javie\Desktop\1 DAM\BD\Diagrama SUPERTIENDA (1).png"; // Reemplaza con la ruta de tu archivo

            //ChangeNameImage.CopyImageFile(filePath);

        }
    }
}
