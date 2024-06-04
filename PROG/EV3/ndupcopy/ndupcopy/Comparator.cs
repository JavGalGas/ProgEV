using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ndupcopy
{
    public static partial class DuplicateCleaner
    {
        private static void CompareFiles(FilePath file1, FilePath file2) //modificar
        {
           if(AreEquals(file1, file2))
                file2.unique = false;
        }

        private static bool AreEquals(FilePath file1, FilePath file2)
        {
            try
            {
                string filePath1 = file1.File_path;
                string filePath2 = file2.File_path;

                if (File.Exists(filePath1) && File.Exists(filePath2))
                {
                    if (file1.Base64Hash != file2.Base64Hash)
                        return false;

                    using (FileStream fs1 = new FileStream(filePath1, FileMode.Open))
                    using (FileStream fs2 = new FileStream(filePath2, FileMode.Open))
                    {
                        if (fs1.Length != fs2.Length)
                            return false;
                        if (!BufferComparison(fs1, fs2))
                            return false;
                    }

                    return true;
                }
                else
                {
                    if (File.Exists(filePath1))
                    {
                        if (File.Exists(filePath2))
                            Console.WriteLine($"Las rutas {filePath1} y {filePath2} no existen.");
                        else
                            Console.WriteLine($"La ruta {filePath2} no existe.");
                    }
                    else
                        Console.WriteLine($"La ruta {filePath1} no existe.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        private static bool BufferComparison(FileStream fs1, FileStream fs2)//modificar
        {
            const int bufferSize = 2048; // Tamaño del bloque
            byte[] buffer1 = new byte[bufferSize];
            byte[] buffer2 = new byte[bufferSize];
            int buffer1Length, buffer2Length;

            try
            {
                while ((buffer1Length = FillBuffer(fs1, buffer1)) > 0 && (buffer2Length = FillBuffer(fs2, buffer2)) > 0)
                {
                    if (buffer1Length != buffer2Length)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static int FillBuffer(FileStream fs, byte[] buffer)
        {
            int totalBytesRead = 0;
            int bytesRead;

            while (totalBytesRead < buffer.Length && (bytesRead = fs.Read(buffer, totalBytesRead, buffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}
