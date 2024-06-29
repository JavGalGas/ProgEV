using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenE2
{
    public class GameState
    {
        [JsonPropertyName("Id")]
        public int id { get; set; }

        [JsonPropertyName("State")]
        public PlayerState[] State {get; set; }

        public GameState(int Id, PlayerState[] state)
        {
            id = Id;
            State = state;
        }
    }
}
