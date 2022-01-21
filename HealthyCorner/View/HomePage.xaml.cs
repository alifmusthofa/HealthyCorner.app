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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Controller.PemeriksaanKontroller pemeriksaanKontroller;
        Controller.kliniskontroller kliniskontroller;
        Controller.agendaKontroller agendaKontroller;
        public HomePage()
        {
            InitializeComponent();
            pemeriksaanKontroller = new Controller.PemeriksaanKontroller(this);
            pemeriksaanKontroller.DataPemeriksaan();
            pemeriksaanKontroller.ShowpemeriksaanToday();
            kliniskontroller = new Controller.kliniskontroller(this);
            kliniskontroller.Dataklinis();
            agendaKontroller = new Controller.agendaKontroller(this);
            agendaKontroller.DataAgenda();

            
        }
    }
}
