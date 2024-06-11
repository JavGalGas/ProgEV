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
        private Box[] _boxes = new Box[63];
        public Player? _winner;

        public Game() 
        {
            _players = new List<Player>();
            CreateBoard();
        }

        public void AddPlayer(Player player) 
        {
            if (player.Name == string.Empty || player.Name == null)
                throw new ArgumentNullException(nameof(player.Name));
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
                player.Box = GetBox(1);
                player.DiceThrow = player.ThrowDice();
            }
            for (int i = 0; i < _players.Count - 1; i++)
            {
                for (int j = i + 1; j < _players.Count; j++)
                {
                    SortPlayersAux(i,j);
                }
            }
        }

        private void SortPlayersAux(int player1, int player2)
        {
            if (_players[player1].DiceThrow > _players[player2].DiceThrow)
            {
                Swap(player1, player2);
            }
            else if (_players[player1].DiceThrow == _players[player2].DiceThrow)
            {
                while (_players[player1].DiceThrow == _players[player2].DiceThrow)
                {
                    int player1DiceThrow = _players[player1].ThrowDice();
                    int player2DiceThrow = _players[player2].ThrowDice();
                    if (player1DiceThrow > player2DiceThrow)
                    {
                        Swap(player1, player2);
                        break;
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
            if (_players.Count <= 0)
                throw new Exception($"The variable {nameof(_players)} has no players.");
            SortPlayers();
            while (_winner == null)
            {
                VisitPlayers(player =>
                {
                    player.SimulateTurn(this);
                    if (_winner != null)
                        return;
                });
            }
            return _winner;
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

        public Box GetBox(int index)
        {
            if (index <= 0)
                throw new ArgumentOutOfRangeException("index");
            if (index > _boxes.Length)
                return _boxes[54];
            return _boxes[index-1];
        }
    }
}
