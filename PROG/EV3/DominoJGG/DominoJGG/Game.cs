using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class Game
    {
        private List<Participant> _participants;
        private DominoDeck _gameField;
        private Participant? _winner;

        public Game(List<Participant> participants, DominoDeck amountOfDominoes) 
        { 
            _participants = participants;
            _gameField = amountOfDominoes;
        }
        public void StartGame()//método para iniciar una nueva partida
        {
            _gameField.Shuffle();
            foreach (Participant participant in _participants)
            {
                _gameField.ExtractPiece();
            }
        }
        public void SimulateGame()
        {
            while (_participants.Count > 1)
            {
               StartGame();
                _participants.RemoveAt(0);
            } 
        }
    }
}
