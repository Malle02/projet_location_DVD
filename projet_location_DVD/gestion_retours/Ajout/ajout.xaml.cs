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

namespace projet_location_DVD.gestion_retours.Ajout
{
    /// <summary>
    /// Logique d'interaction pour ajout.xaml
    /// </summary>
    public partial class ajout : Window


    {
        AjoutViewModel ajoutViewModel;

        private string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";

        public ajout()
        {
            InitializeComponent();
            ajoutViewModel = new AjoutViewModel();
            DataContext = ajoutViewModel;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int retourId;
            int laLocation;
            DateTime dateReturned;

            if (int.TryParse(RetourIdTextBox.Text, out retourId) &&
                int.TryParse(LaLocationTextBox.Text, out laLocation) &&
                DateTime.TryParse(DateReturnedTextBox.Text, out dateReturned))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "insert into retour (RetourId, LaLocation, DateReturned) values (@RetourId, @LaLocation, @DateReturned)";
                        command.Parameters.AddWithValue("@RetourId", retourId);
                        command.Parameters.AddWithValue("@LaLocation", laLocation);
                        command.Parameters.AddWithValue("@DateReturned", dateReturned);
                        command.ExecuteNonQuery();
                    }


                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la mise à jour des données : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Les valeurs saisies ne sont pas valides", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
