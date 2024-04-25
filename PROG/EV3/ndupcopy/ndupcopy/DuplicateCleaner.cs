using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public static class DuplicateCleaner
    {
        public static void CheckDuplicates(string[] args)//modificar
        {
            List<FilePath> filePaths = new List<FilePath>();
            string exitPath = args[args.Length - 1];

            for (int i = 1; i < args.Length - 1; i += 2)
            {
                string directorio = args[i];

                try
                {
                    if (Directory.Exists(directorio))
                    {
                        string[] archivos = Directory.GetFiles(directorio);
                        foreach (string archivo in archivos)
                        {
                            FilePath f = new FilePath(archivo);
                            filePaths.Add(f);
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
            for (int i = 0; i < filePaths.Count-1; i++)
            {
                for (int j = i+1; j < filePaths.Count; j++)
                {
                    if (!filePaths[i].IsDuplicate && !filePaths[j].IsDuplicate!)
                    {
                        FileComparison(filePaths[i], filePaths[j]);
                    }
                }
            }
            foreach (FilePath f in filePaths)
            {
                if(!f.IsDuplicate!)
                    Utils.CopyFileFromTo(f.Path, exitPath);
            }
        }

        public static void FileComparison(FilePath file1, FilePath file2)
        {
            try
            {
                string filePath1 = file1.Path;
                string filePath2 = file2.Path;
                if (File.Exists(filePath1) && File.Exists(filePath2))
                {
                    const int bufferSize = 2048; // Tamaño del bloque
                    byte[] buffer1 = new byte[bufferSize];
                    byte[] buffer2 = new byte[bufferSize];

                    using (FileStream fs1 = new FileStream(filePath1, FileMode.Open))
                    using (FileStream fs2 = new FileStream(filePath2, FileMode.Open))
                    {                     
                        if (file1.hash != file2.hash)
                        {
                            file2.IsDuplicate = true;
                        }
                        else if (file1.hash2 != file2.hash2)
                        {
                            file2.IsDuplicate = true;
                        }
                        else if (fs1.Length != fs2.Length)
                        {
                            file2.IsDuplicate = true;
                        }
                        else if (BufferComparison(fs1, fs2, buffer1, buffer2, bufferSize))
                        {
                            file2.IsDuplicate = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Las rutas no existen.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool BufferComparison(FileStream fs1, FileStream fs2, byte[] buffer1, byte[] buffer2, int bufferSize)
        {
            int offset = 0;
            int buffer1Length, buffer2Length;

            while ((buffer1Length = fs1.Read(buffer1, offset, bufferSize)) > 0 && (buffer2Length = fs2.Read(buffer1, 0, bufferSize)) > 0)
            {
                if (buffer1Length <= buffer2Length)
                {
                    int aux = 0;
                    while (buffer2Length > aux)
                    {
                        for (int i = 0; i < buffer1Length; i++)
                        {
                            if (buffer1[i + aux] != buffer2[i + aux])
                                return false; // Los archivos son diferentes
                        }
                        aux += buffer1Length;
                        buffer1Length = fs1.Read(buffer1, aux, buffer2Length - aux);
                    }
                }
                if (buffer1Length > buffer2Length)
                {
                    int aux = 0;
                    while (buffer1Length > aux)
                    {
                        for (int i = 0; i < buffer2Length; i++)
                        {
                            if (buffer1[i + aux] != buffer2[i + aux])
                                return false; // Los archivos son diferentes
                        }
                        aux += buffer2Length;
                        buffer2Length = fs2.Read(buffer2, aux, buffer1Length - aux);
                    }
                }
                offset += bufferSize;
            }
            return true;
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
