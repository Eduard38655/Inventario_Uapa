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
    public static class Reiniciar
    {
        static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";

        //Habilitar el input de reinicio de la clave.

        public static void ResetClave(string UserName, string password)
        {
            int.TryParse(password, out int Password);

            SqlConnection connection = new SqlConnection(connectionString);
            
                connection.Open();

                string query = "UPDATE Profile SET Password = @Password  WHERE UserName = @UserName";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Valor actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el valor.");
                }








            
        }
    }
}
