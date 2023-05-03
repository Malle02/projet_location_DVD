using projet_location_DVD.client;
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

namespace projet_location_DVD
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        menuviewModel menuviewModel;
        public Menu()
        {
            InitializeComponent();
            menuviewModel = new menuviewModel();
            DataContext = menuviewModel;
            if (nom_du_users.connectedUser != null)
            {
                wUser.Content = "Welcome " + nom_du_users.connectedUser.UserId;
            }
        }

        // gestion des retours
        private void Gest_Retour(object sender, RoutedEventArgs e)
        {
            Gestion_des_retours dv = new Gestion_des_retours();
            dv.Show();
            this.Close();
        }

        // gestion des client
        private void ges_client(object sender, RoutedEventArgs e)
        {
            client_dvd dv = new client_dvd();
            dv.Show();
            this.Close();
        }

        //gestion des dvd 
        private void ges_DVD(object sender, RoutedEventArgs e)
        {
            Gestion_de_DVD dv = new Gestion_de_DVD();
            dv.Show();
            this.Close();
        }


        //gestion des location
        private void ges_loca(object sender, RoutedEventArgs e)
        {
            gestion_des_locations dv = new gestion_des_locations();
            dv.Show();
            this.Close();
        }



        // paramètre
        private void parame_click(object sender, RoutedEventArgs e)
        {
            paramètres dv = new paramètres();
            dv.ShowDialog();
            
        }

        //statistique 
        private void Statis_click(object sender, RoutedEventArgs e)
        {
            statistiques dv = new statistiques();
            dv.ShowDialog();
        }

        // deconnexion
        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Rediriger l'utilisateur vers la page d'authentification
                authentification loginPage = new authentification();
                loginPage.Show();

                // Fermer la fenêtre actuelle
                this.Close();

            }
        }

    }
}
