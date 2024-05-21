using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListView
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brief { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string NameBrief => Name + Brief;
        public int Ranking { get; set; } = 1;

        public Visibility Visible1 => Ranking >= 1 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility Visible2 => Ranking >= 2 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility Visible3 => Ranking >= 3 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility Visible4 => Ranking >= 4 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility Visible5 => Ranking >= 5 ? Visibility.Visible : Visibility.Collapsed;
    }

    public interface IStudentListener
    {
        void OnStudentSelected(Student student);
    }
}
