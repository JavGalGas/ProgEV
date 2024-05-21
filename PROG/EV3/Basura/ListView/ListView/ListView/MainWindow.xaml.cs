using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IStudentListener
    {
        ObservableCollection<Student> _students = new ObservableCollection<Student>();
        Student? _currentStudent;

        public MainWindow()
        {
            InitializeComponent();

            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1", Avatar= "https://img.asmedia.epimg.net/resizer/v2/KUYWWFPNXVHSNH5IOUFD3NC22E.jpg?auth=611cfe3f84263d1fc2a947a7c723b6336e0df65d2be43aeff13f024fe578bed8" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2", Avatar = "https://img.asmedia.epimg.net/resizer/v2/KUYWWFPNXVHSNH5IOUFD3NC22E.jpg?auth=611cfe3f84263d1fc2a947a7c723b6336e0df65d2be43aeff13f024fe578bed8" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3", Avatar = "https://img.asmedia.epimg.net/resizer/v2/KUYWWFPNXVHSNH5IOUFD3NC22E.jpg?auth=611cfe3f84263d1fc2a947a7c723b6336e0df65d2be43aeff13f024fe578bed8" });
            _students.Add(new Student() { Id = 2, Name = "Star1", Brief = "Rob3", Ranking = 1 });
            _students.Add(new Student() { Id = 2, Name = "Star2", Brief = "Rob3", Ranking = 2 });
            _students.Add(new Student() { Id = 2, Name = "Star3", Brief = "Rob3", Ranking = 3 });
            _students.Add(new Student() { Id = 2, Name = "Star4", Brief = "Rob3", Ranking = 4 });
            _students.Add(new Student() { Id = 2, Name = "Star5", Brief = "Rob3", Ranking = 5 });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });


            ItemsPool.ItemsSource = _students;
        }

        public void OnStudentSelected(Student student)
        {
            _currentStudent = student;
            NameLabel.Content = student.Name;
        }
    }
}
