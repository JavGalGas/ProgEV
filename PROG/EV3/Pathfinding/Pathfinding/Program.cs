using System.Security.Cryptography;
using System.IO;
namespace Pathfinding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> entryRoutes = args.Take(args.Length-1).ToList();
            string exitRoute = args[args.Length-1];            

            for (int i = 0; i< entryRoutes.Count; i++)
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

        public static void RemoveDuplicates(ref string[] args)//modificar
        {
            for (int i = 1;i < args.Length -1;i+=2) 
            {
                string directorio = args[i]; // Cambia esto a la ruta del directorio que quieres revisar

                try
                {
                    if (Directory.Exists(directorio))
                    {
                        string[] archivos = Directory.GetFiles(directorio);

                        Console.WriteLine("Archivos en el directorio {0}:", directorio);
                        foreach (string archivo in archivos)
                        {
                            Console.WriteLine(Path.GetFileName(archivo));
                        }
                    }
                    else
                    {
                        Console.WriteLine("El directorio {0} no existe.", directorio);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("El proceso falló: {0}", e.ToString());
                }
            }
        }

        public static void CopyFileFromTo(string origin, string destiny)
        {
            try
            {
                File.Copy(origin, destiny, true);
                Console.WriteLine("Archivo copiado exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
