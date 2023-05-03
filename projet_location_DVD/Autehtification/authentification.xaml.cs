using projet_location_DVD.Inscription;
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
    /// Logique d'interaction pour authentification.xaml
    /// </summary>
    public partial class authentification : Window
    {
        Usermodelvieuw userViewModel;
        public authentification()
        {
            InitializeComponent();
            userViewModel = new Usermodelvieuw();
            DataContext = userViewModel;


        }

        private void connection_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string pass = pwd.Password;
            Users uConnected = userViewModel.ConnectUser(login, pass);
            if (uConnected != null)
            {
                nom_du_users.connectedUser = uConnected;
                Menu dv = new Menu();
                dv.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found");
            }

        }

        private void inscrip(object sender, RoutedEventArgs e)
        {
            inscription_DB dv = new inscription_DB();
            dv.ShowDialog();
        }
    }
}
