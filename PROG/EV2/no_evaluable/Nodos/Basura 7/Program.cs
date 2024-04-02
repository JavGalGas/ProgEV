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
            Console.WriteLine();
            Console.WriteLine(root.Level);
            Console.WriteLine(child1.Level);
            Console.WriteLine(child2.Level);
            Console.WriteLine(child3.Level);
            Console.WriteLine(child4.Level);
            Console.WriteLine(child5.Level);
            Console.WriteLine(child6.Level);
            Console.WriteLine();
            Console.WriteLine(root.IsLeaf);
            Console.WriteLine(child1.IsLeaf);
            Console.WriteLine(child2.IsLeaf);
            Console.WriteLine(child3.IsLeaf);
            Console.WriteLine(child4.IsLeaf);
            Console.WriteLine(child5.IsLeaf);
            Console.WriteLine(child6.IsLeaf);
            Console.WriteLine();
            child5.Unlink();
            Console.WriteLine(child5.Level);
            Console.WriteLine(child5.IsLeaf);
            Console.WriteLine(child1.GetParent()!.ToString());
            List<Node<string>>? filter = root.Filter(root =>
            {
                return root.GetParent() != null;
            });
            if (filter != null)
                foreach (Node<string>? node in filter)
                    Console.WriteLine(node.ToString());


        }
    }
}