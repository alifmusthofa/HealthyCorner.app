using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
namespace HealthyCorner.Controller
{
    class Pengguna
    {
        //deklarasi object model dan view
        Model.PenggunaModel pengguna;
        Login login;
        View.Signup register;
        View.GantiAkun gantiAkun;

        // instace 

        public Pengguna(View.Signup register)
        {
            pengguna = new Model.PenggunaModel();
            this.register = register;
        }
        public Pengguna(Login login)
        {
            pengguna = new Model.PenggunaModel();
            this.login = login;
        }
        public Pengguna(View.GantiAkun gantiAkun)
        {
            pengguna = new Model.PenggunaModel();
            this.gantiAkun = gantiAkun;
        }



        // request & respone
        public void Login()
        {
            pengguna.id = login.txtUsername.Text;
            pengguna.password = login.txtPassword.Password;
            bool result = pengguna.CekLogin();
            if (result)
            {
                View.MainWindow percobaan1 = new View.MainWindow();
                percobaan1.lblUser.Content = Model.PenggunaModel.namaUser;
                percobaan1.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Maaf, username / password anda salah!");
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
            }
        }

        public void Register()
        {
            pengguna.id = register.txtId.Text;
            pengguna.nama = register.txtNama.Text;
            if (register.rdbLaki.IsChecked == true)
            {
                pengguna.jk = "L";
            }
            else
            {
                pengguna.jk = "P";
            }
            pengguna.password = register.txtPassword.Text;
            bool result = pengguna.InsertPengguna();
            if (result)
            {
                MessageBox.Show("Pembuatan akun berhasil, " +
                    "Silahkan login menggunakan ID dan password anda");
                Login login = new Login();
                login.Show();
                register.Close();
            }
            else
            {
                MessageBox.Show("Maaf,Registrasi akun baru gagal, " +
                    "periksa dan lengkapi data diri anda");
            }
        }

        public void UbahPengguna()
        {
            // set data
            
            pengguna.nama = gantiAkun.txtNama.Text;
            if (gantiAkun.rdbLaki.IsChecked == true)
            {
                pengguna.jk = "L";
            }
            else
            {
                pengguna.jk = "P";
            }
            pengguna.password = gantiAkun.txtPassword.Text;

            //proses update
            bool result = pengguna.UpdatePengguna();
            //information
            if (result)
            {
                MessageBox.Show("Akun anda berhasil diubah");
                Model.PenggunaModel.namaUser = pengguna.nama;

            }
            else
            {
                MessageBox.Show("Maaf, perubahan Akun anda tidak dapat dilakukan");
            }


        }

        public void DataAkun()
        {

            DataSet ds = pengguna.InfoAkun();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gantiAkun.lblid.Content = ds.Tables[0].Rows[0][0].ToString();
                gantiAkun.txtNama.Text = ds.Tables[0].Rows[0][1].ToString();
                gantiAkun.txtPassword.Text = ds.Tables[0].Rows[0][3].ToString();
                if(ds.Tables[0].Rows[0][2].ToString() == "L")
                {
                    gantiAkun.rdbLaki.IsChecked = true;
                }
                else
                {
                    gantiAkun.rdbPerempuan.IsChecked = true;
                }
            }
        }
    }
}
