namespace CharacterClass
{
    public class Stadistics
    {
        private int _health = 10;
        private int _magic = 10;
        private int _attack = 10;
        private int _defense = 10;
        private int _speed = 10;

        public int Health => _health;
        public int Magic => _magic;
        public int Attack => _attack;
        public int Defense => _defense;
        public int Speed => _speed;

        public Stadistics()
        {

        }

        public Stadistics(int health, int magic, int attack, int defense, int speed)
        {
            SetHealth(health);
            SetMagic(magic);
            SetAttack(attack);
            SetDefense(defense);
            SetSpeed(speed);
        }

        public void SetAttack(int attack)
        {
            if (attack <= 0) 
                return;
            _attack = attack;
        }

        public void SetDefense(int defense)
        {
            if (defense <= 0)
                return;
            _defense = defense;
        }

        public void SetHealth(int health)
        {
            if (health <= 0)
                return;
            _health = health;
        }

        public void SetMagic(int magic)
        {
            if (magic <= 0)
                return;
            _magic = magic;
        }

        public void SetSpeed(int speed)
        {
            if (speed <= 0)
                return;
            _speed = speed;
        }


    }
}