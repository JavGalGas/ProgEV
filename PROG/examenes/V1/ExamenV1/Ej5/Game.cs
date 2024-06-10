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
        public delegate void VisitDelegate<T>(T element);

        private List<Player> _players;
        public Player _winner;
        private Box[] _boxes = new Box[63];


        public Game() 
        {
            _players = new List<Player>();
            CreateBoard();
            _winner = ;
        }

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
                player.DiceThrow = player.ThrowDice();
            }
            for (int i = 0; i < _players.Count - 1; i++)
            {
                for (int j = i + 1; j < _players.Count; j++)
                {
                    if (_players[i].DiceThrow > _players[j].DiceThrow)
                    {
                        Swap(i, j);
                    }
                    else if (_players[i].DiceThrow == _players[j].DiceThrow)
                    {
                        while(_players[i].DiceThrow == _players[j].DiceThrow)
                        {
                            int player1DiceThrow = _players[i].ThrowDice();
                            int player2DiceThrow = _players[j].ThrowDice();
                            if(player1DiceThrow > player2DiceThrow)
                            {
                                Swap(i, j);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Swap(int playerIndex1,  int playerIndex2)
        {
            Player aux = _players[playerIndex1];
            _players[playerIndex1] = _players[playerIndex2];
            _players[playerIndex2] = aux;
        }

        public Player Simulate()
        {
            SortPlayers();
            foreach (var player in _players)
            {
                player.SimulateTurn();
                if (_winner == player)
                    return player;
            }
        }

        public void VisitPlayers(VisitDelegate<Player> visit)
        {
            foreach (var player in _players)
            {
                visit(player);
            }
        }

        public void VisitBoxes(VisitDelegate<Box> visit)
        {
            foreach (var box in _boxes)
            {
                visit(box);
            }
        }
    }
}
