using System.Security.Cryptography.X509Certificates;

namespace EmGame
{
    public enum TeamType
    {
        HUMAN,
        DWARF,
        ORC,
        ELF,
        GNOME,
        DEMON,

    }
    public class Warrior
    {
        private int _x, _y;
        private double _life;
        private double _lifeCapacity;
        private double _accuracity;
        private int _armor;
        private double _lucky;
        private TeamType _team;
        private int _cooldown;
        public Warrior(int x, int y, int life, double accuracity, int armor, double lucky, TeamType teamType)
        {
            _x=x;
            _y=y;
            _life=life;
            _accuracity=accuracity;
            _armor=armor;
            _lucky=lucky;
            _team=teamType;
        }
        

        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public double GetLife()
        {
            return _life;
        }
        public double GetLifeCapacity()
        {
            return _lifeCapacity;
        }
        public double GetAccuracity()
        {
            return _accuracity;
        }
        public int GetArmor()
        {
            return _armor;
        }
        public  double GetLucky()
        {
            return _lucky;
        }
        public TeamType GetTeam()
        {
            return _team;
        }
        public int GetCooldown()
        {
            return _cooldown;
        }

        public void ExecuteTurn(WarZone zone)
        {
            double value, min, max = 10.0;

            if (zone == null)
                return;

            if (GetLife() < GetLifeCapacity()/2)
            {
                min = 4.0;
                value = EmGame.GetRandomBetween(min, max);

            }
            else if (GetLife() > GetLifeCapacity() / 2)
            {
                min = 1.0;
                value = EmGame.GetRandomBetween(min, max);
            }
            if(value > 0)

        }


        public void Move(int x, int y)
        {
            SetX(x);
            SetY(y);
        }

        public void SetX(int x)
        {
            _x = x;
        }
        public void SetY(int y)
        {
            _y = y;
        }
        public void SetCooldown(int cooldown)
        {
            _cooldown = cooldown;
        }

        public void SetAccuracity(double accuracity)
        {
            _accuracity = accuracity;
        }
        public void SetLife(int life)
        {
            _life = life;
        }
        public void SetLifeCapacity(double maxLife)
        {
            
            if(maxLife<GetLife())
            {
                maxLife = GetLife();
                _lifeCapacity = maxLife;
            }
            else
            {
                _lifeCapacity = maxLife;
            }
        }
        
    }
   
        
    
}
