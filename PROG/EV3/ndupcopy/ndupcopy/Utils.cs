using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public class Utils
    {
        public static void CopyFileFromTo(string origin, string destiny)
        {
            try
            {
                File.Copy(origin, destiny, true);
                Console.WriteLine($"Se ha creado una copia del archivo en: {destiny}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CopyImageFromTo(string origin, string destiny) // perfilar con la página web guardada en Marcadores
        {
            try
            {
                if (File.Exists(origin))
                {
                    string extension = Path.GetExtension(origin).ToLower();

                    // Verifica si el archivo es una imagen o un video
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
                    {
                        string fileName = Path.GetFileNameWithoutExtension(origin);
                        DateTime creationTime = File.GetCreationTime(origin);
                        string newFileName = $"{creationTime:yyyy-MM-dd-HH-mm-ss}_{fileName}{extension}";

                        // Realiza una copia de la imagen
                        File.Copy(origin, destiny);

                        Console.WriteLine($"Se ha creado una copia de la imagen en: {destiny}");
                    }
                    else
                    {
                        Console.WriteLine($"El archivo '{origin}' no es una imagen.");
                    }
                }
                else
                {
                    Console.WriteLine($"El archivo '{origin}' no existe.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
