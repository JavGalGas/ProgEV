namespace DominoJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Participant player1 = new ImpulsiveParticipant("Juan");
            Participant player2 = new ConservativeParticipant("Pablo");
            Participant player3 = new ImpulsiveParticipant("María");
            Participant player4 = new ConservativeParticipant("Rosa");
            game.AddParticipant(player1);
            game.AddParticipant(player2);
            game.AddParticipant(player3);
            game.AddParticipant(player4);
            game.StartGame();
            game.SimulateGame();
            Console.WriteLine($"¡Felicidades! El ganador es el jugador {game.GetWinner()!.Name}.");
            Console.ReadLine();
        }
    }
}