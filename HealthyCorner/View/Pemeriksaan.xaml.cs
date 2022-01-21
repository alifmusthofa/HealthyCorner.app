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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyCorner.View
{
    /// <summary>
    /// Interaction logic for Pemeriksaan.xaml
    /// </summary>
    public partial class Pemeriksaan : Page
    {
        Controller.KalkulatorBMIKontroller bmi;
        Controller.KalkulatorKaloriKontroller kalori;
        public Pemeriksaan()
        {
            InitializeComponent();
            frmkalkulatorkalori.Navigate(new View.kalkulatorkaloripenjelasan());
            frmkalkulatorBMI.Navigate(new View.kalkulatorBMIpenjelasan());
        }

        private void btnKalorihitung_Click(object sender, RoutedEventArgs e)
        {
            if (txtkaloriTinggi.Text == "" || txtkaloriBerat.Text == "" || txtkaloriUmur.Text == "")
            {
                MessageBox.Show("Maaf ada bagian yang belum diinputkan");
            }
            else if (!Int32.TryParse(txtkaloriTinggi.Text, out var outParse) || !Int32.TryParse(txtkaloriBerat.Text, out var outParse1) || !Int32.TryParse(txtkaloriUmur.Text, out var outParse2))
            {
                MessageBox.Show("Maaf inputan harus berupa angka");
            }
            else
            {
                // Do what you want to do if numeric 
                kalori = new Controller.KalkulatorKaloriKontroller(this);
                kalori.HasilBMI();
                frmkalkulatorkalori.Navigate(new View.Kalkulatorkalorihasil());
            }
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void btnBMIhitung_Click(object sender, RoutedEventArgs e)
        {
            if (txtBMITinggi.Text == "" || txtBMIBerat.Text == "")
            {
                MessageBox.Show("Maaf ada bagian yang belum diinputkan");
            }
            else if (!Int32.TryParse(txtBMITinggi.Text, out var outParse) || !Int32.TryParse(txtBMIBerat.Text, out var outParse1))
            {
                MessageBox.Show("Maaf inputan harus berupa angka");
            }
            else
            {

                // Do what you want to do if numeric
                bmi = new Controller.KalkulatorBMIKontroller(this);
                bmi.HasilBMI();
                frmkalkulatorBMI.Navigate(new View.kalkulatorBMIhasil());
            }

        }

        private void txtkaloriTinggi_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBMITinggi_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtBMITinggi_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtBMITinggi_KeyUp(object sender, KeyEventArgs e)
        {
            
           
        }
    }
}
