using projet_location_DVD.gestion_retours.Ajout;
using projet_location_DVD.gestion_retours.calcule;
using projet_location_DVD.gestion_retours.Modif;
using projet_location_DVD.gestion_retours.Supprimer;
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

using projet_location_DVD.client.Ajout_clt;
using projet_location_DVD.client.Supprimer_client;
using projet_location_DVD.client.Modifif_clt;

namespace projet_location_DVD.client
{
    /// <summary>
    /// Logique d'interaction pour client_dvd.xaml
    /// </summary>
    public partial class client_dvd : Window
    {
        clientViewModel clientview;
        public client_dvd()
        {
            InitializeComponent();
            clientview = new clientViewModel();
            DataContext = clientview;



        }


        private void add_click(object sender, RoutedEventArgs e)
        {
           ajout_client   add = new ajout_client();
            add.ShowDialog();
        }

        private void cltListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            client selectedDVD = (client)CltListView.SelectedItem;
            // dvdViewModel.DeleteDVD(selectedDVD);
            

            // teste 




            if (selectedDVD != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous modifier les informations concernant ce client ?", "Modifier l'élément", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    modification_client Modification_Client = new modification_client(selectedDVD);
                    Modification_Client.ShowDialog();
                    // actualiser la liste des retours après la modification
                    clientview.RefreshList();
                }
            }

        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as clientViewModel).RefreshList();
        }


        private void supp_click(object sender, RoutedEventArgs e)
        {
            supprim_client ad = new supprim_client();
            ad.ShowDialog();
        }


       



        private void Retours_click(object sender, RoutedEventArgs e)
        {
            Menu ad = new Menu();
            ad.Show();
            this.Close();
        }




    }

}
