using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_final
{
    public class EditClass
    {
        static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";

        public static void EditarItems(TextBox codigo, TextBox nombre, TextBox precio, TextBox description, TextBox marca, TextBox stock)
        {
            // Validar entrada
            if (!int.TryParse(codigo.Text, out int Codigo))
            {
                MessageBox.Show("El código debe ser un número válido.");
                return;
            }

            decimal Precio = 0;
            if (precio.Text != "" && !decimal.TryParse(precio.Text, out Precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            int Stock = 0;
            if (stock.Text != "" && !int.TryParse(stock.Text, out Stock))
            {
                MessageBox.Show("El stock debe ser un número válido.");
                return;
            }

            // Crear conexión y consulta dinámica
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "UPDATE Productos SET ";
            bool hasUpdates = false;

            if (nombre.Text != "")
            {
                query += "Nombre = @Producto_Nombre, ";
                hasUpdates = true;
            }
            if (precio.Text != "")
            {
                query += "Precio = @Productos_Precio, ";
                hasUpdates = true;
            }
            if (marca.Text != "")
            {
                query += "Marca = @Productos_Marca, ";
                hasUpdates = true;
            }
            if (description.Text != "")
            {
                query += "Description = @Productos_Description, ";
                hasUpdates = true;
            }
            if (stock.Text != "")
            {
                query += "Stock = @Productos_Stock, ";
                hasUpdates = true;
            }

            // Verificar si hay campos para actualizar
            if (!hasUpdates)
            {
                MessageBox.Show("No se proporcionaron valores para actualizar.");
                connection.Close();
                return;
            }

            // Eliminar la última coma y espacio del SET
            query = query.TrimEnd(',', ' ') + " WHERE ProductosID = @ProductosID";

            SqlCommand command = new SqlCommand(query, connection);

            // Asignar parámetros solo si son necesarios
            command.Parameters.AddWithValue("@ProductosID", Codigo);
            if (nombre.Text != "") command.Parameters.AddWithValue("@Producto_Nombre", nombre.Text);
            if (precio.Text != "") command.Parameters.AddWithValue("@Productos_Precio", Precio);
            if (marca.Text != "") command.Parameters.AddWithValue("@Productos_Marca", marca.Text);
            if (description.Text != "") command.Parameters.AddWithValue("@Productos_Description", description.Text);
            if (stock.Text != "") command.Parameters.AddWithValue("@Productos_Stock", Stock);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Valor actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el valor.");
            }

            connection.Close();
        }
    }
}
