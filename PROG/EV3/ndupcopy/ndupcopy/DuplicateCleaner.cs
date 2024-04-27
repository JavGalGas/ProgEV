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
            DirectoryFilter( args, ref exitPath, ref filePaths);            
            if (filePaths.Count > 1)
            {
                RemoveDuplicatesAndCopy(ref filePaths, ref exitPath);
            }
            else if (filePaths.Count == 1)
            {
                Utils.CopyFileFromTo(filePaths[0].File_path, exitPath);
            }
        }
        private static void DirectoryFilter( string[] args, ref string exitPath, ref List<FilePath> filePaths)
        {
            string directorio;
            for (int i = 0; i < args.Length; i += 2)
            {
                try
                {
                    if (args[i] == "-i" || args[i] == "-o")
                        directorio = args[i+1];                   
                    else
                    {
                        throw new Exception($"Argumento {args[i]} no válido.");
                    }
                    if (args[i] == "-o" && exitPath == "")
                        exitPath = args[i + 1];
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
                        Console.WriteLine($"El directorio {directorio} no existe.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"El proceso falló: {e}");
                }
            }
        }

        private static void RemoveDuplicatesAndCopy(ref List<FilePath> filePaths, ref string exitPath)
        {
            for (int i = 0; i < filePaths.Count - 1; i++)
            {
                if (Path.GetDirectoryName(filePaths[i].File_path) == exitPath)
                    continue;
                for (int j = i + 1; j < filePaths.Count; j++)
                {
                    if (filePaths[i].unique && filePaths[j].unique)
                    {
                        IsUnique(filePaths[i], filePaths[j]);
                    }
                }
                if (filePaths[i].unique)
                {
                    Utils.CopyFileFromTo(filePaths[i].File_path, exitPath);
                }     
            }
        }
    }
}
