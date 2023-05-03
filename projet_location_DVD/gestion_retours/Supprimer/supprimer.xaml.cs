using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace projet_location_DVD.gestion_retours.Supprimer
{
    /// <summary>
    /// Logique d'interaction pour supprimer.xaml
    /// </summary>
    public partial class supprimer : Window
    {
        public ObservableCollection<retours> Retours { get; set; }

        public supprimer()
        {
            InitializeComponent();

            Retours = new ObservableCollection<retours>();

            string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand("SELECT RetourId, LaLocation, DateReturned FROM retour", connection);

            try
            {
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    retours retour = new retours()
                    {
                        RetourId = (int)row["RetourId"],
                        LaLocation = (int)row["LaLocation"],
                        DateReturned = (DateTime)row["DateReturned"]
                    };
                    Retours.Add(retour);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            DataContext = this;
        }

        private void SupprimerSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (RetoursDataGrid.SelectedItems.Count > 0)
            {
                string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand("DELETE FROM retour WHERE RetourId = @RetourId", connection);
                command.Parameters.Add("@RetourId", MySqlDbType.Int32);

                try
                {
                    connection.Open();

                    List<retours> retoursToDelete = new List<retours>();

                    foreach (retours retour in RetoursDataGrid.SelectedItems)
                    {
                        command.Parameters["@RetourId"].Value = retour.RetourId;
                        command.ExecuteNonQuery();
                        retoursToDelete.Add(retour);
                    }

                    foreach (retours retour in retoursToDelete)
                    {
                        Retours.Remove(retour);
                    }

                    MessageBox.Show($"Suppression effectuée pour {retoursToDelete.Count} éléments !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez au moins un élément !");
            }
        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}