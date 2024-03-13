namespace Basura_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<string> root = new Node<string>("T");
            Node<string> child1 = new Node<string>("A", root);
            Node<string> child2 = new Node<string>("B");
            Node<string> child3 = new Node<string>("C", child1);
            Node<string> child4 = new Node<string>("D", child3);
            Node<string> child5 = new Node<string>("E", child2);
            Node<string> child6 = new Node<string>("F", child1);

            root.AddChild(child2);
            child1.AddChild(root);
            root.SetParent(child2);


            Console.WriteLine(root.ToString());
            Console.WriteLine(child1.ToString());
            Console.WriteLine(child2.ToString());

            Console.WriteLine(root.Level);
            Console.WriteLine(child1.Level);
            Console.WriteLine(child2.Level);
            Console.WriteLine(child3.Level);
            Console.WriteLine(child4.Level);
            Console.WriteLine(child5.Level);

            Console.WriteLine(root.IsLeaf);
            Console.WriteLine(child1.IsLeaf);
            Console.WriteLine(child2.IsLeaf);
            Console.WriteLine(child3.IsLeaf);
            Console.WriteLine(child4.IsLeaf);
            Console.WriteLine(child5.IsLeaf);

            child5.Unlink();
            Console.WriteLine(child5.Level);
            Console.WriteLine(child5.IsLeaf);

            List<Node<string>>? filter = root.Filter(root =>
            {
                return root.GetLevel() == 2;
            });

            //queremos sumar dos listas : AddRange() [buscar]
            //nunca te...(a ver si recuerdo que venia aquí) 
            //switch(exp)
            //{
            //  case: 3
            //      exp=3
            //      break;
            //  case: 5
            //      exp=5
            //      break;
            //  case: 4
            //      exp=4
            //      break;
            //  default:
            //      exp=-1
            //      break;
            //
            //}
            //

            //
            //API (application programming interface) es una pieza de código que permite a diferentes aplicaciones comunicarse entre sí y compartir información y funcionalidades.
            //
            //main()
            //{
            //  ...
            //  Ventana
            //  Ventana
            //  Configuración
            //  while(!exit)
            //  {
            //      message=windows.GetMessage();
            //      message.id
            //  }
            //
            //}


            //try
            //{
            //
            //}
            //catch(Exception ex) [division por cero, out of bounds, null Exception, stack Overflow]cosas que se pueden preveer y controlar [abrir archivo, acceder a un servidor (BBDD, html), parsear strings, abrir sockets... ]cosas que NO se pueden preveer ni modificar
            //{
            //
            //}
            //finally
            //{
            //
            //}

            //throw new Exception("Hola");
            //class MyException : Exception
            //{
            //  ...
            //}

            //try
            //{
            //
            //}
            //catch(MyException ex1)
            //{
            //
            //}
            //catch(OtherException ex2)
            //{
            //
            //}
            //finally
            //{
            //
            //}
        }
    }
}