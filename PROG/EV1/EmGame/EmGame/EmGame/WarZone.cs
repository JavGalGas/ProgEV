using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace EmGame
{
    public class WarZone
    {
        private int _width=0, _height=0, _maxWidth=10, _maxHeight=10;

        public WarZone(int width, int height, int maxW, int maxH)
        {
            _width=width;
            _height=height;
            _maxWidth=maxW; 
            _maxHeight=maxH;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        private List<Warrior> _warriors=new List<Warrior>();
        public List<Warrior> GetWarriorList()
        {
            return _warriors;
        }
        public void CreateWarrior(int count, TeamType type)
        {
            for(int i = 0; i < count; i++)
            {
                Warrior warrior = new Warrior(1,1,100,0.6,1,0.8, type);
                _warriors.Add(warrior);
            }
        }
        public List<Warrior> RemoveWarriorAt(int index)
        {
            List<Warrior> List1 = _warriors;
            List1.RemoveAt(index);
            return List1;
        }
        public void MoveWarrior(int x, int y, int targetX, int targetY)
        {
            Warrior? warrior = GetWarriorAt(x, y);
            if (warrior == null)
            {
                return;
            }
            warrior.Move(targetX, targetY);
        }

        public void ExecuteRound(WarZone zone)
        {
            for(int i=0; i< _warriors.Count; i++)
            {
                Warrior warrior= _warriors[i];
                warrior.ExecuteTurn(zone);
            }
            return;
        }

        public Warrior? GetWarriorAt(int x, int y) //en el WarZone
        {
            for (int i = 0; i < _warriors.Count; i++)
            {
                if (_warriors[i].GetX()==x && _warriors[i].GetY()==y)
                    return _warriors[i];
            }
            return null;
        }

        public int GetWarriorCount()
        {
            return _warriors.Count;
        }

        public Warrior? GetWarriorAt2(int index) // en la lista
        {
            return (index < 0 || index >= _warriors.Count) ? _warriors[index] : null;
        }

        public int GetEnemiesAroundCount(int x, int y, TeamType team) // todos los enemigos en el rango
        {
            int x0 = x - 1, y0 = y - 1, x1 = x + 1, y1 = y + 1;
            int enemyCount=0;
            List<Warrior> list = GetWarriorsInside(x0, y0, x1, y1);

            for(int i=0; i< list.Count; i++)
            {
                if (list[i].GetTeam()!=team && list[i].GetX()!=x && list[i].GetY() != y)
                    enemyCount++;
            }
            return enemyCount;
        }

        public int GetPlayersAroundCount(int x, int y) //todos los jugadores en el rango
        {
            int x0 = x - 1, y0 = y - 1, x1 = x + 1, y1 = y + 1;
            return GetWarriorsInside(x0, y0, x1, y1).Count();
        }

        public List<Warrior> GetWarriorsSortedByDistance(int x, int y)
        {
            List<Warrior> list = GetWarriorsInside(0, 0, GetWidth(), GetHeight());
            int n = list.Count - 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    double aux = Weapon.GetDistance(x, y, list[j].GetX(), list[j].GetY());
                    if (aux < Weapon.GetWeaponDistance())
                    {
                        Swap(i, j, list); 
                    }
                }
            }
            return (list);
        }
        public void Swap(int i, int j, List<Warrior> list)
        {
            Warrior aux2 = new Warrior(0, 0, 0, 0, 0, 0, 0);
            List<Warrior> warriors = list;
            aux2 = list[i];
            list[i] = list[j];
            list[j] = aux2;
        }

        public List<Warrior> GetWarriorsInside(int x, int y, int x2, int y2)
        //public List<Warrior> GetWarriorsInside(int x, int y, int width, int height)
        {
            int i=x;
            int j=y;
            List<Warrior?> list = new List<Warrior?>();

            while (i<=x2 && j<=y2)
            {
                ++i;
                ++j;
                if (j == y2)
                    j = y;
                if (GetWarriorAt(i, j) == null)
                    continue;
                list.Add(GetWarriorAt(i, j));
            }
            return list;

            //while(i<=x2)
            //{
            //  ++i;
            //    while(j<=y2)
            //    {
            //        ++j;
            //        if (GetWarriorAt(i, j)==null)
            //            break;
            //        list.Add(GetWarriorAt(i, j));
            //    }   
            //}
        }

        //Ver como conseguir que MoveWarrior llame a un solo guerrero
        public bool IsBattleFinished(WarZone warZone)
        {
            ExecuteRound(warZone);
            Warrior? warrior = warZone.GetWarriorAt2(0);
            for(int i = 1; i < warZone.GetWarriorList().Count; i++)
            {
                if (warZone.GetWarriorAt2(i) != warrior) 
                    return false;
            }
            return true;

        }
    }
}
