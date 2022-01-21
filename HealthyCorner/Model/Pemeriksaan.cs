using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace HealthyCorner.Model
{
    class Pemeriksaan
    {
        ModelTemplate temp;
        public string id_record { get; set; }
        public string tanggal { get; set; }
        public string id { get; set; }
        public string guladarah { get; set; }
        public string detakjantung { get; set; }
        public string tekanandarah1 { get; set; }
        public string tekanandarah2 { get; set; }
        public string asamurat { get; set; }
        public string kolesterol { get; set; }
        public string suhubadan { get; set; }
        public string tanggal_id { get; set; }
        public bool penuh { get; set; }
        public Pemeriksaan()
        {
            temp = new ModelTemplate();
        }

        public DataSet RiwayatPemeriksaan()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT TOP 10 CONVERT (VARCHAR(9),tanggal_pemeriksaan,6) AS [Tanggal],guladarah AS [Gula Darah],detakjantung AS [Detak Jantung],tekanandarah AS [Tekanan Darah],asamurat AS [Asam Urat],kolesterol AS [Kolesterol],suhubadan AS [Suhu Badan] FROM pemeriksaan where id = '" + Model.PenggunaModel.idUser + "' order by id_record desc", "pemeriksaan");
            return ds;
        }
       

        public DataSet PemeriksaanHariIni(string kolom1, string kolom2, string kolom3, string kolom4, string kolom5, string kolom6, string tanggal)
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("select top(1) " + kolom1 + "," + kolom2 + "," + kolom3 + "," + kolom4 + "," + kolom5 + "," + kolom6 + " from pemeriksaan where tanggal_pemeriksaan ='" + tanggal + "' and id = '"+ Model.PenggunaModel.idUser+"' order by id_record desc", "pemeriksaan");
            return ds;
        }

        public DataSet RiwayatPemeriksaan2()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("select id_record as [ID],CONVERT (VARCHAR(9),tanggal_pemeriksaan,6) AS [Tanggal],guladarah AS [GulaDarah],detakjantung AS [DetakJantung],tekanandarah AS [TekananDarah],asamurat AS [AsamUrat],kolesterol AS [Kolesterol],suhubadan AS [SuhuBadan] FROM pemeriksaan where id = '" + Model.PenggunaModel.idUser + "' ", "pemeriksaan");
            return ds;
        }

        public bool InsertPemeriksaan()
        {
            string tabel = "pemeriksaan";
            string data = "'" + id_record + "','" + tanggal + "','" + id + "','" + guladarah + "','" + detakjantung + "','" + tekanandarah1+"/"+ tekanandarah2 + "','" + asamurat + "','"+ kolesterol + "','"+ suhubadan + "'";
            return temp.Insert(tabel, data);
        }

        public bool HapusPemeriksaan()
        {
            string tabel = "pemeriksaan";
            string kondisi = "id_record='" + id_record + "'";
            return temp.Delete(tabel, kondisi);
        }

        public bool UpdatePemeriksaan()
        {
            string tabel = "pemeriksaan";
            string data = "tanggal_pemeriksaan = '" + tanggal + "',guladarah = '" + guladarah + "',detakjantung = '" + detakjantung + "',tekanandarah = '" + tekanandarah1 + "/" + tekanandarah2 + "',asamurat = '" + asamurat + "',kolesterol = '" + kolesterol + "',suhubadan = '" + suhubadan + "' ";
            string kondisi = "id_record='" + id_record + "'";
            return temp.Update(tabel, data, kondisi);
        }

        public string GenerateId()
        {
            string id = "";
            string query = "SELECT max(RIGHT(id_record,3)) from pemeriksaan where tanggal_pemeriksaan = '" + tanggal + "'";
            DataSet data = new DataSet();
            data = temp.SelectData(query, "pemeriksaan");

            if (data.Tables[0].Rows[0][0].ToString() == "")
            {
                
                id = tanggal_id + "-" + "001";
            }
            else
            {

                int ambil1 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(0, 1));
                int ambil2 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 1));
                int ambil3 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                int nilai = 0;
                if (ambil1 == 9 && ambil2 == 9 && ambil3 == 9)
                {
                    penuh = true;
                }
                else if (ambil1 > 0)
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
                    else if (ambil1 > 0)
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
