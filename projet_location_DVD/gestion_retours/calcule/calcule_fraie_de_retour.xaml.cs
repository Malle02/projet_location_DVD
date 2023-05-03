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

namespace projet_location_DVD.gestion_retours.calcule
{
    /// <summary>
    /// Logique d'interaction pour calcule_fraie_de_retour.xaml
    /// </summary>
    public partial class calcule_fraie_de_retour : Window
    {
        private const double LateFeeRate = 4.00; // Frais de retard par jour en euros
        public calcule_fraie_de_retour()
        {
            InitializeComponent();

        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime rentalDate = RentalDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime returnDate = ReturnDatePicker.SelectedDate ?? DateTime.MinValue;

            if (rentalDate == DateTime.MinValue || returnDate == DateTime.MinValue)
            {
                MessageBox.Show("Veuillez sélectionner les dates de location et de retour.");
                return;
            }

            int rentalDays = (int)(returnDate - rentalDate).TotalDays;
            rentalDays = (rentalDays >= 0) ? rentalDays : 0;

            double rentalPrice = rentalDays * LateFeeRate;

            RentalDaysTextBox.Text = rentalDays.ToString();
            RentalPriceTextBox.Text = rentalPrice.ToString("C2");

            int lateDays = (DateTime.Now > returnDate) ? (int)(DateTime.Now - returnDate).TotalDays : 0;
            double lateFee = lateDays * LateFeeRate;

            LateFeeTotalTextBox.Text = lateFee.ToString("C2");
        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

   
}
