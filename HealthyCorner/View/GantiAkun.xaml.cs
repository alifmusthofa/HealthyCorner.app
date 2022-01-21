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
    /// Interaction logic for GantiAkun.xaml
    /// </summary>
    public partial class GantiAkun : Window
    {
        Controller.Pengguna Pengguna;
        public GantiAkun()
        {
            InitializeComponent();
            Pengguna = new Controller.Pengguna(this);
            Pengguna.DataAkun();
            
        }


        private void CancelClik(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.lblUser.Content = Model.PenggunaModel.namaUser;
            mainWindow.Show();
            this.Close();
        }

        private void EditClik(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin mengedit data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Pengguna.UbahPengguna();
                MainWindow mainWindow = new MainWindow();
                mainWindow.lblUser.Content = Model.PenggunaModel.namaUser;
                mainWindow.Show();
                this.Close();
            }

        }
    }
}
