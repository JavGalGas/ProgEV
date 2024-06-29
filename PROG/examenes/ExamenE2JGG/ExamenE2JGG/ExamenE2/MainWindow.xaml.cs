using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ExamenE2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private const int TotalCells = 63;
        private const int Rows = 9;
        private const int Columns = 7;
        private Rectangle[]? _cells;
        private Game game = new Game();
        private const string connectionString = "Data Source=test.db";

        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();
            GooseGameDB();
            //CleanEmptyGames();
        }

        //private void CleanEmptyGames()
        //{
        //    try
        //    {
        //        using (var connection = new SqliteConnection(connectionString))
        //        {
        //            connection.Open();

        //            string deleteQuery = "DELETE FROM partidas WHERE partida = '{}'";
        //            using (var command = new SqliteCommand(deleteQuery, connection))
        //            {
        //                command.ExecuteNonQuery();
        //                Console.WriteLine("Empty game entries removed successfully.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error cleaning empty games: " + ex.Message);
        //    }
        //}

        private void GooseGameDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Crear una tabla
                string createTableQuery = "CREATE TABLE IF NOT EXISTS partidas (id INTEGER PRIMARY KEY AUTOINCREMENT, partida TEXT)";
                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveGame()
        {
            try
            {
                GameState? gameState = game.GetGameState();
                if ( gameState == null)
                {
                    return;
                }
                string partida = GameStateToJson(gameState);

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO partidas (partida) VALUES (@partida)";
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@partida", partida);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected != 1)
                        {
                            // Handle potential issue with insert operation (e.g., logging error)
                            Console.WriteLine("Error saving game: Unexpected number of rows affected.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle general exception from GetGameState or other potential issues
                Console.WriteLine("Error saving game: " + ex.Message);
            }
        }

        private void LoadGame()
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    if (connection == null || connection.State != ConnectionState.Open)
                    {
                        // Handle scenario where connection is not open as expected
                        Console.WriteLine("Error loading game: Database connection is not open.");
                        return;
                    }

                    // Read saved games from the database
                    string selectQuery = "SELECT partida FROM partidas";
                    using (var command = new SqliteCommand(selectQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            // Handle no saved games found
                            Console.WriteLine("No saved games found.");
                            return;
                        }

                        // Create a list to store saved game data
                        List<GameState> savedGames = new List<GameState>();

                        while (reader.Read())
                        {
                            string partidaJson = reader.GetString(0);
                            GameState? gameState = JsonToGameState(partidaJson);

                            savedGames.Add(gameState!);
                        }

                        // Show the saved game selection window
                        SavedGameSelectionWindow selectionWindow = new SavedGameSelectionWindow(savedGames);
                        selectionWindow.ShowDialog();

                        // If a game was selected, load it
                        if (selectionWindow.SelectedGame != null)
                        {
                            LoadGameFromState(selectionWindow.SelectedGame);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine("Error loading game: " + ex.Message);
            }
        }

        private void LoadGameFromState(GameState gameState)
        {
            // Reset the game state
            game = new Game();
            CreateBoard();

            // Recreate players based on their saved state
            foreach (PlayerState playerState in gameState.State)
            {
                Player player;

                switch (playerState.PlayerType)
                {
                    case "NORMAL":
                        player = new PlayerNormal(playerState.Name);
                        player.SetPlayerPosition(playerState.BoxPosition, game);
                        break;
                    case "QUICK":
                        player = new PlayerQuick(playerState.Name, playerState.DiceBonus);
                        player.SetPlayerPosition(playerState.BoxPosition, game);
                        break;
                    case "CHEATER":
                        player = new PlayerCheater(playerState.Name);
                        player.SetPlayerPosition(playerState.BoxPosition, game);
                        break;
                    default:
                        player = new PlayerNormal(playerState.Name); // Default to Normal if type unknown
                        player.SetPlayerPosition(playerState.BoxPosition, game);
                        break;
                }
                game.AddPlayer(player);
            }

            // Update the UI to reflect the loaded game
            UpdateBoard();
        }

        private void CreateGame()
        {
            game = new Game();
            Player p = new PlayerNormal("Player A");
            Player p2 = new PlayerQuick("Player B", Utils.GetRandomBetween(1, 3));
            Player p3 = new PlayerCheater("Player C");
            Player p4 = new PlayerNormal("Player D");

            game.AddPlayer(p);
            game.AddPlayer(p2);
            game.AddPlayer(p3);
            game.AddPlayer(p4);            
        }

        private void SimulateGame()
        {
            CreateBoard();
            Player winner = game.Simulate();
            UpdateBoard();
            TextBlockWinner.Text = TextBlockWinner.Text + winner.Name;
        }

        private void UpdateBoard()
        {
            foreach (var player in game.Players)
            {
                game.VisitBoxField(box =>
                {
                    if (box.Equals(player.Box))
                    {
                        int cell = box.BoxPosition -1;
                        Grid cellContainer = new Grid();
                        Rectangle rectangle = new Rectangle
                        {
                            Name = $"Rectangle{cell + 1}",
                            Stroke = Brushes.Black,
                            Fill = Brushes.Yellow,
                        };

                        TextBlock rectangleName = new TextBlock
                        {
                            Text = $"{player.Name}",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        cellContainer.Children.Add(rectangle);
                        cellContainer.Children.Add(rectangleName);
                        _cells![cell] = rectangle;

                        // Convert cell number to row and column
                        int row = cell / Columns;
                        int column = cell % Columns;

                        // Alternating the direction for every other row to create the zigzag pattern
                        if (row % 2 == 1)
                        {
                            column = Columns - 1 - column;
                        }

                        Grid.SetRow(cellContainer, row);
                        Grid.SetColumn(cellContainer, column);
                        BoardGrid.Children.Add(cellContainer);
                    }
                });
            }
        }

        public static string GameStateToJson(GameState state)
        {
            string jsonString = JsonSerializer.Serialize(state);
            return jsonString;
        }

        public static GameState? JsonToGameState(string jsonString)
        {
            GameState? gameState = JsonSerializer.Deserialize<GameState>(jsonString);
            return gameState;
        }

        private void CreateBoard()
        {
            _cells = new Rectangle[TotalCells];

            for (int cell = 0; cell < TotalCells; cell++)
            {
                Grid cellContainer = new Grid();
                Rectangle rectangle = new Rectangle
                {
                    Name = $"Rectangle{cell + 1}",
                    Stroke = Brushes.Black,
                    Fill = FillColor(cell + 1),
                };

                TextBlock rectangleName = new TextBlock
                {
                    Text = $"{cell + 1}",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                cellContainer.Children.Add(rectangle);
                cellContainer.Children.Add(rectangleName);
                _cells[cell] = rectangle;

                // Convert cell number to row and column
                int row = cell / Columns;
                int column = cell % Columns;

                // Alternating the direction for every other row to create the zigzag pattern
                if (row % 2 == 1)
                {
                    column = Columns - 1 - column;
                }

                Grid.SetRow(cellContainer, row);
                Grid.SetColumn(cellContainer, column);
                BoardGrid.Children.Add(cellContainer);
            }
        }

        private SolidColorBrush FillColor(int index)
        {
            if (index == 1)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (index % 6 == 0)
            {
                return new SolidColorBrush(Colors.White);
            }

            else if (index % 13 == 0)
            {
                return new SolidColorBrush(Colors.Purple);
            }

            else if (index == 8 || index == 14)
            {
                return new SolidColorBrush(Colors.Brown);
            }

            else if (index == 27 || index == 53)
            {
                return new SolidColorBrush(Colors.DimGray);
            }

            else if (index == 58)
            {
                return new SolidColorBrush(Colors.Black);
            }

            else if (index == 63)
            {
                return new SolidColorBrush(Colors.Red);
            }

            else
                return new SolidColorBrush(Colors.LightGray);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlockWinner.Text = "Winner:";
            SimulateGame();
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            LoadGame();
        }

        private void Button_Save_Click_1(object sender, RoutedEventArgs e)
        {
            SaveGame();
        }
    }
}
