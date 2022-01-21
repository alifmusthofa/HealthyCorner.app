using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HealthyCorner.Model
{
    class PenggunaModel
    {
        // deklarasi variabel
        public string id;
        public string nama;
        public string jk;
        public string password;


        // chace
        public static string namaUser;
        public static string idUser;

        // deklarasi object model template\
        private ModelTemplate temp;

        // instace
        public PenggunaModel()
        {
            temp = new ModelTemplate();
        }

        // validasi login
        public bool CekLogin()
        {
            bool result = false;
            DataSet ds = new DataSet();
            ds = temp.Select("pengguna", "id = '" + id + "' AND password = '" + password + "'");
            // cek
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
                idUser = ds.Tables[0].Rows[0][0].ToString();
                namaUser = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                result = false;
            }
            return result;
        }

        
        public DataSet InfoAkun()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT * FROM pengguna where id = '"+idUser+"'", "pengguna");
            return ds;
        }
        

        public bool InsertPengguna()
        {
            string data = "'" + id + "','" + nama + "','"  + jk + "','" + password + "'";
            return temp.Insert("pengguna", data);
        }
        public bool UpdatePengguna()
        {
            string tabel = "pengguna";
            string data = "nama = '" + nama + "',gender = '" + jk + "',password = '" + password + "' ";
            string kondisi = "id='" + idUser + "'";
            return temp.Update(tabel, data, kondisi);
        }
    }
}
