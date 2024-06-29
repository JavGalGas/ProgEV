using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class ImpulsiveParticipant : Participant
    {
        public ImpulsiveParticipant(string name) : base(name)
        {
        }

        public override void Sort()
        {
            int count2 = _dominoes.Count;
            int count = count2 - 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = i+1; j < count2; j++)
                {
                    Domino piece = _dominoes[i];
                    Domino piece2 = _dominoes[j];
                    if (piece2.IsDouble)
                    {
                        if (piece.IsDouble && piece.TotalValue > piece2.TotalValue)
                            continue;
                        //Domino aux = _dominoes[i];
                        //_dominoes[i] = _dominoes[j];
                        //_dominoes[j] = aux;
                        //Utils.Swap(ref piece, ref piece2);
                        Utils.Swap(_dominoes, i, j);
                    } 
                }
            }
        }
    }
}
