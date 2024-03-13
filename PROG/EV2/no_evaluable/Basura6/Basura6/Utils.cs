using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Basura6
{
    public delegate int ComparatorDelegate<T>(T n1, T n2);
    public class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
        public static void Sort<T>(T[] array, ComparatorDelegate<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer(array[i], array[j]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        //struct Student
        //{
        //    int age;
        //}
        //class Clase
        //{
        //    Student debug;
        //    int age;
        //}
        //nuevos conceptos: struct, heap
        //diferencia entre struct y class: al crear una nuevo objeto de una clase, en la RAM se crea un número de referencia a ESA clase
        //al crear un nuevo objeto de struct, en la RAM se crea un número que alberga los datos.
        //struct no soporta herencias, class sí
        //struct sirve, por ejemplo, a la hora de copiar y enviar de vuelta datos de la GPU.
        //struct se comporta como un int
        //struct crea de una variable temporal, o que esta dentro de un objeto.




        //clase inmutable y que no herede de nadie
        //class,-- struct,-- record
        //se comporta como un readonly
        //record Student(string Name, int Age)
        //{
        //    int Curso { get; set; }

        //}
        //Student s = new Student(..., ...);
        //s.Name;

        //void YerkoQuiereAEnrique()
        //{
        //    int j;
        //    for(int i= 0; i <= 0; i--)
        //    {
        //        Beso b = new BesoEnLaBoca(); --> BesoEnLaBoca no da error si hereda de Beso (es class al heredar)
        //              EN ACABAR el proceso de Beso, b apuntará a null, y en teoría se destruye (no lo hace)
        //              runtime de C# (este es el lugar donde se 
        //  runtime pide un hueco, el sistema lo busca y se lo devuelve, y por último el runtime te devuelve el espacio
        //      App --> RT C# --> SO ¬
        //       ^      |  ^         |
        //       |______|  |_________|
        //
        //          En vez de borrarse el objeto, lo mete en una lista (pool) de objetos "muertos" (Garbage Collector)
        //          
        //    }
        //}
        //
        //s= new Student();
        //s1 = s;
        //.
        //.
        //.
        //s=null;
        //
        //class Node<T>
        //{
        //     private T Content/Item;
        //     private List<Node<T>> _children;
        //     private Node<T>? _parent; (root tiene como _parent null)
        //
        //
        //
        //     Node<T>? Parent{ get; Set(hacer función); }
        //     bool IsRoot{ get; }
        //     bool IsLeaf{ get; }
        //     int ChildCount{ get; }
        //     int Level { get; }
        //     
        //     int GetLevel()
        //     {
        //          return (_parent == null) ? return 0 : return _parent.GetLevel() + 1;
        //
        //          if(_parent == null)
        //              return 0;
        //          return _parent.GetLevel() + 1;
        //          
        //          (más eficiente con while)
        //          while()
        //          {
        //          
        //
        //
        //
        //
        //
        //
        //
        //
        //          }
        //     }
        //
        //     Node<T> GetRoot ()
        //     {
        //          return (_parent == null) ? this : _parent.GetRoot();
        //  
        //
        //          if(_parent == null)
        //              return this;
        //          
        //          return _parent.GetRoot();
        //
        //     }
        //
        //     void Unlink()        /(tambien se puede llamar Detach())
        //     {
        //          _parent.Remove(this); (Remove debe ser private)
        //
        //          _parent = null;
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //     }
        //
        //      void AddChild(Node<T> child)
        //      {
        //
        //
        //
        //
        //
        //
        //      }
        //
        //}

    }
}
