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
        public string telp;
        public string password;

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
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool InsertPengguna()
        {
            string data = "'" + id + "','" + nama + "','" + jk + "','" + telp + "','" + password + "'";
            return temp.Insert("pengguna", data);
        }
    }
}
