using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public static class Utils
    {
        public static List<string> Directories = new List<string>();

        public static void CopyTo(string origin, string destination)
        {
            try
            {
                // Opens the origin file for reading
                using (FileStream fileStreamSource = new FileStream(origin, FileMode.Open, FileAccess.Read))
                {
                    // Opens the origin file for writing, overwriting it if it exists
                    using (FileStream fileStreamDestiny = new FileStream(destination, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[4096];
                        int RemainingBytesForRead;

                        while ((RemainingBytesForRead = fileStreamSource.Read(buffer, 0, buffer.Length)) > 0)                                                                
                        {
                            fileStreamDestiny.Write(buffer, 0, RemainingBytesForRead);
                        }
                    }
                }
                Console.WriteLine("Archivo copiado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
            }
        }
        public static void CopyFileFromTo(string origin, string destiny) // comprobar los directorios que se le pasa por args
        {
            try
            {
                if (File.Exists(origin))
                {
                    string extension = Path.GetExtension(origin).ToLower();
                    //string fullPath = Path.GetFullPath(origin);

                    //crea la estructura de carpetas
                    CreateDirectoryStructure(origin, ref destiny);

                    // Verifica si el archivo es una imagen o un video
                    if (CheckExtension(extension))
                    {
                        //string? directory = Path.GetDirectoryName(origin);
                        string fileName = Path.GetFileNameWithoutExtension(origin);
                        DateTime creationTime = File.GetCreationTime(origin);
                        string newFileName = $"{creationTime:yyyy-MM-dd-HH-mm-ss}_{fileName}{extension}";
                        string newFilePath = Path.Combine(destiny, newFileName);
                        // Realiza una copia de la imagen
                        CopyTo(origin, newFilePath);
                        Console.WriteLine($"Se ha creado una copia de la imagen o vídeo en: {newFilePath}");
                    }
                    else
                    {
                        //string? directory = Path.GetDirectoryName(origin);
                        string fileName = Path.GetFileName(origin);
                        string newFilePath = Path.Combine(destiny, fileName);
                        // Realiza una copia de la imagen
                        CopyTo(origin, newFilePath);

                        Console.WriteLine($"Se ha creado una copia del archivo en: {newFilePath}");
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

        private static bool CheckExtension(string extension)
        {
            List<string> extensions = new List<string>()
            {
                //img
                ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".tiff", ".heif", ".svg",

                //vídeo
                ".mp3", ".mp4", ".mov", ".wmv", ".wav", ".avi", ".mkv", ".flv", ".mpeg", ".3gp"
            };
            return extensions.Contains(extension);
        }

        private static void CreateDirectoryStructure(string origin, ref string destiny)
        {
            try
            {
                foreach (var directory in Directories)
                {
                    if (BelongsToDirectory(origin, directory))
                    {
                        string directoryStructure = Path.GetDirectoryName(GetRelativePath(origin, directory))!;
                        CreateFolderStructureFromRelative(destiny, directoryStructure);
                        destiny = Path.Combine(destiny, directoryStructure);
                        break;
                    }
                }
               
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetRelativePath(string rutaAbsoluta, string directorioBase)
        {
            var uriFile = new Uri(rutaAbsoluta);
            var uriDirectory = new Uri(directorioBase);
            var relativePath = Uri.UnescapeDataString(uriDirectory.MakeRelativeUri(uriFile).ToString().Replace('/', Path.DirectorySeparatorChar));
            return relativePath;
        }

        private static bool BelongsToDirectory(string absolutePath, string baseDirectory)
        {
            var relativePath = GetRelativePath(absolutePath, baseDirectory);
            return !relativePath.StartsWith("..");
        }

        private static void CreateFolderStructureFromRelative(string baseDirectory, string folderStructure)
        {
            string[] folders = folderStructure.Split(Path.DirectorySeparatorChar);
            string currentPath = baseDirectory;

            foreach (string folder in folders)
            {
                currentPath = Path.Combine(currentPath, folder);
                Directory.CreateDirectory(currentPath);
            }
        }
    }

    
}
