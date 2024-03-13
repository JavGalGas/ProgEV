using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmGame
{
    public enum WeaponType
    {
        PUNCH,
        SWORD,
        BOW,
        MAZE,
        ARROW,
    }
    public class Weapon
    {
        private WeaponType _weaponType;
        private int _damage;
        private int _reloadTime;
        private int _arrowAmmo;
        private static double _distance;

        public WeaponType? GetWeaponType()
        {
            return _weaponType;
        }
        public int GetWeaponDamage()
        {
            return _damage;
        }
        public int GetWeaponReload()
        {
            return _reloadTime;
        }
        public static double GetWeaponDistance()
        {
            return _distance;
        }
        public void SetWeapon() 
        {
            if (_weaponType == WeaponType.PUNCH)
            {
                _damage = 25;
                _reloadTime = 1;
                _distance= 1.5;
            }
            if (_weaponType == WeaponType.SWORD)
            {
                _damage = 15;
                _reloadTime = 2;
                _distance = 4.3;
            }
            if (_weaponType == WeaponType.BOW)
            {
                _damage = 5;
                _reloadTime = 1;
                _distance = 1.5;
            }
            if (_weaponType == WeaponType.MAZE)
            {
                _damage = 20;
                _reloadTime = 2;
                _distance = 2.9;
            }
            if (_weaponType == WeaponType.ARROW)
            {
                _damage = 10;
                _reloadTime = 1;
                _arrowAmmo = 10;
                _distance = 8.5;
            }
        }

        public void ArrowToBow()
        {
            if (_arrowAmmo == 0)
                _weaponType = WeaponType.BOW;
            _arrowAmmo -= 1;
        }

        public static double GetDistance(Warrior w1, Warrior w2)
        {
            return GetDistance(w1.GetX(), w1.GetY(), w2.GetX(), w2.GetY());
        }
        public static double GetDistance(int x1, int y1, int x2, int y2)
        {
            int dx= x2-x1;
            int dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
