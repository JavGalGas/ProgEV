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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> _students = new ObservableCollection<Student>();
        Student? _currentStudent;
        public MainWindow()
        {
            InitializeComponent();
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 0, Name = "Roberto1", Brief = "Rob1" });
            _students.Add(new Student() { Id = 1, Name = "Roberto2", Brief = "Rob2" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });
            _students.Add(new Student() { Id = 2, Name = "Roberto3", Brief = "Rob3" });

            _students.Se

            ItemsPool.ItemsSource = _students;
        }

        internal void SetCurrentException(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
