namespace DominoJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Participant player1 = new ImpulsiveParticipant("Mondongo");
            Participant player2 = new ConservativeParticipant("Pablo Escobar");
            Participant player3 = new ImpulsiveParticipant("Rosa Melano");
            Participant player4 = new ConservativeParticipant("");
            game.AddParticipant(player1);
            game.AddParticipant(player2);
            game.AddParticipant(player3);
            game.AddParticipant(player4);
            game.SimulateGame();
            Console.WriteLine($"¡Felicidades! El ganador es el jugador {game.Winner!.Name}.");
            Console.ReadKey();
        }
    }
}