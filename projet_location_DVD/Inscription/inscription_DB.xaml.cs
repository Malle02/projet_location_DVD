using MySql.Data.MySqlClient;
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

namespace projet_location_DVD.Inscription
{
    /// <summary>
    /// Logique d'interaction pour inscription_DB.xaml
    /// </summary>
    public partial class inscription_DB : Window
    {
        public inscription_DB()
        {
            InitializeComponent();
        }

        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = pwd.Password;

            // Vérifier que tous les champs ont été remplis
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs vides", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Créer une connexion à la base de données
                string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Vérifier si l'utilisateur existe déjà dans la base de données
                    string checkQuery = "SELECT COUNT(*) FROM User WHERE Username=@username";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@username", login);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("L'utilisateur existe déjà dans la base de données.", "Utilisateur existant", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    // Ajouter l'utilisateur à la base de données
                    string insertQuery = "INSERT INTO User (Username, Password) VALUES (@username, @password)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@username", login);
                        insertCommand.Parameters.AddWithValue("@password", password);
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("L'utilisateur a été ajouté à la base de données.", "Inscription réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                            Login.Clear();
                            pwd.Clear();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("L'utilisateur n'a pas été ajouté à la base de données.", "Erreur d'inscription", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'inscription. Veuillez réessayer plus tard." + Environment.NewLine + "Erreur : " + ex.Message, "Erreur d'inscription", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}