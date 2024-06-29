using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ej3
{
    public class User
    {
        public delegate int RemoveDelegate(string key);
        private string[] _keys;
        private string _name = string.Empty;
        private int _age;
        private int _numKeys = 0;

        public string Name { get => _name.ToUpper(); }
        public int Code { get => GetCode(); }
        public int Age { get => _age; }
        public int KeyCount { get => _keys.Length; }

        public User(int maxKeys, int age)
        {
            if (age <= 0 || age > 150)
            {
                throw new Exception();
            }
            if (maxKeys < 1)
            {
                throw new Exception();
            }

            _age = age;
            _keys = new string[maxKeys];
        }

        public int GetCode()
        {
            int result = 0;
            int aux;
            foreach (char character in _name)
            {
                aux = Convert.ToInt32(character);
                result += aux;
            }
            result = (result +_age) * 33;
            return result;
        }

        public void SetName(string name)
        {
            if (name == string.Empty || name == null)
            {
                throw new Exception();
            }
            _name = name;
        }

        public void AddKey(string key)
        {
            if (key == string.Empty || key == null)
            {
                throw new Exception();
            }

            if (_numKeys <= KeyCount)
            {
                _keys[_numKeys] = key;
                _numKeys++;
            }
        }

        public void ClearKeys()
        {
            _keys = new string[KeyCount];
            _numKeys = 0;
        }

        public bool ContainsKey(string findKey)
        {
            return (IndexOf(findKey) != -1);
        }

        public void RemoveKeys(RemoveDelegate found)
        {
            string[] _auxArray = new string[KeyCount];
            int i = 0;

            foreach (string key in _keys) 
            {
                if (found(key) == 1)
                {
                    _numKeys--;
                    continue;
                }

                _auxArray[i] = key;
                i++;
            }
            _keys = _auxArray;
        }

        public int IndexOf(string findKey)
        {
            if (findKey == string.Empty || findKey == null)
            {
                throw new Exception();
            }
            for (int i = 0; i < _numKeys; i++)
            {
                if (_keys[i] == findKey)
                    return i;
            }
            return -1;
        }
    }
}
