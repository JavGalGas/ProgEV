using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class Game
    {
        private List<Participant> _participants = new();
        private Domino[] _gameField = new Domino[0];
        private DominoDeck _gameDeck = new();
        private Participant? _winner;
        public Participant? Winner { get => _winner; }
        public int StartField { get => _gameField[0].Value1; }
        public int EndField { get => _gameField[_gameField.Length-1].Value1; }

        public Game() //constructor vacío si quiero ir añadiendo participantes poco a poco
        {
        }

        public Game(List<Participant> participants) 
        { 
            _participants = participants;
        }

        public void StartGame()//método para iniciar una nueva partida
        {
            _gameField = new Domino[0];
            foreach (var participant in _participants)
            {
                participant.Clear();
            }
            _gameDeck.AddDeck().Shuffle();
            while(_gameDeck.DominoCount%_participants.Count == 0) 
            {
                foreach(var player in _participants)
                {
                    player.AddDomino(_gameDeck.ExtractPiece()!);
                }
            }
            foreach (var player in _participants)
            {
                player.Sort();
            }
        }

        public void SimulateGame()
        {
            int round = 1;
            while (_participants.Count > 1)
            {
                for(int i = 0; i < _participants.Count; i++)
                {
                    if(_participants[i].GetDominoes().Count == 0) 
                    {
                        
                    }
                }
                StartGame();
                PlayRound();
                _participants.RemoveAt(0);
                round++;
            }
            _winner = _participants[0];
        }

        public void PlayRound()
        {
            int position = -1;
            int length = _gameField.Length;
            int newLength = length +1;
            foreach (var participant in _participants)
            {
                Domino? playedDomino = participant.ChooseDomino(_gameField, out position);
                if (playedDomino == null || position == -1)
                    continue;
                Domino[] newField = new Domino[newLength];
                newField[position] = playedDomino;
                for (int i = 0; i < newLength; i++)
                {
                    if (newField[0] == playedDomino)
                        continue;
                    newField[i] = _gameField[i];
                }
                _gameField = newField;  
            }
        }

        public void AddParticipant(Participant player)
        {
            _participants.Add(player);
        }
    }
}
