using MySql.Data.MySqlClient;
using projet_location_DVD.gestion_retours;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_location_DVD.client
{
   
    internal class clientViewModel
    {
        public ObservableCollection<client> CltList { get; set; }
        public clientViewModel() 
        {
            CltList = GetAllclients();

        }
        public ObservableCollection<client> GetAllclients()
        {
            ObservableCollection<client> dvs = new ObservableCollection<client>();
            // Chaîne de connexion        
            string connectionString =
            "server=localhost;database=dvdexempleb;uid=root;pwd=;";
            // Créer une connexion à la base de données
            string query = "SELECT * FROM  client";
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
                            int ClientId = reader.GetInt32(0);
                            string FirstName = reader.GetString(1);
                            string LastName = reader.GetString(2);
                            string Address = reader.GetString(3);
                            string PhoneNumber = reader.GetString(4);
                            
                        

        client dvd = new client { ClientId = ClientId, FirstName = FirstName, LastName = LastName, Address = Address, PhoneNumber = PhoneNumber };
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

        public void UpdateRetours(client r)
        {
            // Chaîne de connexion        
            string connectionString = "server=localhost;database=dvdexempleb;uid=root;pwd=;";

            // Créer une connexion à la base de données
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer un objet Command
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE client SET FirstName = @FirstName, LastName = @LastName, Address = @Address, PhoneNumber = @PhoneNumber  WHERE ClientId = @ClientId";

                // Ajouter les paramètres de la requête
                command.Parameters.AddWithValue("@ClientId", r.ClientId);
                command.Parameters.AddWithValue("@FirstName", r.FirstName);
                command.Parameters.AddWithValue("@LastName", r.LastName);
                command.Parameters.AddWithValue("@Address", r.Address);
                command.Parameters.AddWithValue("@PhoneNumber", r.PhoneNumber);

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
            CltList.Clear();
            ObservableCollection<client> newList = GetAllclients();

            foreach (client d in newList)
            {
                CltList.Add(d);
            }
        }




        // test 









    }

}
