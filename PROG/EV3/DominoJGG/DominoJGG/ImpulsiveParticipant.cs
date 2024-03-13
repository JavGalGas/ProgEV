using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class ImpulsiveParticipant : Participant
    {
        public ImpulsiveParticipant(string name) : base(name)
        {
        }

        public override Domino ChooseDomino()//comprobar los valores del Array de Juego
        {
            Domino piece = _dominoes[0];
            foreach( var i in _dominoes )
                if(i.IsDouble)
                    return i;
            foreach( var i in _dominoes)
                if(piece.TotalValue < i.TotalValue)
                    piece = i;
            return piece;
        }
    }
}
