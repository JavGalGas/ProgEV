using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenE2
{
    public delegate void VisitDelegate<T>(T element);
    public class Game
    {
        private List<Player> _players; //cambio: Creo una nueva instancia en el constructor
        private IBox[]? _field;
        private Player? _winner;

        public List<Player> Players => _players;

        public Game()
        {
            _players = new List<Player>();
            CreateField();
        }
        public void SetWinner(Player winner)
        {
            if (winner == null)
                throw new ArgumentNullException(nameof(winner));
            if (_winner != null)
                return;
            _winner = winner;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            if (Contains(player))
                throw new Exception("The player is already contained.");
            _players.Add(player);
        }

        public void RemovePlayers()
        {
            _players = new List<Player>();
        }

        public bool Contains(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            foreach (Player character in _players)
            {
                if (character.Equals(player))
                    return true;
            }
            return false;
        }

        public void CreateField()//
        {
            _field = new IBox[63];
            for (int i = 0; i < 63; i++)
            {
                int boxPosition = i + 1;

                if(boxPosition% 6 == 0)
                {
                    _field[i] = new BoxGoose(boxPosition);
                }

                else if(boxPosition% 13 == 0) 
                {
                    _field[i] = new BoxPunish(boxPosition);
                }

                else if(boxPosition == 8 || boxPosition == 14)
                {
                    _field[i] = new BoxBridge(boxPosition);
                }

                else if (boxPosition == 27  || boxPosition == 53)
                {
                    _field[i] = new BoxDice(boxPosition);
                }

                else if (boxPosition == 58)
                {
                    _field[i] = new BoxDeath(boxPosition);
                }

                else if (boxPosition == 63)
                {
                    _field[i] = new BoxWinner(boxPosition);
                }

                else
                    _field[i] = new Box(boxPosition);
            }
        }

        private void SortPlayers()
        {
            if (_players == null)
                return;
            int player1Throw;
            int player2Throw;

            foreach (Player player in _players)
                player.SetStartThrow();

            for (int i = 0; i < _players.Count - 1; i++)
            {
                for (int j = i+1; j < _players.Count; j++)
                {
                    if (_players[i].ThrowValue < _players[j].ThrowValue)
                    {
                        SwapPlayers(i, j);
                    }
                    else if (_players[i].ThrowValue == _players[j].ThrowValue)//repiten las tiradas hasta que uno gane. Si gana el segundo, cambian posiciones.
                    {
                        do
                        {
                            player1Throw = _players[i].ThrowDice();
                            player2Throw = _players[j].ThrowDice();
                            if (player1Throw < player2Throw)
                                SwapPlayers(i, j);
                        } while (player1Throw == player2Throw);
                    }
                }
            }
        }

        private void SwapPlayers(int player1_index, int player2_index)//cambio: en vez de pasarle la lista, utilizo la lista en la función directamente
        {
            Player aux = _players[player1_index];
            _players[player1_index] = _players[player2_index];
            _players[player2_index] = aux;
        }

        public Player Simulate()
        {
            if (_players.Count <= 0)
                throw new Exception($"The variable {nameof(_players)} has no players.");

            //CreateField();cambio: como creo el tablero en el constructor, no lo creo en la función
            SortPlayers();
            foreach ( Player player in _players )
            {
                player.SetPlayerPosition(1,this);
            }
            while (_winner == null)
            {
                VisitPlayers(player =>
                {
                    player.SimulatePlayer(this);
                    if (_winner != null)
                        return;
                });
            }
            return _winner;
        }

        public void VisitPlayers(VisitDelegate<Player> visit)
        {
            if(visit == null)
            {
                throw new ArgumentNullException(nameof(visit));
            }
            if (_players.Count <= 0)
                throw new Exception("There are no players to visit");
            foreach (Player player in _players)
            {
                visit(player);
            }
        }

        public void VisitBoxField(VisitDelegate<IBox> visit)
        {
            if (visit == null)
            {
                throw new ArgumentNullException(nameof(visit));
            }
            if (_field == null || _field.Length <= 0)
                throw new ArgumentOutOfRangeException(nameof(_field));
            foreach (IBox box in _field)
            {
                visit(box);
            }
        }

        public GameState? GetGameState()
        {
            if (_players.Count == 0)
            {
                return null;
            }

            PlayerState[] gameState = new PlayerState[_players.Count];
            GameState state;
            for (int i = 0; i < gameState.Length; i++)
            {
                Player player = _players[i];
                if (player is PlayerQuick playerQuick)
                {
                    gameState[i] = new PlayerState()
                    {
                        Name = playerQuick.Name,
                        DisabledTurns = playerQuick.DisabledTurns,
                        BoxPosition = playerQuick.Box.BoxPosition,
                        PlayerType = playerQuick.PlayerType.ToString(),
                        DiceBonus = playerQuick.NumDices,
                    };
                }
                else
                {
                    gameState[i] = new PlayerState()
                    {
                        Name = player.Name,
                        DisabledTurns = player.DisabledTurns,
                        BoxPosition = player.Box.BoxPosition,
                        PlayerType = player.PlayerType.ToString()
                    };
                }
            }
            int idNumber = Utils.GetRandom();
            state = new GameState(idNumber, gameState);
            return state;
        }
        public void SetGameState(string gameStateJson)
        {

        }
    }
}
