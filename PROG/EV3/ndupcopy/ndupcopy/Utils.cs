using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public class Utils
    {
        public static void CopyFileFromTo(string origin, string destiny) // perfilar con la página web guardada en Marcadores
        {
            try
            {
                if (File.Exists(origin))
                {
                    string extension = Path.GetExtension(origin).ToLower();

                    // Verifica si el archivo es una imagen o un video
                    if (CheckExtension(extension))
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
                        File.Copy(origin, destiny);
                        Console.WriteLine($"Se ha creado una copia de la imagen en: {destiny}");
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
        public static bool CheckExtension(string extension)
        {
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")//img
            { 
                return true; 
            }
            return (extension == ".mp3" || extension == ".mp4" || extension == ".mov" || extension == ".wmv" || extension == ".wav" || extension == ".avi");//video
        }
    }

    
}
