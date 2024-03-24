using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TPVLib
{
    internal class UI
    {
        //public static int ReadOption()
        //{
        //    string input = Console.ReadLine();
        //    if (input == null)
        //        return -1;
        //    if (int.TryParse(input, out int option))
        //        return option;
        //    else
        //        Console.WriteLine("Not a valid entry.");
        //    return 0;
        //}

        public static string? ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------------- ");
            Console.WriteLine("|  Elige una operación a realizar: |");
            Console.WriteLine("|  1-Buscar Producto               |");
            Console.WriteLine("|  2-Buscar Productos              |");
            Console.WriteLine("|  3-Añadir Producto               |");
            Console.WriteLine("|  4-Eliminar Producto             |");
            Console.WriteLine("|  5-Actualizar Producto           |");
            Console.WriteLine("|  6-Cerrar Programa               |");
            Console.WriteLine(" ---------------------------------- ");
            string? option = Console.ReadLine();
            return option;
        }

        // Javi: La UI no debería tomar decisiones, hacer bucles, sólo mostrar y leer datos del usuario


        public static void CaseGetProduct(ITPV tpv)
        {
            Console.Write("Seleccione el id: ");
            long id = Convert.ToInt64(Console.ReadLine());
            Product? product= tpv.GetProductWithId(id);
            if (product == null)
                return;
            Console.WriteLine(" -------------------------------------------------------------- ");
            Console.WriteLine("| ID   Name        Description         Price    Stock    IVA   |");
            ShowProduct(product, tpv);
            Console.WriteLine("|                                                              |");
            Console.WriteLine(" -------------------------------------------------------------- ");
            Console.ReadLine();
        }
        public static void CaseGetProducts(ITPV tpv)
        {
            Console.Write("Seleccione el id de inicio: ");
            int offset = Convert.ToInt32(Console.ReadLine());
            Console.Write("Seleccione el id final: ");
            int limit = Convert.ToInt32(Console.ReadLine());
            List<Product> products= tpv.GetProducts(offset, limit);
            if (products == null)
                return;
            int count = products.Count;
            Console.WriteLine(" -------------------------------------------------------------- ");
            Console.WriteLine("| ID   Name        Description         Price    Stock    IVA   |");
            foreach (Product product in products)
                ShowProduct(product, tpv);
            Console.WriteLine("|                                                              |");
            Console.WriteLine(" -------------------------------------------------------------- ");
            Console.ReadLine();
        }
        // Javi: Nombre horroroso. Por favor, coméntame esto en clase
        public static void CaseAddProduct(ITPV tpv)
        {
            Console.Write("Diga el id del producto: ");
            long id = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Diga el nombre del producto: ");
            string? name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ponga una descripción al producto: ");
            string? description = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ponga un precio al producto: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Diga cuánto es el stock del producto: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Diga cuánto es el IVA: ");
            double IVA = Convert.ToDouble(Console.ReadLine());
            Product product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Stock = stock,
                IVA = IVA
            };
            Console.WriteLine("Producto añadido correctamente. El id es : " + tpv.AddProduct(product));
            Console.ReadLine();
        }

        public static void CaseUpdateProduct(ITPV tpv)//modificar
        {
            Console.Write("Seleccione el id: ");
            long id = Convert.ToInt64(Console.ReadLine());
            Console.Write("Diga el nombre del producto: ");
            string? name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ponga una descripción al producto: ");
            string? description = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ponga un precio al producto: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Diga cuánto es el stock del producto: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Diga cuánto es el IVA: ");
            double IVA = Convert.ToDouble(Console.ReadLine());
            Product product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Stock = stock,
                IVA = IVA
            };
            tpv.UpdateProductWithId(id, product);
            Console.WriteLine("Producto actualizado.");
            Console.ReadLine();
        }

        public static void CaseRemoveProduct(ITPV tpv)
        {
            Console.Write("Seleccione el id: ");
            long id = Convert.ToInt64(Console.ReadLine());
            Product? p = tpv.GetProductWithId(id);
            if (p == null)
            {
                return;
            }
            Console.WriteLine("Producto eliminado");
            Console.ReadLine();
        }

        public static void CaseExit(ITPV tpv, out bool runProgram)
        {
            Console.WriteLine("Hasta luego.");
            Console.ReadLine();
            Console.WriteLine("Cerrando programa...");
            runProgram = false;
        }

        private static void ShowProduct(Product product, ITPV tpv)
        {
            if(product==null || tpv==null)
                return;
            int spaces;
            Console.Write("| " + product.Id);
            spaces = 5 - product.Id.ToString().Length;
            PrintSpace(spaces);
            Console.Write(product.Name);
            if(product.Name == null)
                spaces = 12;
            else
            {
                spaces = 12 - product.Name.Length;
            }
            PrintSpace(spaces);
            Console.Write(product.Description);
            if (product.Description == null)
                spaces = 20;
            else
            {
                spaces = 20 - product.Description.Length;
            }
            PrintSpace(spaces);
            Console.Write(product.Price.ToString());
            spaces = 9 - product.Price.ToString().Length;
            PrintSpace(spaces);
            Console.Write(product.Stock.ToString());
            spaces = 9 - product.Stock.ToString().Length;
            PrintSpace(spaces);
            Console.Write(product.IVA.ToString());
            spaces = 6 - product.IVA.ToString().Length;
            PrintSpace(spaces);
            Console.WriteLine("|");
        }

        private static void PrintSpace(int count)
        {
            for (int i = 0;i < count;i++)
                Console.Write(" ");
        }

        //public static long StringToLong(string? value)
        //{
        //    if (value == null)
        //        return long.MinValue;

        //    long result = 0;
        //    int count = value.Length;
        //    for (int i = 0; i < count; i++)
        //    {
        //        long n = (long)(value[i] * Math.Pow(10, count - i));
        //        result += n;
        //    }
        //    return result;
        //}

        //public static int StringToInt(string? value)
        //{
        //    if (value == null)
        //        return int.MinValue;

        //    int result = 0;
        //    int count = value.Length;

        //    for (int i = 0; i < count; i++)
        //    {
        //        int n = (int)(value[i] * Math.Pow(10, count - i));
        //        result += n;
        //    }
        //    return result;
        //}
    }
}
