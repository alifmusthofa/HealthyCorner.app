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
    /// Interaction logic for PemeriksaanRutinAwal.xaml
    /// </summary>
    public partial class PemeriksaanRutinAwal : Page
    {
        public static string id = "";
        public static string tanggal = "";
        public static string guladarah = "";
        public static string tekanandarah = "";
        public static string detakjantung = "";
        public static string asamurat = "";
        public static string kolesterol = "";
        public static string suhubadan = "";

        Controller.PemeriksaanKontroller pemeriksaan;
        public string idHapus = "0";
        public PemeriksaanRutinAwal()
        {
            InitializeComponent();
            pemeriksaan = new Controller.PemeriksaanKontroller(this);
            pemeriksaan.DataPemeriksaan2();
        }

        private void imgview_Click(object sender, RoutedEventArgs e)
        {
            id = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["ID"].ToString();
            tanggal = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["Tanggal"].ToString();
            guladarah = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["GulaDarah"].ToString();
            tekanandarah = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["TekananDarah"].ToString();
            detakjantung = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["DetakJantung"].ToString();
            kolesterol = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["AsamUrat"].ToString();
            asamurat = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["Kolesterol"].ToString();
            suhubadan = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["SuhuBadan"].ToString();

            NavigationService.Navigate(new PemeriksaanRutinAkhir());

        }
        private void imgdelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string nama = "0";
                string str = ((DataRowView)dgrpemeriksaan.SelectedItem).Row["ID"].ToString();
                nama = str.ToString();
                idHapus = nama;
                pemeriksaan.HapusRiwayatpemeriksaan();
                pemeriksaan.DataPemeriksaan2();
            }
            
        }

        private void btnsimpan_Click(object sender, RoutedEventArgs e)
        {
            if (dtpTanggal.Text == "")
            {
                MessageBox.Show("Maaf data tanggal belum dimasukan");
            }
            else
            {
                pemeriksaan.TambahRiwayatPemeriksaan();
                pemeriksaan.DataPemeriksaan2();
            }
            
        }
    }
}
