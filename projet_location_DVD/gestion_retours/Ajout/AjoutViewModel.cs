using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_location_DVD.gestion_retours.Ajout
{
    internal class AjoutViewModel
    {
        public ObservableCollection<location> retourList { get; set; }

        public AjoutViewModel()
        {
            retourList = GetAllDVDs();

        }
        public ObservableCollection<location> GetAllDVDs()
        {
            ObservableCollection<location> dvs = new ObservableCollection<location>();
            // Chaîne de connexion        
            string connectionString =
            "server=localhost;database=dvdexempleb;uid=root;pwd=;";
            // Créer une connexion à la base de données
            string query = "SELECT * FROM location";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer un objet Command
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    // Ouvrir la connexion
                    connection.Open();
                    // Exécuter la requête SQL et récupérer les données dans un DataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcourir les lignes de données
                        while (reader.Read())
                        {
                            // Récupérer les valeurs des colonnes de la ligne actuelle
                            int LocationId = reader.GetInt32(0);
                            int LeClient = reader.GetInt32(1);
                            int LeDVD = reader.GetInt32(2);
                            DateTime dateRented = reader.GetDateTime(3);
                            DateTime dateReturned = reader.GetDateTime(4);

                            location dvd = new location { LocationId = LocationId, LeClient = LeClient, LeDVD = LeDVD, dateRented = dateRented, dateReturned = dateReturned };
                            dvs.Add(dvd);

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
            return dvs;

        }

    }
}
