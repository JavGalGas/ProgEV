using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenE2
{
    public class PlayerState
    {
        [JsonPropertyName("PlayerName")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("DisabledTurns")]
        public int DisabledTurns { get; set; } = 0;

        [JsonPropertyName("BoxPosition")]
        public int BoxPosition { get; set; } = 1;

        [JsonPropertyName("PlayerType")]
        public string PlayerType { get; set; } = string.Empty;

        [JsonPropertyName("DiceBonus")]
        public int DiceBonus { get; set; } = 0;

        public PlayerState() 
        {
            
        }
    }
}
