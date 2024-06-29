namespace ExamenE2
{
    public class BoxDeath : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;


        public BoxDeath(int boxPosition)
        {
            _boxPosition = boxPosition;
        }

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition)
                {
                    player.SetPlayerPosition(1, game);
                }
            });
        }
    }
}