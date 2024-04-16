using System.Text.Json;

namespace ndupcopy
{
    public class AppParams
    {
        public string[]? input_folders { get; set; } //"imput_folders" : ["f1", "f2", "f3"],
        //public string[]? options {get; set; } //"options" : [" ", " ", " ", ],

        public string? output_folder { get; set; } // "output_folder" : "out1",
    }

    internal class Program
    {
        //byte[] --> string
        //BitConverter(hash);
        //byte[] content;

        //base 64

        static void Main(string[] args)
        {
            //comprobar carpeta de salida 

            //Formas de meter datos:
                //strings
                //Environment
                //.txt

            //string rutaDelArchivoConLosPath = args[0];
            //try
            //{
            //    string jsonContent = File.ReadAllText(rutaDelArchivoConLosPath);
            //    var obj = JsonSerializer.Deserialize<AppParams>(jsonContent);

            //    //var lines = File.ReadAllLines(rutaDelArchivoConLosPath);
            //    //foreach (var path in lines)
            //    //{
            //    //    Console.WriteLine(Path.GetFullPath(path));
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Algo ha ido mal " + ex.Message);
            //}

            //Utilizar rutas abssolutas y relativas

            //Dos maneras de verlo:
            //Mantener los directorios de origen en el directorio de salida
            //Unificar todos los subdirectorios

            //1- Meter en una lista todos los elementos
            //2- Eliminar los duplicados
            //3- Copiar los elementos

            //personal: buscar ofuscador de código

            //SI: docker y kubernetes

            List<string> entryRoutes = args.Take(args.Length - 1).ToList();
            string exitRoute = args[args.Length - 1];

            for (int i = 0; i < entryRoutes.Count; i++)
            {
                entryRoutes[i] = Path.GetFullPath(entryRoutes[i]);
            }

            foreach (string route in entryRoutes)
            {
                Console.WriteLine(route);
            }

            //RemoveDuplicates(args);


            //Para poder cambiar el nombre de la imagen copiada

            //string filePath = @"C:\Users\javie\Desktop\1 DAM\BD\Diagrama SUPERTIENDA (1).png"; // Reemplaza con la ruta de tu archivo

            //ChangeNameImage.CopyImageFile(filePath);

        }
    }
}
