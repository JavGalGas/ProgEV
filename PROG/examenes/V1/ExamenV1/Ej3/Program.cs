namespace Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //User user1 = new User(-1, 40);
                //User user2 = new User(1, -40);
                //User user3 = new User(1, 240);
                User user = new User(5, 40);

                Console.WriteLine(user.Name);
                Console.WriteLine(user.Age);
                Console.WriteLine(user.Code);
                Console.WriteLine(user.KeyCount);
                Console.WriteLine("");
                //user.SetName(string.Empty);
                //user.SetName(null);
                user.SetName("Juan");

                Console.WriteLine(user.Name);
                Console.WriteLine(user.Code);
                Console.WriteLine("");

                //user.ContainsKey(string.Empty);
                string key1 = "axu1";
                Console.WriteLine(user.ContainsKey(key1));

                //user.AddKey(string.Empty);
                user.AddKey(key1);
                Console.WriteLine(user.IndexOf(key1));
                Console.WriteLine(user.ContainsKey(key1));
                Console.WriteLine("");

                user.AddKey("a");
                user.AddKey("a");
                user.AddKey("a");
                user.AddKey("a");
                //user.AddKey("a");

                user.ClearKeys();
                Console.WriteLine(user.ContainsKey(key1));
                Console.WriteLine("");

                user.AddKey("a");
                user.AddKey("a");
                user.AddKey("a");
                user.AddKey("a");
                Console.WriteLine(user.ContainsKey("a"));
                user.RemoveKeys(key =>
                {
                    if (key == "a")
                        return 1;
                    else
                        return -1;
                });
                Console.WriteLine(user.ContainsKey("a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}