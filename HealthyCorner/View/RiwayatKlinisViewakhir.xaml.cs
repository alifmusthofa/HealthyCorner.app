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
    /// Interaction logic for RiwayatKlinisViewakhir.xaml
    /// </summary>
    public partial class RiwayatKlinisViewakhir : Page
    {
        Controller.kliniskontroller kliniskontroller;
        public RiwayatKlinisViewakhir()
        {
            InitializeComponent();
            kliniskontroller = new Controller.kliniskontroller(this);

            lblid.Content = "ID Number : " + View.RiwayatKlinisViewAwal.id;
            txtpenyakit.Text = View.RiwayatKlinisViewAwal.penyakit;
            txtketeranganKlinis.Text = View.RiwayatKlinisViewAwal.keterangan;
            dtptanggal.Text = View.RiwayatKlinisViewAwal.tanggal;
        }

        

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            if (dtptanggal.Text == "")
            {
                MessageBox.Show("Maaf data tanggal belum dimasukan");
            }
            else
            {
                if (MessageBox.Show("Yakin ingin mengedit data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    kliniskontroller.UbahKlinis();
                    NavigationService.Navigate(new RiwayatKlinisViewAwal());
                }
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


    }
}
