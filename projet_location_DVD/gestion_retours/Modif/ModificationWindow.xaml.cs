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

namespace projet_location_DVD.gestion_retours.Modif
{
    /// <summary>
    /// Logique d'interaction pour ModificationWindow.xaml
    /// </summary>
    public partial class ModificationWindow : Window
    {
        private retours selectedDVD;
        private string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";

        public ModificationWindow(retours selectedDVD)
        {
            InitializeComponent();
            this.selectedDVD = selectedDVD;
            RetourIdTextBox.Text = selectedDVD.RetourId.ToString();
            LaLocationTextBox.Text = selectedDVD.LaLocation.ToString();
            DateReturnedTextBox.Text = selectedDVD.DateReturned.ToString();
        }

        private void EnregistrerButton_Click(object sender, RoutedEventArgs e)
        {
            int retourId;
            int laLocation;
            DateTime dateReturned;

            if (int.TryParse(RetourIdTextBox.Text, out retourId) &&
                int.TryParse(LaLocationTextBox.Text, out laLocation) &&
                DateTime.TryParse(DateReturnedTextBox.Text, out dateReturned))
            {
                selectedDVD.RetourId = retourId;
                selectedDVD.LaLocation = laLocation;
                selectedDVD.DateReturned = dateReturned;

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE  retour SET LaLocation=@LaLocation, DateReturned=@DateReturned WHERE RetourId=@RetourId";
                        command.Parameters.AddWithValue("@RetourId", selectedDVD.RetourId);
                        command.Parameters.AddWithValue("@LaLocation", selectedDVD.LaLocation);
                        command.Parameters.AddWithValue("@DateReturned", selectedDVD.DateReturned);
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
