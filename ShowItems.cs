using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_final
{
    public class ShowItems
    {
        static string connectionString = "Server=LAPTOP-GNIDI8TC\\SQLEXPRESS;Database=Inventario;User Id=EF197ef9;Password=123456;";

        //Buscar Items.
        public static void ScreenItems(DataGridView datos, TextBox valor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Productos";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            datos.DataSource = dataTable;

            connection.Close();
        }

        public static void GetItem(TextBox codigo, TextBox nombre, TextBox precio, TextBox description, TextBox marca, TextBox stock, DataGridView datos, Button editar, Button eliminar)
        {
            string Codigo = codigo.Text;
            int.TryParse(Codigo, out int ProductoID);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Productos WHERE ProductosID = @ProductoID OR Nombre = @Producto_Nombre";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductoID", ProductoID);
            command.Parameters.AddWithValue("@Producto_Nombre", nombre.Text);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            datos.DataSource = dataTable;


            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nombre.Text = reader["Nombre"].ToString();
                precio.Text = reader["Precio"].ToString();
                description.Text = reader["Description"].ToString();
                marca.Text = reader["Marca"].ToString();
                stock.Text = reader["Stock"].ToString();

            }
            else
            {
                MessageBox.Show("No se encontraron productos con ese ID.");
            }

            reader.Close();
            connection.Close();
        }

        public static void Validate_text(string valor1, string valor2, Button editar, Button eliminar)
        {

        }



        //Obtener valor del Datagrid cuando se haga click.
        public static void dataValor(TextBox codigo, TextBox nombre, TextBox precio, TextBox description, TextBox marca, TextBox stock, string click)
        {

            int.TryParse(click, out int ProductoID);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Productos WHERE ProductosID = @ProductoID ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ProductoID", ProductoID);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);



            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                codigo.Text = reader["ProductosID"].ToString();
                nombre.Text = reader["Nombre"].ToString();
                precio.Text = reader["Precio"].ToString();
                description.Text = reader["Description"].ToString();
                marca.Text = reader["Marca"].ToString();
                stock.Text = reader["Stock"].ToString();


            }
        }
    }
}
