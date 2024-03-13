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

        public Game() 
        { 
            //constructor vacío si quiero ir añadiendo participantes poco a poco
        }

        public Game(List<Participant> participants) 
        { 
            _participants = participants;
            _gameDeck.AddDeck();
        }

        public void StartGame()//método para iniciar una nueva partida
        {
            _gameDeck.Shuffle();
            while(_gameDeck.DominoesCount%_participants.Count == 0) 
            {
                foreach(var player in _participants)
                {
                    player.AddDomino(_gameDeck.ExtractPiece()!);
                }
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

        public void PlayRound()
        {
            foreach (var participant in _participants)
            {
                Domino playedDomino = participant.ChooseDomino();

            }
        }

        public void AddParticipant(Participant player)
        {
            _participants.Add(player);
        }
    }
}
