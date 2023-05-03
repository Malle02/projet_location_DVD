using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace projet_location_DVD.gestion_retours
{
    internal class RetoursViewModel
    {
        public ObservableCollection<retours> DVDList { get; set; }

        public RetoursViewModel()
        {
            DVDList = GetAllretourss();

        }
        public ObservableCollection<retours> GetAllretourss()
        {
            ObservableCollection<retours> dvs = new ObservableCollection<retours>();
            // Chaîne de connexion        
            string connectionString =
            "server=localhost;database=dvdexempleb;uid=root;pwd=;";
            // Créer une connexion à la base de données
            string query = "SELECT * FROM  retour";
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
                            int RetourId = reader.GetInt32(0);
                            int LaLocation = reader.GetInt32(1);
                            DateTime DateReturned = reader.GetDateTime(2);

                            retours dvd = new retours { RetourId = RetourId, LaLocation = LaLocation, DateReturned = DateReturned };
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
        //  public void DeleteDVD(retours d)
        // {
        //   DVDList.Remove(DVDList.Where(i => i.RetourId == d.RetourId).Single());
        //}

        public void UpdateRetours(retours r)
        {
            // Chaîne de connexion        
            string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";

            // Créer une connexion à la base de données
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer un objet Command
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE retour SET LaLocation = @LaLocation, DateReturned = @DateReturned WHERE RetourId = @RetourId";

                // Ajouter les paramètres de la requête
                command.Parameters.AddWithValue("@RetourId", r.RetourId);
                command.Parameters.AddWithValue("@LaLocation", r.LaLocation);
                command.Parameters.AddWithValue("@DateReturned", r.DateReturned);

                try
                {
                    // Ouvrir la connexion
                    connection.Open();
                    // Exécuter la requête SQL et récupérer le nombre de lignes modifiées
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " ligne(s) modifiée(s).");
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

        }
        public void RefreshList()
        {
            DVDList.Clear();
            ObservableCollection<retours> newList = GetAllretourss();

            foreach (retours d in newList)
            {
                DVDList.Add(d);
            }
        }




        // test 









    }

}
