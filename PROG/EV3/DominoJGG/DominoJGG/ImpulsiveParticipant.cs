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
                        //Domino aux = _dominoes[i];
                        //_dominoes[i] = _dominoes[j];
                        //_dominoes[j] = aux;
                        Swap(ref piece, ref piece2);
                    } 
                }
            }
        }

        public void Swap(ref Domino p1, ref Domino p2)
        {
            Domino aux = p1;
            p1 = p2;
            p2 = aux;
        }
    }
}
