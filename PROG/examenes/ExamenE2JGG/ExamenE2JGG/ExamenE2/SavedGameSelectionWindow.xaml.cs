using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ExamenE2
{
    /// <summary>
    /// Lógica de interacción para SavedGameSelectionWindow.xaml
    /// </summary>
    public partial class SavedGameSelectionWindow : Window
    {
        public List<GameState> SavedGames { get; set; }
        public GameState? SelectedGame { get; private set; }

        public SavedGameSelectionWindow(List<GameState> savedGames)
        {
            InitializeComponent();

            SavedGames = savedGames;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(indexTextBox.Text, out int index) && index >= 0 && index < SavedGames.Count)
            {
                SelectedGame = SavedGames[index];
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid index. Please enter a non-negative number less than the total number of saved games.");
            }
        }
    }
}
