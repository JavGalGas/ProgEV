namespace DominoJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
             // Configuración inicial
            int numParticipantes = 4; // Cambia esto según el número de jugadores
            List<string> fichas = GenerarFichas();
            List<string>[] manos = RepartirFichas(fichas, numParticipantes);

            // Inicia las rondas
            while (numParticipantes > 1)
            {
                // Implementa la lógica de cada ronda aquí
                // ...
                // Al final de la ronda, actualiza el número de participantes
                numParticipantes--;
            }

            // El ganador es el último jugador restante
            Console.WriteLine("¡Felicidades! El ganador es el jugador X."); // Cambia esto con el nombre del ganador

            Console.ReadLine();
        }

        // Genera todas las fichas de dominó posibles
        static List<string> GenerarFichas()
        {
            List<string> fichas = new List<string>();
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    fichas.Add($"{i}-{j}");
                }
            }
            return fichas;
        }

        // Reparte las fichas aleatoriamente entre los jugadores
        static List<string>[] RepartirFichas(List<string> fichas, int numParticipantes)
        {
            List<string>[] manos = new List<string>[numParticipantes];
            // Implementa la lógica de repartir las fichas aquí
            // ...
            return manos;
        }
    }
}