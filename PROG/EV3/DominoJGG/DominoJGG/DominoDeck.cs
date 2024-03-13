using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class DominoDeck
    { //Necesita métodos para comprobar qué fichas hay en el monto
        private List<Domino> _dominoes = new();

        public int DominoesCount { get => _dominoes.Count; }

        public Domino? ExtractPieceAt(int index)
        {
            if (index < 0 || index >= _dominoes.Count)
            {
                return null;
            }
            var p = _dominoes[index];
            _dominoes.RemoveAt(index);
            return p;
        }

        public Domino? ExtractPiece()
        {
            int random = Utils.GetRandomBetween(0, _dominoes.Count - 1);
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
            if (index < 0 || index >= _dominoes.Count)
                return null;
            return _dominoes[index];
        }

        public void Swap(ref Domino p1, ref Domino p2)
        {
            Domino aux = p1;
            p1 = p2;
            p2 = aux;
        }

        public void Shuffle()
        {
            for (int i = 0; i < _dominoes.Count; i++)
            {
                Domino p1 = _dominoes[Utils.GetRandomBetween(0, DominoesCount - 1)];
                Domino p2 = _dominoes[Utils.GetRandomBetween(0, DominoesCount - 1)];
                Swap(ref p1, ref p2);
            }
        }

        public bool ContainsPiece(Domino piece)
        {
            if (piece == null)
                return false;
            for (int i = 0; i < DominoesCount; i++)
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
            for (int i = 0; i < DominoesCount - 1; i++)
            {
                if (piece.IsEquals(GetPieceAt(i)))
                    return i;
            }
            return -1;
        }

        public void AddDeck()
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    Domino piece = new Domino(i, j);
                    _dominoes.Add(piece);
                }
            }
        }
    }
}
