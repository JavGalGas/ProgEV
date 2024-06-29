namespace ExamenE2
{
    public class BoxWinner : IBox
    {
        private int _boxPosition = 1;
        public BoxWinner(int boxPosition)
        {
            _boxPosition = boxPosition;
        }

        public int BoxPosition => _boxPosition;

        public void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Box.BoxPosition == _boxPosition)
                {
                    game.SetWinner(player);
                }
                else if (player.Box.BoxPosition > _boxPosition)
                    player.SetPlayerPosition(55,game);
            });
        }
    }
}