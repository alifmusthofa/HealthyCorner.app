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
    /// Interaction logic for AgendaAwal.xaml
    /// </summary>
    public partial class AgendaAwal : Page
    {
        public static string id = "";
        public static string tanggal = "";
        public static string agenda = "";
        public static string catatan = "";

        Controller.agendaKontroller agendaKontroller;
        public string idHapus = "0";
        public AgendaAwal()
        {
            InitializeComponent();
            agendaKontroller = new Controller.agendaKontroller(this);
            agendaKontroller.DataAgenda2();
        }
        private void btnsimpan_Click(object sender, RoutedEventArgs e)
        {
            if (dtpTanggal.Text == "")
            {
                MessageBox.Show("Maaf data tanggal belum dimasukan");
            }
            else
            {
                agendaKontroller.TambahRiwayatAgenda();
                agendaKontroller.DataAgenda2();
            }

        }

        private void imgview_Click(object sender, RoutedEventArgs e)
        {
            id = ((DataRowView)dgragenda.SelectedItem).Row["ID"].ToString();
            tanggal = ((DataRowView)dgragenda.SelectedItem).Row["Tanggal"].ToString();
            agenda = ((DataRowView)dgragenda.SelectedItem).Row["Agenda"].ToString();
            catatan = ((DataRowView)dgragenda.SelectedItem).Row["Catatan"].ToString();

            NavigationService.Navigate(new agendaAkhir());
        }

        private void imgdelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string nama = "0";
                string str = ((DataRowView)dgragenda.SelectedItem).Row["ID"].ToString();
                nama = str.ToString();
                idHapus = nama;
                agendaKontroller.HapusRiwayatAgenda();
                agendaKontroller.DataAgenda2();
            }
            
        }

    }
}
