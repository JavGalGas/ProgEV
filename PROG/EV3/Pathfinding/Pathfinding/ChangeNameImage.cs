using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pathfinding
{
    public class ChangeNameImage
    {
        public static void CopyImageFile(string filePath) // perfilar con la página web guardada en Marcadores
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string extension = Path.GetExtension(filePath).ToLower();

                    // Verifica si el archivo es una imagen
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
                    {
                        string directory = Path.GetDirectoryName(filePath);
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        DateTime creationTime = File.GetCreationTime(filePath);
                        string newFileName = $"{creationTime:yyyy-MM-dd-HH-mm-ss}_{fileName}{extension}";
                        string newFilePath = Path.Combine(directory, newFileName);

                        // Realiza una copia de la imagen
                        File.Copy(filePath, newFilePath);

                        Console.WriteLine($"Se ha creado una copia de la imagen en: {newFilePath}");
                    }
                    else
                    {
                        Console.WriteLine($"El archivo '{filePath}' no es una imagen.");
                    }
                }
                else
                {
                    Console.WriteLine($"El archivo '{filePath}' no existe.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
