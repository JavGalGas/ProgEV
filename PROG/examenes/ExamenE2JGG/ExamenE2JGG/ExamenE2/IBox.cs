using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenE2
{
    public interface IBox
    {
        void ApplyEffect(Game game);

        int BoxPosition { get; }

    }
}
