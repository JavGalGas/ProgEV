using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public abstract class Participant
    {
        private List<Domino> _dominoes = new();
        private string _name;

        public Participant(string name)
        {
            _name = name;
        }

        public abstract Domino ChooseDominoe();

        public void AddDominoe(Domino domino)
        {
            if (domino == null)
                throw new ArgumentNullException();
            _dominoes.Add(domino);

        }
    }
}
