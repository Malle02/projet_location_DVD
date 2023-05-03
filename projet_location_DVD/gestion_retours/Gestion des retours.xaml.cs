using projet_location_DVD.gestion_retours;
using projet_location_DVD.gestion_retours.Ajout;
using projet_location_DVD.gestion_retours.calcule;
using projet_location_DVD.gestion_retours.Modif;
using projet_location_DVD.gestion_retours.Supprimer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour Gestion_des_retours.xaml
    /// </summary>
    public partial class Gestion_des_retours : Window
    {

        RetoursViewModel dvdViewModel;
        public Gestion_des_retours()
        {
            InitializeComponent();
            dvdViewModel = new RetoursViewModel();
            DataContext = dvdViewModel;



        }


        private void add_click(object sender, RoutedEventArgs e)
        {
           ajout ad = new ajout();
            ad.ShowDialog();
        }

        private void DVDListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            retours selectedDVD = (retours)DVDListView.SelectedItem;
            // dvdViewModel.DeleteDVD(selectedDVD);


            // teste 




            if (selectedDVD != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous modifier les informations concernant ce retour ?", "Modifier l'élément", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ModificationWindow modificationWindow = new ModificationWindow(selectedDVD);
                    modificationWindow.ShowDialog();
                    // actualiser la liste des retours après la modification
                    dvdViewModel.RefreshList();
                }
            }

        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RetoursViewModel).RefreshList();
        }


        private void supp_click(object sender, RoutedEventArgs e)
        {
            supprimer ad = new supprimer();
            ad.ShowDialog();
        }


        private void calc_click(object sender, RoutedEventArgs e)
        {
            calcule_fraie_de_retour ad = new calcule_fraie_de_retour();
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
