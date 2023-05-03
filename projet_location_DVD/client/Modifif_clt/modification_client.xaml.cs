using MySql.Data.MySqlClient;
using projet_location_DVD.gestion_retours;
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

namespace projet_location_DVD.client.Modifif_clt
{
    /// <summary>
    /// Logique d'interaction pour modification_client.xaml
    /// </summary>
    public partial class modification_client : Window
    {
        private client selectedDVD;
        private string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";

        public modification_client(client selectedDVD)
        {
            InitializeComponent();
            this.selectedDVD = selectedDVD;

            IdclientTextBox.Text = selectedDVD.ClientId.ToString();
            FirstNameTextBox.Text = selectedDVD.FirstName.ToString();
            LastNameTextBox.Text = selectedDVD.LastName.ToString();
            AddressTextBox.Text = selectedDVD.Address.ToString();
            PhoneNumberTextBox.Text = selectedDVD.PhoneNumber.ToString();
        }

        private void EnregistrerButton_Click(object sender, RoutedEventArgs e)
        {
            int clientId;
            string firstName;
            string lastName;
            string address;
            string phoneNumber;

            if (int.TryParse(IdclientTextBox.Text, out clientId) &&
                !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(LastNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(AddressTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                firstName = FirstNameTextBox.Text;
                lastName = LastNameTextBox.Text;
                address = AddressTextBox.Text;
                phoneNumber = PhoneNumberTextBox.Text;

                selectedDVD.ClientId = clientId;
                selectedDVD.FirstName = firstName;
                selectedDVD.LastName = lastName;
                selectedDVD.Address = address;
                selectedDVD.PhoneNumber = phoneNumber;

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE client SET FirstName=@FirstName, LastName=@LastName, Adresse=@Address, PhoneNumber=@PhoneNumber WHERE ClientId=@ClientId";
                        command.Parameters.AddWithValue("@ClientId", selectedDVD.ClientId);
                        command.Parameters.AddWithValue("@FirstName", selectedDVD.FirstName);
                        command.Parameters.AddWithValue("@LastName", selectedDVD.LastName);
                        command.Parameters.AddWithValue("@Address", selectedDVD.Address);
                        command.Parameters.AddWithValue("@PhoneNumber", selectedDVD.PhoneNumber);
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














    