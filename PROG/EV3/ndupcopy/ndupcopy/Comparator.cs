using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public static partial class DuplicateCleaner
    {
        private static void IsUnique(FilePath file1, FilePath file2) //modificar
        {
            try
            {
                string filePath1 = file1.File_path;
                string filePath2 = file2.File_path;
                if (File.Exists(filePath1) && File.Exists(filePath2))
                {
                    using (FileStream fs1 = new FileStream(filePath1, FileMode.Open))
                    using (FileStream fs2 = new FileStream(filePath2, FileMode.Open))
                    {
                        if (file1.IntHash == file2.IntHash)
                        {
                            if (fs1.Length == fs2.Length)
                            {
                                file2.unique = false;
                            }
                        }
                        else if (file1.Base64Hash == file2.Base64Hash)
                        {
                            if (fs1.Length == fs2.Length)
                            {
                                file2.unique = false;
                            }
                        }
                        else if (BufferComparison(fs1, fs2))
                        {
                            file2.unique = false;
                        }
                    }        
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
        }

        private static bool BufferComparison(FileStream fs1, FileStream fs2)
        {
            const int bufferSize = 2048; // Tamaño del bloque
            byte[] buffer1 = new byte[bufferSize];
            byte[] buffer2 = new byte[bufferSize];
            //int offset = 0;
            int buffer1Length, buffer2Length;
            try
            {
                while ((buffer1Length = FillBuffer(fs1, buffer1)/*fs1.Read(buffer1, 0, bufferSize)*/) > 0 && (buffer2Length = FillBuffer(fs2, buffer2)/*fs2.Read(buffer1, 0, bufferSize)*/) > 0)
                {
                    //if (buffer1Length <= buffer2Length)
                    //{
                    //    int aux = 0;
                    //    while (buffer2Length > aux)
                    //    {
                    //        for (int i = 0; i < buffer1Length; i++)
                    //        {
                    //            if (buffer1[i + aux] != buffer2[i + aux])
                    //                return false; // Los archivos son diferentes
                    //        }
                    //        aux += buffer1Length;
                    //        buffer1Length = fs1.Read(buffer1, aux, buffer2Length - aux);
                    //    }
                    //}
                    //if (buffer1Length > buffer2Length)
                    //{
                    //    int aux = 0;
                    //    while (buffer1Length > aux)
                    //    {
                    //        for (int i = 0; i < buffer2Length; i++)
                    //        {
                    //            if (buffer1[i + aux] != buffer2[i + aux])
                    //                return false; // Los archivos son diferentes
                    //        }
                    //        aux += buffer2Length;
                    //        buffer2Length = fs2.Read(buffer2, aux, buffer1Length - aux);
                    //    }
                    //}
                    //offset += bufferSize;

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

        //public static bool BufferComparison(FileStream fs1, FileStream fs2, byte[] buffer1, byte[] buffer2, int bufferSize)
        //{
        //    int bytesRead1, bytesRead2;

        //    do
        //    {
        //        bytesRead1 = fs1.Read(buffer1, 0, bufferSize);
        //        bytesRead2 = fs2.Read(buffer2, 0, bufferSize);

        //        if (bytesRead1 != bytesRead2)
        //            return false; // Los archivos son de longitudes diferentes

        //        for (int i = 0; i < bytesRead1; i++)
        //        {
        //            if (buffer1[i] != buffer2[i])
        //                return false; // Los archivos son diferentes
        //        }
        //    } while (bytesRead1 > 0 && bytesRead2 > 0);

        //    // Si no se encontraron diferencias y ambos archivos se leyeron completamente, son iguales
        //    return true;
        //}
    }
}
