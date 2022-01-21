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
using System.Data;

namespace HealthyCorner.View
{
    /// <summary>
    /// Interaction logic for percobaan2.xaml
    /// </summary>
    public partial class percobaan2 : Window
    {
        Controller.percobaankontroller2 kliniskontroller;
        public percobaan2()
        {
            InitializeComponent();
            kliniskontroller = new Controller.percobaankontroller2(this);
            kliniskontroller.Dataklinis2();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            string nama = "0";
            DataRowView rowView = (DataRowView)dataGridProgram.SelectedItem;
            string str = ((DataRowView)dataGridProgram.SelectedItem).Row["Penyakit"].ToString();
            int row = dataGridProgram.SelectedIndex;
            nama = str.ToString();
            kliniskontroller.hapusdataklinis(row);


           
        }
    }
}
