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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Ici, vous pouvez mettre votre logique de chargement, comme par exemple
            // charger des données depuis un service web, lire un fichier, etc.
            // Vous pouvez également mettre une Task.Delay pour simuler un chargement.

            for (int i = 0; i <= 100; i++)
            {
                Progression.Value = i;
                pourcentage.Text = $"{i}%"; // Mettre à jour le texte du label
                await Task.Delay(50);
            }

            // Une fois le chargement terminé, vous pouvez afficher la page principale de l'application
            // en masquant la page de chargement et en affichant la page du menu.

            var menuWindow = new authentification(); // Créer une instance de la fenêtre "Menu.xaml"
            menuWindow.Show(); // Afficher la fenêtre "Menu.xaml"
            Close(); // Fermer la fenêtre de chargement (MainWindow)
        }
    }
}