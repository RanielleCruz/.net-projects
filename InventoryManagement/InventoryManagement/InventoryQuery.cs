using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagement
{
    class InventoryQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString;

        public InventoryQuery()
        {
            connectionString = "Data Source=DELL\\SQLEXPRESS02;Initial Catalog=Inventoryyyy;Integrated Security=True";
            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();

        }

        public bool Display() {
            try {
                string ViewInventory = "SELECT productName, category,  manufacturingID, expirationDate, descriptions, quantity, sellingPrice FROM Products";
                sqlCommand = new SqlCommand();
                sqlAdapter = new SqlDataAdapter(sqlCommand);

                dataTable.Clear();
                sqlAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
                return false;
            }
        
        }
        public bool AddItem(string ProductName, string Category, string MfgDate,
            string ExpDate, string Description, int Quantity, double SellPrice) {

            sqlCommand = new SqlCommand("INSERT INTO Products (productName, category, manufacturingID, expirationDate, descriptions, quantity, sellingPrice)" +
                " VALUES (@productName, @category, @manufacturingID, @expirationDate, @descriptions, @quantity,  @sellingPrice)", sqlConnect);

            sqlCommand.Parameters.Add("@productName", SqlDbType.VarChar).Value = ProductName;
            sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = Category;
            sqlCommand.Parameters.Add("@manufacturingID", SqlDbType.VarChar).Value = MfgDate;
            sqlCommand.Parameters.Add("@expirationDate", SqlDbType.VarChar).Value = ExpDate;
            sqlCommand.Parameters.Add("@descriptions", SqlDbType.VarChar).Value = Description;
            sqlCommand.Parameters.Add("@quantity", SqlDbType.Int).Value = Quantity;
            sqlCommand.Parameters.Add("@sellingPrice", SqlDbType.Float).Value = Convert.ToSingle(SellPrice);


            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            return true;
        }

        public bool RemoveItem(string ProductName, string Category, string MfgDate,
            string ExpDate, string Description, int Quantity, double SellPrice)
        {
            sqlCommand = new SqlCommand(
                "DELETE FROM Inventory WHERE ProductName = @ProductName AND Category = @Category AND MfgDate = @MfgDate" +
                " AND ExpDate = @ExpDate AND Description = @Description AND Quantity = @Quantity AND SellPrice = @SellPrice", sqlConnect);

            sqlCommand.Parameters.Add("@productName", SqlDbType.VarChar).Value = ProductName;
            sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = Category;
            sqlCommand.Parameters.Add("@manufacturingID", SqlDbType.VarChar).Value = MfgDate;
            sqlCommand.Parameters.Add("@expirationDate", SqlDbType.VarChar).Value = ExpDate;
            sqlCommand.Parameters.Add("@descriptions", SqlDbType.VarChar).Value = Description;
            sqlCommand.Parameters.Add("@quantity", SqlDbType.Int).Value = Quantity;
            sqlCommand.Parameters.Add("@sellingPrice", SqlDbType.Float).Value = Convert.ToSingle(SellPrice);


            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            return true;

            return true;
        }
    }
}
