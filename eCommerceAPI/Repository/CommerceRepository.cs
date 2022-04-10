using eCommerceAPI.Models;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace eCommerceAPI.Repository
{
    public class CommerceRepository
    {
        private DbConnection _connection;

        public CommerceRepository()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Commerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Product GetProductById(long id)
        {
            Product product = new Product();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM Product WHERE Id = @Id";
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Connection = (SqlConnection)_connection;

                _connection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    product.NameProduct = Convert.ToString(dataReader["NameProduct"]);
                    product.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    product.Value = Convert.ToDecimal(dataReader["Value"]);
                }
            }
            catch(Exception ex)
            {
                _connection.Close();
                throw new Exception(ex.Message);
            }

            return product;
        }

        public void InsertProduct(Product product)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "INSERT INTO Product VALUES (@NameProduct, @Quantity, @Value)";
                sqlCommand.Parameters.AddWithValue("@NameProduct", product.NameProduct);
                sqlCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                sqlCommand.Parameters.AddWithValue("@Value", product.Value);
                sqlCommand.Connection = (SqlConnection)_connection;

                _connection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _connection.Close();
                throw new Exception(ex.Message);
            }
        }
    }
}
