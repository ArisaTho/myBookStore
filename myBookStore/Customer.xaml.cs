using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace myBookStore
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        string connectionString = "Server=Arisa;Database=myBookStore;User Id=sa;Password=1234;";
        public Customer()
        {
            InitializeComponent();
        }

        private void CbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CtxtAddress.Text != null && CtxtCustName.Text != null && CtxtAddress.Text != null && CtxtEmail.Text != null)
            {
                // data to insert
                int custId = int.Parse(CtxtAddress.Text);
                string custName = CtxtCustName.Text;
                string address = CtxtAddress.Text;
                string email = CtxtEmail.Text;

                // Create the SQL query
                string query = "INSERT INTO Customer (cust_id, cust_name, address, email) VALUES (@CustId, @CustName, @Address, @Email)";
                // Create and open the connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the command and set its properties
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameters and their values
                        command.Parameters.AddWithValue("@CustId", custId);
                        command.Parameters.AddWithValue("@CustName", custName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Email", email);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Pls enter data!!");
            }

        }

        private void CbtnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbtnDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
