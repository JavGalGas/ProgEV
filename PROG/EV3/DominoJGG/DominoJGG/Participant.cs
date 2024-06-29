using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{//utilizar lambda en el sort
    public abstract class Participant
    {
        protected List<Domino> _dominoes = new();
        private string _name;
        public string Name { get => _name; }
        public Participant(string name)
        {
            _name = name;
        }

        public virtual Domino? ChooseDomino(Game game, out int position )
        {
            if (game == null)
            {
                position = -1;
                return null;
            }         
            for (int i = 0; i < game.GameField.Length; i++)
            {
                int valid = IsValid(_dominoes[i], game);
                if (valid != -1)
                {
                    var p = CheckSwap(_dominoes[i], game);
                    position = valid;
                    _dominoes.RemoveAt(i);
                    return p;
                }
                if (valid == game.GameField.Length)
                {
                    var p = CheckSwap(_dominoes[i], game);
                    position = -1;
                    _dominoes.RemoveAt(i);
                    return p;
                }
            }
            position = -1;
            return null;
        }

        private Domino CheckSwap(Domino piece, Game game)
        {
            Domino p = piece;
            if (piece.Value1 == game.StartField || piece.Value2 == game.EndField)
            {
                p = piece.SwapValues();
            }
            return p;
        }
        public abstract void Sort();
        public virtual int IsValid(Domino piece, Domino[] field)
        {
            if (field == null)
                return -1;
            int lastDominoIndex = field.Length - 1;
            if (piece.Value1 == field[0].Value1 || piece.Value2 == field[0].Value1)
                return 0;
            else if (piece.Value1 == field[lastDominoIndex].Value2 || piece.Value2 == field[lastDominoIndex].Value2)
                return field.Length;
            return -1;
        }

        public virtual int IsValid(Domino piece, Game gamefield)
        {
            if (gamefield == null)
                return -1;
            if (piece.Value1 == gamefield.StartField || piece.Value2 == gamefield.StartField)
                return 0;
            else if (piece.Value1 == gamefield.EndField || piece.Value2 == gamefield.EndField)
                return gamefield.GameField.Length;
            return -1;
        }

        public void AddDomino(Domino domino)
        {
            if (domino == null)
                throw new ArgumentNullException();
            _dominoes.Add(domino);
        }

        public List<Domino> GetDominoes()
        {
            List<Domino > list = new List<Domino>();
            if(_dominoes != null)
                foreach (Domino domino in _dominoes)
                { list.Add(domino); }
            return list;
        }
        
        public int GetHandValue()
        {
            int value = 0;
            if(_dominoes==null) 
                return value;
            foreach(var domino in _dominoes)
            {
                int aux = domino.Value1 + domino.Value2;
                if(domino.IsDouble) 
                    aux*=2;
                value += aux;
            }
            return value;
        }

        public void Clear()
        {
            _dominoes.Clear();
        }

    }
}
