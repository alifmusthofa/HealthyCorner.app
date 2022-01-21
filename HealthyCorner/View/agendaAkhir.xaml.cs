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
    /// Interaction logic for agendaAkhir.xaml
    /// </summary>
    public partial class agendaAkhir : Page
    {
        Controller.agendaKontroller agendaKontroller;
        public agendaAkhir()
        {
            InitializeComponent();
            agendaKontroller = new Controller.agendaKontroller(this);

            lblid.Content = "ID Number : " + View.AgendaAwal.id;
            txtagenda.Text = View.AgendaAwal.agenda;
            txtcatatan.Text = View.AgendaAwal.catatan;
            dtpTanggal.Text = View.AgendaAwal.tanggal;
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
                    agendaKontroller.UbahAgenda();
                    NavigationService.Navigate(new AgendaAwal());
                }

            }

        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
