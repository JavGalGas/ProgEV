using Microsoft.VisualBasic;
using System;

namespace Classes
{
    public class DateTime
    {
        private int _year;
        private int _month;
        private int _day;
        private int _hour;
        private int _minute;
        private int _second;

        public DateTime()
        {
            _year = 0;
            _month = 1;
            _day = 1;
            _hour = 0;
            _minute = 0;
            _second = 0;
        }
        public DateTime(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }
        public DateTime(int hour, int minute, int second, int day, int month, int year)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
            _day = day;
            _month = month;
            _year = year;
        }
        public DateTime Clone()
        {
            return new DateTime(_hour, _minute, _second, _day, _month, _year);
        }
        public bool Equals(DateTime other)
        {
            return (_day == other._day && _month == other._month && _year == other._year && _hour == other._hour && _minute == other._minute && _second == other._second);
        }
        public bool IsValid()
        {
            if (_year < 0 || _month < 0 || _month > 12 || _day < 0 || _hour < 0 || _minute < 0 || _second < 0)
            {
                return false;
            }
            switch(_month)
            {
                case 2:
                    if (_day > 29 || (_day==29 && !IsLeap())) 
                    {
                        return false; 
                    }
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                case 11:
                        if (_day > 31) { return false; }
                        break;
                case 4:
                case 6:
                case 8:
                case 10:
                case 12:
                    if (_day > 30) { return false; }
                    break;     
            }
            if (_hour < 24 && _minute < 60 && _second < 60) 
            { 
                return true; 
            }
            return false;
        }
        public bool IsLeap()
        {
            return IsLeap(_year);
        }
        public static bool IsLeap(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 100 == 0 && year % 400 == 0);
        }
        
        public int GetYear()
        {
            return _year;
        }
        public int GetMonth()
        {
            return _month;
        }
        public int GetDay()
        {
            return _day;
        }
        public int GetHour()
        {
            return _hour;
        }
        public int GetMinute()
        {
            return _minute;
        }
        public int GetSecond()
        {
            return _second;
        }

        public string DateToString() // escribir la fecha --> (ejemplo): 13/11/2023
        {
            return _day + "/" + _month + "/" + _year + "| |" + PrintHour() + ":" + PrintMinute() + ":" + PrintSecond();
        }
        public string PrintHour()
        {
            if (_hour < 9)
                return "0" + _hour;
            return _hour.ToString();
        }
        public string PrintMinute()
        {
            if (_minute < 9)
                return "0" + _minute;
            return _minute.ToString();
        }
        public string PrintSecond() 
        { 
            if (_second < 9)
                return "0" + _second;
            return _second.ToString();
        }
        public static int GetDaysCount(int year, int month)
        {
            if (month == 3 || month == 5 || month == 7 || month == 9 || month == 11)
                return 30;
            else if(month == 2)
                return IsLeap(year) ? 29 : 28;
            return 31;
        }
        public int GetDaysOfMonth()
        {
            return GetDaysCount(GetYear(), GetMonth());
        }
        public void IncrementDay()
        {
            _day++;
            if(!IsValid())
            {
                if(_month<=12)
                {
                    _day = 1;
                    _month++;
                }
                _day = 1;
                _month=1;
                _year++;
            }
        }
        public void IncrementSeconds()
        {
            _second++;
            if (!IsValid())
            {
                _second = 0;
                _minute++;
                if (_minute >= 60)
                {
                    _minute = 0;
                    _hour++;
                }
                else if (_hour >= 24)
                {
                    _hour = 0;
                    IncrementDay();
                }
            }
        }
        public void Correct()
        {
            while(_second>=60)
            {
                _second = _second - 60;
                _minute++;
            }
            while(_minute>=60)
            {
                _minute = _minute - 60;
                _hour++;
            }
            while(_hour>=24)
            {
                _hour=_hour - 24;
                _day++;
            }
            while(_day>GetDaysCount(_year, _month))
            {
                _day = _day - GetDaysCount(_year, _month);
                _month++;
            }
            while(_month>12)
            {
                _month = _month - 12;
                _year++;
            }
        }
        public int monthCode()
        {
            switch(GetMonth())
            {
                case 1:
                case 10:
                    return 6;
                case 2:
                case 3:
                case 11:
                    return 2;
                case 4:
                case 7:
                    return 5;
                case 5:
                    return 0;
                case 6:
                    return 3;
                case 9:
                case 12:
                    return 4;
            }
            return 1;
        }
        public int GetLeapCountBetween(int value1, int value2)
        {
            int count = 0;
            for(int i = value1; i <= value2; i++)
            {
                if(IsLeap(i))
                    count++;
            }
            return count;
        }
        public int yearCode()
        {
            int i = GetYear();
            int leap = i / 400;
            int notLeap = (i / 100) - leap;
            int aux = i - (leap + notLeap) * 100;
            int aux2 = aux / 12;
            int aux3 = aux % 12;
            int aux4 = aux3 + GetLeapCountBetween(GetYear() - aux3, GetYear());
            int yearCode = aux4 + aux2;
            int century =34 - leap - (notLeap * 2);
            int code = yearCode%7 + century;
            return code;
        }
        public int weekCode()
        {
            int code = (GetDay() % 7) + monthCode() + yearCode();
            if (IsLeap() && (GetMonth()==1 || GetMonth()==2))
                code--;
            return code;
        }
        public DayOfWeek GetDayOfWeek()
        {
            switch(weekCode()%7)
            {
                case 0: return DayOfWeek.Sunday;
                case 1: return DayOfWeek.Monday;
                case 2: return DayOfWeek.Tuesday;
                case 3: return DayOfWeek.Wednesday;
                case 4: return DayOfWeek.Thursday;
                case 5: return DayOfWeek.Friday;
            }
            return DayOfWeek.Saturday;
        }
        public string GetNameOfDay()
        {
            return GetDayOfWeek().ToString();
        }
    }
}
