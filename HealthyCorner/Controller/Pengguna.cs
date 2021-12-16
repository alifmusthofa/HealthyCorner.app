using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthyCorner.Controller
{
    class Pengguna
    {
        //deklarasi object model dan view
        Model.PenggunaModel pengguna;
        Login login;
        //RegisterWindow register;

        // instace 

        /*public Pengguna(View.RegisterWindow register)
        {
            pengguna = new Model.PenggunaModel();
            this.register = register;
        }*/
        public Pengguna(Login login)
        {
            pengguna = new Model.PenggunaModel();
            this.login = login;
        }



        // request & respone
        public void Login()
        {
            //pengguna.id = login.txtUsername.Text;
            //pengguna.password = login.txtPassword.Password;
            bool result = pengguna.CekLogin();
            if (result)
            {
                MainWindow main = new MainWindow();
                main.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Maaf, username / password anda salah!");
                //login.txtUsername.Text = "";
                //login.txtPassword.Password = "";
                //login.txtUsername.Focus();
            }
        }

        /*public void Register()
        {
            pengguna.id = register.txtId.Text;
            pengguna.nama = register.txtNamaLengkap.Text;
            if (register.rdbLaki.IsChecked == true)
            {
                pengguna.jk = "L";
            }
            else
            {
                pengguna.jk = "P";
            }
            pengguna.telp = register.txtTelp.Text;
            pengguna.password = register.txtPassword.Text;
            bool result = pengguna.InsertPengguna();
            if (result)
            {
                MessageBox.Show("Pembuatan akun berhasil, " +
                    "Silahkan login menggunakan ID dan password anda");
                View.LoginWindow login = new View.LoginWindow();
                login.Show();
                register.Close();
            }
            else
            {
                MessageBox.Show("Maaf,Registrasi akun baru gagal, " +
                    "periksa dan lengkapi data diri anda");
            }
        }*/
    }
}
