﻿using System.Reflection.PortableExecutable;

namespace CharacterClass
{
    public class Stadistics//utilizar esta clase para hacer los cálculos ????
    {
        private int _health = 100;
        private int _magic = 100;
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

        public void IncreaseStadistics(Character character)
        {
            const int numIncrease = 2;
            const int numLowIncrease = 1;
            const int numGreatIncrease = 4;

            if (character is Tank tank)
            {
                _health += 5 * numIncrease;
                _magic += 5 * numIncrease;
                _attack += numIncrease;
                _defense += numGreatIncrease;
                _speed += numLowIncrease;
            }
            else if (character is Warrior warrior)
            {
                _health += 5 * numIncrease;
                _magic += 5 * numLowIncrease;
                _attack += numGreatIncrease;
                _defense += numIncrease;
                _speed += numIncrease;
            }
            else if (character is Mage mage)
            {
                _health += 5 * numLowIncrease;
                _magic += 5 * numGreatIncrease;
                _attack += numIncrease;
                _defense += numIncrease;
                _speed += numIncrease;
            }
            else if (character is Thief thief)
            {
                _health += 5 * numIncrease;
                _magic += 5 * numIncrease;
                _attack += numIncrease;
                _defense += numLowIncrease;
                _speed += numGreatIncrease;
            }
            else if (character is Support support)
            {
                _health += 5 * numGreatIncrease;
                _magic += 5 * numIncrease;
                _attack += numLowIncrease;
                _defense += numIncrease;
                _speed += numIncrease;
            }
        }


    }
}