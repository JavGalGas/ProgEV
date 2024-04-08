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
        public static void RemoveDuplicates(ref string[] args)//modificar
        {
            for (int i = 1; i < args.Length - 1; i += 2)
            {
                string directorio = args[i];

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

        public static bool FileComparison(string file1, string file2)
        {
            try
            {
                if (File.Exists(file1) && File.Exists(file2))
                {
                    const int bufferSize = 2048; // Tamaño del bloque
                    byte[] buffer1 = new byte[bufferSize];
                    byte[] buffer2 = new byte[bufferSize];

                    using (FileStream fs1 = new FileStream(file1, FileMode.Open))
                    using (FileStream fs2 = new FileStream(file2, FileMode.Open))
                    {


                        //  H   A   S   H   //



                        if (fs1.Length != fs2.Length)
                            return false; // Los archivos son diferentes en tamaño
                        int offset = 0;
                        int buffer1Length, buffer2Length;

                        while ((buffer1Length = fs1.Read(buffer1, offset, bufferSize)) > 0 && (buffer2Length = fs2.Read(buffer1, 0, bufferSize)) > 0)
                        {//manejar en una sola función
                            if (buffer1Length <= buffer2Length)
                            {
                                int aux = 0;
                                while (buffer2Length > aux)
                                {
                                    for (int i = 0; i < buffer1Length; i++)
                                    {
                                        if (buffer1[i + aux] != buffer2[i+aux])
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
                    }

                    return true; // Los archivos son iguales
                }
                else
                {
                    Console.WriteLine("Las rutas no existen.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        //public static void BufferComparison(int b1, int b2)
        //{
        //    if (b1 < b2)
        //    {
        //        for (int i = 0; i < b1; i++)
        //        {
        //            if (buffer1[i] != buffer2[i])
        //                return false; // Los archivos son diferentes
        //        }
        //        int aux = 0;
        //        while (b1 < b2)
        //        {
        //            for (int i = 0; i < b1; i++)
        //            {
        //                if (buffer1[i + aux] != buffer2[i + aux])
        //                    return false; // Los archivos son diferentes
        //            }
        //            aux += b1;
        //            b1 = fs1.Read(buffer1, aux, b2 - aux);
        //        }
        //    }
        //}

    }
}
