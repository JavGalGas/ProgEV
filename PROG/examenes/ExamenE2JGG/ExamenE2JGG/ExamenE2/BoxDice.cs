namespace ExamenE2
{
    public class BoxDice : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;


        public BoxDice(int boxPosition)
        {
            _boxPosition = boxPosition;
        }

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition && _boxPosition == 27)
                {
                    player.SetPlayerPosition(53, game);
                    player.SimulatePlayer(game);
                }
            });
        }
    }
}