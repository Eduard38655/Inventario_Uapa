using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public static class LoginAccess
    {
        static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";


        public static void ValidarUser(string User,string Password)
        {

            int.TryParse(Password,out int Clave);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Profile where UserName=@User and Password=@Clave";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@User", User);
            command.Parameters.AddWithValue("@Clave", Clave);
            command.ExecuteNonQuery();
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count>0)
            {
                MessageBox.Show("Bienvenido");
                Form1 inicio = new Form1();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("Revisa tus credenciales.");

            }
        }
    }
}
