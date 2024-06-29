namespace ExamenE2
{
    public class BoxGoose : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;

        public BoxGoose(int position)
        {
            _boxPosition = position;
        }

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition)
                {
                    player.SetPlayerPosition(_boxPosition + 6, game);//Suma la posición más 6, ej: posición = 6, 6 + 6 = 12, nueva posición = 12
                    player.SimulatePlayer(game);
                }
            });
        }
    }
}