using System.Security.Cryptography;
using System.IO;
namespace Pathfinding
{
    internal class Program
    {
        static void Main(string[] args)
        {//pasar a hacer nuevos arrays de string en args

            //consigue la ruta absoluta del programa en ejecución (ddl)
            string programAbsolutePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //ruta relativa del directorio Pathfinding a partir de programAbsolutePath
            string relativePath = @"..\..\..\..\..\";

            List<string> entryRoutes = new List<string>
            {
                @"entry1\",
                @"entry2\"
            };
            string exitRoute = @"exit\";            

            args = new string[entryRoutes.Count*2 + 2];

            for (int i = 0; i < args.Length - 2; i += 2)
            {
                args[i] = "-i";
                args[i + 1] = GetAbsolutePathFromRelative(programAbsolutePath, relativePath + entryRoutes[i / 2]); 
            }
            args[args.Length - 2] = "-o";
            args[args.Length - 1] = GetAbsolutePathFromRelative(programAbsolutePath, relativePath + exitRoute);

            for (int i = 0; i < args.Length; i += 2)
            {
                Console.WriteLine(args[i] + " " + args[i + 1]);
            }

            //Para poder cambiar el nombre de la imagen copiada

            //string filePath = @"C:\Users\javie\Desktop\1 DAM\BD\Diagrama SUPERTIENDA (1).png"; // Reemplaza con la ruta de tu archivo

            //ChangeNameImage.CopyImageFile(filePath);
        }

        public static string GetAbsolutePathFromRelative(string absolutePath, string relativePath)
        {
            try
            {
                // Combina la ruta absoluta con la ruta relativa
                string combinedPath = Path.Combine(absolutePath, relativePath);

                // Obtiene la ruta absoluta final normalizando la ruta combinada
                string finalAbsolutePath = Path.GetFullPath(combinedPath);

                //Console.WriteLine($"La ruta absoluta final es: {finalAbsolutePath}");
                return finalAbsolutePath;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
