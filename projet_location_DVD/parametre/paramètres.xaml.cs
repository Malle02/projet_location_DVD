using projet_location_DVD.gestion_retours.Supprimer;
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
    /// Logique d'interaction pour paramètres.xaml
    /// </summary>
    public partial class paramètres : Window
    {
        public paramètres()
        
            {
                InitializeComponent();
            }

            private void BackgroundColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ComboBoxItem cbi = (ComboBoxItem)BackgroundColorComboBox.SelectedItem;
                string color = cbi.Content.ToString();

                switch (color)
                {
                    case "White":
                        Background = Brushes.White;
                        break;
                    case "LightGray":
                        Background = Brushes.LightGray;
                        break;
                    case "LightBlue":
                        Background = Brushes.LightBlue;
                        break;
                    default:
                        break;
                }
            }

            private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (DevTextBlock != null && FontFamilyComboBox.SelectedItem != null)
                {
                    string fontFamily = ((ComboBoxItem)FontFamilyComboBox.SelectedItem).Content.ToString();
                    DevTextBlock.FontFamily = new FontFamily(fontFamily);
                }
                ComboBoxItem cbi = (ComboBoxItem)FontFamilyComboBox.SelectedItem;
                string font = cbi.Content.ToString();
                DevTextBlock.FontFamily = new FontFamily(font);
            }

            private void FontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                double value = e.NewValue;
                DevTextBlock.FontSize = value;
            }

            private void InfoButton_Click(object sender, RoutedEventArgs e)
            {


                DevTextBlock.Visibility = Visibility.Visible;

                information ad = new information();
                ad.ShowDialog();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Modifications enregistrées!");
            }
        }
    }

