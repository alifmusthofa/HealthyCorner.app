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

namespace HealthyCorner
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Controller.Pengguna pengguna;
        public Login()
        {
            InitializeComponent();
            pengguna = new Controller.Pengguna(this);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pengguna.Login();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.Signup register = new View.Signup();
            register.Show();
            this.Close();
        }
    }
}
