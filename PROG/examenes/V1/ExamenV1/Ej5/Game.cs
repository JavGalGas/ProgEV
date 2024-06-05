using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class Game
    {
        private List<Player> _players = new();
        private Box[] _boxes = new Box[63];

        public void AddPlayer(Player player) 
        {
            if (player.Name == string.Empty || player.Name == null)
                throw new ArgumentNullException(nameof(player.Name));
            if (player.Position < 0)
            _players.Add(player);
        }

        public void RemovePlayers()
        {
            _players = new();
        }

        public void CreateBoard()
        {
            Box[] fichas = new Box[63];
            for (int i = 0; i < fichas.Length; i++)
            {
                int boxValue = i + 1;

                if (boxValue == 63)
                    fichas[i] = new BoxWin(boxValue);

                else if (boxValue % 6 == 0)
                    fichas[i] = new BoxGoose(boxValue);

                else if (boxValue % 13 == 0)
                    fichas[i] = new BoxPunish(boxValue);

                else if (boxValue == 8 || boxValue == 14)
                    fichas[i] = new BoxBridge(boxValue);

                else if (boxValue == 27 || boxValue == 53)
                    fichas[i] = new BoxDice(boxValue);

                else if (boxValue == 58)
                    fichas[i] = new BoxDeath(boxValue);

                else
                    fichas[i] = new BoxNormal(boxValue);
            }
            _boxes = fichas;
        }

        private void SortPlayers()
        {
            foreach (var player in _players)
            {
                player.ThrowDice();
            }
            for (int i = 0; i < _players.Count - 1; i++)
            {
                for (int j = i + 1; j < _players.Count; j++)
                {
                    if (_players[i].DiceThrow > _players[j].DiceThrow)
                    {
                        Player aux = _players[i];
                        _players[i] = _players[j];
                        _players[j] = aux;
                    }
                }
            }
        }

        public Player Simulate()
        {
            SortPlayers();
            foreach (var player in _players)
            {
                player.ExecuteTurn();
            }
            return new NormalPlayer("J",63);
        }
    }
}
