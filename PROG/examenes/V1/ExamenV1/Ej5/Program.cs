namespace Ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                Player player1 = new NormalPlayer("A");
                Player player2 = new QuickPlayer("B", Utils.GetRandomBetween(1,3));
                Player player3 = new CheaterPlayer("C");
                Player player4 = new NormalPlayer("D");
                game.AddPlayer(player1);
                game.AddPlayer(player2);
                game.AddPlayer(player3);
                game.AddPlayer(player4);

                Player winner = game.Simulate();
                Console.WriteLine("El ganador es : " + winner.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}