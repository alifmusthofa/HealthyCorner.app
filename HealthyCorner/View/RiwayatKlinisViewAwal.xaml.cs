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
using System.Data;

namespace HealthyCorner.View
{
    /// <summary>
    /// Interaction logic for RiwayatKlinisViewAwal.xaml
    /// </summary>
    public partial class RiwayatKlinisViewAwal : Page
    {
        public static string id = "";
        public static string tanggal = "";
        public static string penyakit = "";
        public static string keterangan = "";

        Controller.kliniskontroller kliniskontroller;
        public string idHapus = "0";

        
        public RiwayatKlinisViewAwal()
        {
            InitializeComponent();
            kliniskontroller = new Controller.kliniskontroller(this);
            kliniskontroller.Dataklinis2();
        }

        private void btnsimpan_Click(object sender, RoutedEventArgs e)
        {
            if (dtptanggal.Text == "")
            {
                MessageBox.Show("Maaf data tanggal belum dimasukan");
            }
            else
            {
                kliniskontroller.TambahRiwayatKlinis();
                kliniskontroller.Dataklinis2();
            }
 
        }

        private void imgdelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string nama = "0";
                string str = ((DataRowView)dgriwayatklinis.SelectedItem).Row["ID"].ToString();
                nama = str.ToString();
                idHapus = nama;
                kliniskontroller.HapusRiwayatKlinis();
                kliniskontroller.Dataklinis2();
            }
            

        }

        private void imgview_Click(object sender, RoutedEventArgs e)
        {
            
            id = ((DataRowView)dgriwayatklinis.SelectedItem).Row["ID"].ToString();
            tanggal = ((DataRowView)dgriwayatklinis.SelectedItem).Row["Tanggal"].ToString();
            penyakit = ((DataRowView)dgriwayatklinis.SelectedItem).Row["Penyakit"].ToString();
            keterangan = ((DataRowView)dgriwayatklinis.SelectedItem).Row["KeteranganKlinis"].ToString();

            NavigationService.Navigate(new RiwayatKlinisViewakhir());

        }
    }
}
