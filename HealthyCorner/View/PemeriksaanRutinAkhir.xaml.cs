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
    /// Interaction logic for PemeriksaanRutinAkhir.xaml
    /// </summary>
    public partial class PemeriksaanRutinAkhir : Page
    {
        Controller.PemeriksaanKontroller PemeriksaanKontroller;
        public PemeriksaanRutinAkhir()
        {
            InitializeComponent();
            PemeriksaanKontroller = new Controller.PemeriksaanKontroller(this);

            lblid.Content = "ID Number : " + View.PemeriksaanRutinAwal.id;
            txtguladarah.Text = View.PemeriksaanRutinAwal.guladarah;
            txtDetakJantung.Text = View.PemeriksaanRutinAwal.detakjantung;
            txtkolesterol.Text = View.PemeriksaanRutinAwal.kolesterol;
            txtasamUrat.Text = View.PemeriksaanRutinAwal.asamurat;
            txtSuhuBadan.Text = View.PemeriksaanRutinAwal.suhubadan;

            int posisi = View.PemeriksaanRutinAwal.tekanandarah.IndexOf('/');
            if(posisi == 1)
            {
                txtTekananDarah1.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(0,1);
                txtTekananDarah2.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(2);
            }else if (posisi == 2)
            {
                txtTekananDarah1.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(0, 2);
                txtTekananDarah2.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(3);
            }
            else
            {
                txtTekananDarah1.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(0, 3);
                txtTekananDarah2.Text = View.PemeriksaanRutinAwal.tekanandarah.Substring(4);
            }



            dtpTanggal.Text = View.PemeriksaanRutinAwal.tanggal;
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            if (dtpTanggal.Text == "")
            {
                MessageBox.Show("Maaf data tanggal belum dimasukan");
            }
            else
            {
                if (MessageBox.Show("Yakin ingin mengedit data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    PemeriksaanKontroller.UbahPemeriksaan();
                    NavigationService.Navigate(new PemeriksaanRutinAwal());
                }
            }
            

        }
    }
}
