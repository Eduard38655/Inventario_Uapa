using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_final
{
    public class EliminarItem
    {
        static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";

        public static void EliminarValor(TextBox nombre, TextBox codigo)
        {
            string nombreValor = nombre.Text;   
            string codigoValor = codigo.Text;

            int.TryParse(codigoValor, out int Codigo);

             SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

             string query = "DELETE FROM Productos WHERE Nombre = @Productos_Nombre OR ProductosID = @ProductosID";

             SqlCommand command = new SqlCommand(query, connection);

             command.Parameters.AddWithValue("@Productos_Nombre", nombreValor);  
             command.Parameters.AddWithValue("@ProductosID", Codigo);

             int rowsAffected = command.ExecuteNonQuery();

            // Verificar si se eliminó algún registro
            if (rowsAffected > 0)
            {
                MessageBox.Show("Valor eliminado!");
            }
            else
            {
                MessageBox.Show("No se pudo borrar el valor. Verifique que el nombre o código sean correctos.");
            }
        }
    }
}
