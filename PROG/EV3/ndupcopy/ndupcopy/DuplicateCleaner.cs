using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndupcopy
{
    public static partial class DuplicateCleaner
    {
        public static void RunProgram(string[] args)
        {
            List<FilePath> filePaths = new List<FilePath>();
            string exitPath = "";            
            DirectoryFilter( args, exitPath, filePaths);
            if (filePaths.Count >= 1)
            {
                CopyOnlyUniques(filePaths, exitPath);
            }
        }
        private static void DirectoryFilter( string[] args, string exitPath, List<FilePath> filePaths)
        {
            string directorio;
            for (int i = 0; i < args.Length; i += 2)
            {
                try
                {
                    if (args[i] == "-i" || args[i] == "-o")
                        directorio = Path.GetFullPath(args[i+1]);                   
                    else
                    {
                        throw new Exception($"Argumento {args[i]} no válido.");
                    }
                    if (args[i] == "-o" && exitPath == "")
                        exitPath = args[i + 1];
                    if (Directory.Exists(directorio))
                    {
                        Utils.Directories.Add(directorio);
                        RecursiveDirectoryReading(directorio, ref filePaths);
                    }
                    else
                    {
                        Console.WriteLine($"El directorio {directorio} no existe.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"El proceso falló: {e}");
                }
            }
        }

        private static void RecursiveDirectoryReading(string directorio, ref List<FilePath> filePaths)
        {
            try
            {
                string[] archivos = Directory.GetFiles(directorio);
                foreach (string archivo in archivos)
                {
                    FilePath f = new FilePath(archivo);
                    filePaths.Add(f);
                }

                string[] subdirectorios = Directory.GetDirectories(directorio);
                foreach (string subdirectorio in subdirectorios)
                    RecursiveDirectoryReading(subdirectorio, ref filePaths);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CopyOnlyUniques(List<FilePath> filePaths, string exitPath)
        {
            FilePath? path1;
            FilePath? path2;
            for (int i = 0; i < filePaths.Count; i++)
            {
                if (Path.GetDirectoryName(filePaths[i].File_path) == exitPath)
                    continue;
                path1 = filePaths[i];
                if (path1.unique)
                {
                    for (int j = i + 1; j < filePaths.Count; j++)
                    {
                        path2 = filePaths[j];
                        if (path2.unique)
                        {
                            CompareFiles(path1, path2);
                        }
                    }

                    Utils.CopyFileFromTo(path1.File_path, exitPath);
                }
                  
            }
        }
    }
}
