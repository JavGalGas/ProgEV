using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public abstract class Participant
    {
        protected List<Domino> _dominoes = new();
        private string _name;
        public string Name { get => _name; }
        public Participant(string name)
        {
            _name = name;
        }

        public virtual Domino? ChooseDomino(Domino[] field, out int position )
        {
            if (field == null)
            {
                position = -1;
                return null;
            }         
            for (int i = 0; i < field.Length; i++)
            {
                if (IsValid(_dominoes[i], field)==0)
                {
                    position = 1;
                    var p = _dominoes[i];
                    _dominoes.RemoveAt(i);
                    return p;
                }
                if (IsValid(_dominoes[i], field) == field.Length)
                {
                    position = -1;
                    var p = _dominoes[i];
                    _dominoes.RemoveAt(i);
                    return p;
                }
            }
            position = -1;
            return null;
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
        public void AddDomino(Domino domino)
        {
            if (domino == null)
                throw new ArgumentNullException();
            _dominoes.Add(domino);
        }

        
        

    }
}
