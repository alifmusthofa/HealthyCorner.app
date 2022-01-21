using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace HealthyCorner.Model
{
    class KlinisModel
    {
        ModelTemplate temp;
        public string id_record { get; set; }
        public string tanggal { get; set; }
        public string id { get; set; }
        public string nama { get; set; }
        public string ket { get; set; }
        public string tanggal_id { get; set; }
        public bool penuh { get; set; }

        public KlinisModel()
        {
            temp = new ModelTemplate();
        }
        public DataSet RiwayatKlinis()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("select nama as [Penyakit],CONVERT (VARCHAR(9),tanggal_pemeriksaan,6) AS [Tanggal],ket_klinis as [Keterangan Klinis] from klinis where id = '" + Model.PenggunaModel.idUser + "' ", "klinis");
            return ds;
        }
        public DataSet RiwayatKlinis2()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("select id_klinis as [ID],nama as [Penyakit],CONVERT (VARCHAR(9),tanggal_pemeriksaan,6) AS [Tanggal],ket_klinis as [KeteranganKlinis] from klinis where id = '" + Model.PenggunaModel.idUser + "' ", "klinis");
            return ds;
        }

        public bool Insertklinis()
        {
            string tabel = "klinis";
            string data = "'"+id_record+"','"+tanggal+"','"+id+"','"+nama+"','"+ket+"'";
            return temp.Insert(tabel, data);
        }

        public bool HapusKlinis()
        {
            string tabel = "klinis";
            string kondisi = "id_klinis='" + id_record + "'";
            return temp.Delete(tabel,kondisi);
        }

        public bool UpdateKlinis()
        {
            string tabel = "klinis";
            string data = "tanggal_pemeriksaan = '"+tanggal+"',nama = '"+nama+"',ket_klinis = '"+ket+"' ";
            string kondisi = "id_klinis='" + id_record + "'";
            return temp.Update(tabel, data, kondisi);
        }

        public string GenerateId()
        {
            string id = "";
            string query = "SELECT max(RIGHT(id_klinis,3)) from klinis where tanggal_pemeriksaan = '" + tanggal + "'";
            DataSet data = new DataSet();
            data = temp.SelectData(query, "klinis");

            if(data.Tables[0].Rows[0][0].ToString() == "")
            {
                
                id = tanggal_id + "-" + "001";
            }
            else
            {
                int ambil1 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(0,1));
                int ambil2 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1,1));
                int ambil3 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2,1));
                int nilai = 0;
                if (ambil1 == 9 && ambil2 == 9 && ambil3 == 9)
                {
                    penuh = true;
                    
                }
                else if(ambil1 > 0)
                {
                    
                    nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(0, 3));
                    id = tanggal_id + "-" + (nilai + 1);
                }
                else 
                {
                    ambil1 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 1));
                    ambil2 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                    if (ambil1 == 9 && ambil2 == 9)
                    {
                        
                        nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                        id = tanggal_id + "-" + (nilai + 1);
                    }
                    else if (ambil1 > 0 )
                    {
                        
                        nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                        id = tanggal_id + "-0" + (nilai + 1);
                    }
                    else
                    {
                        if (ambil2 == 9)
                        {
                            
                            nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                            id = tanggal_id + "-0" + (nilai + 1);
                        }
                        else
                        {
                            
                            nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                            id = tanggal_id + "-00" + (nilai + 1);
                        }

                    }
                }

            }

            return id;
        }

    }
}
