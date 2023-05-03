using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_location_DVD
{
    internal class Usermodelvieuw
    {
        public Usermodelvieuw() 
        {
            
        }
        public Users ConnectUser(String login, String pwd)
        {
            string connectionString =
            "server=localhost;database=dvdexempleb;uid=root;pwd=;";
            // Créer une connexion à la base de données


            string query = "SELECT * FROM User where Username= '" + login + "' and Password = '" + pwd + "'";
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
                            int uId = reader.GetInt32(0);
                            string uName = reader.GetString(1);
                            string pWord = reader.GetString(2);
                            string isAdmin = reader.GetString(3);

                            Users userConnected = new Users { UserId = uId, Username = uName, Password = pWord, IsAdmin = isAdmin };
                            return userConnected;
                        }


                    }
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
            return null;
        }

    }
}
