namespace ExamenE2
{
    public class BoxPunish : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;


        public BoxPunish(int boxPosition)
        {
            _boxPosition = boxPosition;
        }

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition)
                {
                    player.AddDisabledTurns(_boxPosition/13); //Calcula el número de turnos que el jugador va a estar deshabilitado : 13/13=> 1 , 26/13=>2...
                }
            });
        }
    }
}