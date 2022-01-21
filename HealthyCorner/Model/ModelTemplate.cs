using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HealthyCorner.Model
{
    class ModelTemplate
    {
        //deklarasi object + variabel
        private static SqlConnection conn;
        private SqlCommand command;
        private bool result;

        public static SqlConnection GetConnection()
        {
            // instace coonection
            conn = new SqlConnection();
            // set connection
            conn.ConnectionString = "Data Source = DESKTOP-DCA7UTL;" +
                                    "Initial Catalog = HealthyCorner;" +
                                    "Integrated Security = True;";
            return conn;
        }

        public ModelTemplate()
        {
            GetConnection();
        }


        // template select data
        public DataSet Select(string tabel, string kondisi)
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                if (kondisi == null)
                {
                    command.CommandText = "SELECT * FROM " + tabel;
                }
                else
                {
                    command.CommandText = "SELECT * FROM " + tabel + " WHERE " + kondisi;
                }
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, tabel);
            }
            catch (SqlException)
            {
                ds = null;
            }
            conn.Close();
            return ds;
        }

        // template insert data
        public Boolean Insert(string tabel, string data)
        {
            result = false;
            try
            {
                string query = "INSERT INTO " + tabel + " VALUES (" + data + ")";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        // template update data
        public Boolean Update(string tabel, string data, string kondisi)
        {
            result = false;
            try
            {
                string query = "UPDATE " + tabel + " SET " + data + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        // template delete data
        public Boolean Delete(string tabel, string kondisi)
        {
            result = false;
            try
            {
                string query = "DELETE FROM " + tabel + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        // template select data counting, top, grouping,dll
        public DataSet SelectData(string query, string tabel)
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, tabel);
            }
            catch (SqlException)
            {
                ds = null;
            }
            conn.Close();
            return ds;
        }

    }
}
