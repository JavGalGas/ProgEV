using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{//DominoDeck d = new DominoDeck().Fill().Shuffle();
 //para hacer lo anterior las funciones deben devolver DominoDeck [return this]
    public class DominoDeck
    { //Necesita métodos para comprobar qué fichas hay en el monto
        private List<Domino> _dominoes = new();

        public int DominoCount { get => _dominoes.Count; }

        //clases basadas en listas de algo, sobreescribiendo esta property indexer ya
        //funciona como una variable, parecida a un array
        //public Domino? this[int index]
        //{
        //    get => _dominoes[index];
        //    set => _dominoes[index] = value;
        //}

        public Domino? ExtractPieceAt(int index)
        {
            if (index < 0 || index >= DominoCount)
            {
                return null;
            }
            var p = _dominoes[index];
            _dominoes.RemoveAt(index);
            return p;
        }

        public Domino? ExtractPiece()
        {
            int random = Utils.GetRandomBetween(0, DominoCount - 1);
            return ExtractPieceAt(random);
        }

        public void AddPiece(Domino? piece)
        {
            if (piece == null)
                return;
            if (ContainsPiece(piece) == false)
                _dominoes.Add(piece);
        }

        public Domino? GetPieceAt(int index)
        {
            if (index < 0 || index >= DominoCount)
                return null;
            return _dominoes[index];
        }

        public void Swap(ref Domino p1, ref Domino p2)
        {
            Domino aux = p1;
            p1 = p2;
            p2 = aux;
        }

        public DominoDeck Shuffle()
        {
            for (int i = 0; i < _dominoes.Count; i++)
            {
                Domino p1 = _dominoes[Utils.GetRandomBetween(0, DominoCount - 1)];
                Domino p2 = _dominoes[Utils.GetRandomBetween(0, DominoCount - 1)];
                Swap(ref p1, ref p2);
            }
            return this;
        }

        public bool ContainsPiece(Domino piece)
        {
            if (piece == null)
                return false;
            for (int i = 0; i < DominoCount; i++)
            {
                if (_dominoes[i].IsEquals(piece))
                    return true;
            }
            return false;
        }

        public int IndexOf(Domino piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < DominoCount; i++)
            {
                if (piece.IsEquals(GetPieceAt(i)))
                    return i;
            }
            return -1;
        }

        public DominoDeck AddDeck()
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                { 
                    Domino piece = Domino.CreatePiece(i, j)!;
                    _dominoes.Add(piece);
                }
            }
            return this;
        }
    }
}
