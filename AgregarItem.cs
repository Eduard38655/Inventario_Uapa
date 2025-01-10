using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Proyecto_final
{
    public static class AgregarItem
    {

            static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";

        public static void Agregar(string producto,string Description, string marca,string stock, string precio)
        {

            

            int.TryParse(precio, out int Precio);
            int.TryParse(stock, out int Stock);

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = "insert into Productos(Nombre,Precio,Description,Marca,Stock) values(@nombre,@Precio,@Description,@marca,@Stock)";

            SqlCommand command = new SqlCommand(query, connection);

             
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@nombre", producto);
            command.Parameters.AddWithValue("@marca", marca);
            command.Parameters.AddWithValue("@Stock", Stock);
            command.Parameters.AddWithValue("@Precio",Precio);
            int rowsAffected = command.ExecuteNonQuery();

            // Verificar si se eliminó algún registro
            if (rowsAffected > 0)
            {
                MessageBox.Show("Los valores han sido agregados!");
            }
            else
            {
                MessageBox.Show("No se pudo borrar el valor.");
            }
        }
    }
}
