namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DominoPiece f = new DominoPiece(1, 2);

            //Card carta1 = new Card(13, Palo.CLOVER);
            //Console.WriteLine(carta1.IsValid());
            //Console.WriteLine(carta1.GetValue());
            //Console.WriteLine(carta1.GetPalo());
            //Console.WriteLine(carta1.GetColor());
            //Console.WriteLine(carta1.GetFigure());
            //Console.WriteLine(carta1.IsFigure());
            //Console.WriteLine("");
            //Console.WriteLine("_________________________________________________________________________________________");
            //Console.WriteLine("");
            //DominoDeck deck = new DominoDeck();
            //for(int i = 0; i < 10; i++)
            //{
            //    DominoPiece? piece = DominoPiece.CreatePiece(DominoDeck.GetRandomBetween(0, 6), DominoDeck.GetRandomBetween(0, 6));
            //    deck.AddPiece(piece);
            //}
            //deck.Shuffle();
            //DominoPiece piece1 = new(6,2);
            //DominoPiece? piece2 = DominoDeck.ExtractPiece();
            //Console.WriteLine(piece1.GetValue1());
            //Console.WriteLine(piece1.GetValue2());
            //Console.WriteLine(piece1.GetTotalValue());
            //Console.WriteLine(piece1.IsDouble());
            //Console.WriteLine(piece1.IsEquals(piece2));
            //Console.WriteLine(deck.ContainsPiece(piece1));
            //Console.WriteLine(deck.GetPieceAt(2));
            //Console.WriteLine(deck.GetPieceCount());
            //Console.WriteLine("");
            //Console.WriteLine("_________________________________________________________________________________________");
            //Console.WriteLine("");
            //DateTime time = new DateTime(14, 02, 59, 07, 12, 2023);
            //if (time.IsValid())
            //{
            //    DateTime time2 = time.Clone();
            //    time.Equals(time2);
            //}
            //else
            //{
            //    time.Correct();
            //}
            //Console.WriteLine(time.IsLeap());
            //Console.WriteLine(time.GetNameOfDay());
            //Console.WriteLine(time.DateToString());
            //time.IncrementSeconds();
            //Console.WriteLine(time.DateToString());
            //time.IncrementDay();
            //Console.WriteLine(time.DateToString());
            //Console.WriteLine("");
            //Console.WriteLine("_________________________________________________________________________________________");
            //Console.WriteLine("");
            //int centims = 50023;
            //List<Moneda> result = CoinChange.GetCoins(centims);
            //for(int i = 0; i < result.Count; i++)
            //{
            //    Console.Write(result[i]+", ");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("_________________________________________________________________________________________");
            //Console.WriteLine("");

            //ChessGame, ChessUtils, ChessFigure To Do (static-->!static)

            //el nuevo símbolo visto el (30-10-2023), una relación con un cuadrado blanco al final es el símbolo de Agregación.
            //si el cuadrado es negro, es el símbolo de Composición.
            //Cuando se elimina la clase seleccionada por Agregación, NO se elimina la clase que la seleccionaba.
            //Cuando se elimina la clase seleccionada por Composición, SÍ se elimina la clase que la seleccionaba.

            List<int> list = new List<int>();
            for (int i = 2000; i<= 2099; i++)
            {
                DateTime time = new DateTime(07, 10, i);
                if (!time.IsValid())
                {
                    time.Correct();
                }
                if (time.GetNameOfDay() == "Saturday")
                    list.Add(time.GetYear());
            }
            foreach (int i in list)
                Console.WriteLine(i);
        }
    }
}