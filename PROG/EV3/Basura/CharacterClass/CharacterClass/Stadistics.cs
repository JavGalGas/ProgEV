namespace CharacterClass
{
    public class Stadistics
    {
        private int _attack = 10;
        private int _defense = 10;
        private int _health = 10;
        private int _magic = 10;
        private int _speed = 10;

        public int Attack => _attack;
        public int Defense => _defense;
        public int Health => _health;
        public int Magic => _magic;
        public int Speed => _speed;

        public Stadistics()
        {

        }

        public Stadistics(int attack, int defense, int health, int magic, int speed)
        {
            _attack = attack;
            _defense = defense;
            _health = health;
            _magic = magic;
            _speed = speed;
        }




    }
}