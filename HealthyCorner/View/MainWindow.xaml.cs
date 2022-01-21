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

namespace HealthyCorner.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Model.ModelTemplate model = new Model.ModelTemplate();
            string hariIni = DateTime.Now.ToString("ddd, dd MMMM yyyy");
            lblTanggalHariIni.Content = hariIni;
            lbljudul.Content = "Home Page";
            frmMain.Navigate(new View.HomePage());

        }
        private void dataUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MenuPengguna.Visibility == Visibility.Visible)
            {
                MenuPengguna.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuPengguna.Visibility = Visibility.Visible;
            }
        }

        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbljudul.Content = "Home Page";
            frmMain.Navigate(new View.HomePage());
        }

        private void Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Pemeriksaan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbljudul.Content = "Pemeriksaan Rutin";
            frmMain.Navigate(new View.PemeriksaanRutin());
        }

        private void lblLogout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void lblAkunPengguna_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GantiAkun gantiAkun = new GantiAkun();
            gantiAkun.Show();
            this.Close();
        }

        private void Record_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbljudul.Content = "Record Klinis";
            frmMain.Navigate(new View.RiwayatKliniz());
        }

        private void Agenda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbljudul.Content = "Agenda";
            frmMain.Navigate(new View.Agenda());
        }

        private void Kalkulator_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbljudul.Content = "Kalkulator";
            frmMain.Navigate(new View.Pemeriksaan());
        }
    }
}
