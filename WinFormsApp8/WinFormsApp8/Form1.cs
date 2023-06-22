using System.Data.SqlClient;




namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\source\repos\WinFormsApp5\WinFormsApp5\Database1.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Company (CompanyName, Address) VALUES (@Value1, @Value2)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Value1", textBox1.Text);
            command.Parameters.AddWithValue("@Value2", textBox2.Text);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\source\repos\WinFormsApp5\WinFormsApp5\Database1.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT CompanyName, Address FROM Company WHERE Id = @Value1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Value1", Guid.Parse(textBox3.Text));

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["CompanyName"].ToString();
                textBox2.Text = reader["Address"].ToString();
            }
            reader.Close();

            connection.Close();
        }
    }
}