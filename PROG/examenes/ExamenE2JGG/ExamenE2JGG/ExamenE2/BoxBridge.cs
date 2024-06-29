namespace ExamenE2
{
    public class BoxBridge : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;


        public BoxBridge(int boxPosition)
        {
            _boxPosition = boxPosition;
        }

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition)
                {
                    if (_boxPosition == 27)
                    {
                        player.SetPlayerPosition(53, game);
                    }
                    else
                    {
                        player.SetPlayerPosition(27, game);
                    }
                    player.SimulatePlayer(game);
                }
            });
        }
    }
}