﻿namespace Ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Player winner = game.Simulate();
            Console.WriteLine("El ganador es : " + winner.Name);
            NormalPlayer n = new("",0);
            Console.WriteLine(n.Name);
        }
    }
}