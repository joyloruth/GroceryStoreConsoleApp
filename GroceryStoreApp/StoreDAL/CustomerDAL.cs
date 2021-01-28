using FoodStore.StoreModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreDAL
{
    class CustomerDAL
    {
        private string _connectionString;

        public CustomerDAL(string connectionString)
        {
            _connectionString = (@"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True");
        }

        public List<CustomersModel> GetCustomers()
        {
            //SQL command for selecting all from customers table
            string sqlQuery = "SELECT * FROM Customers";

            //Empty list of customersModel to add and return
            List<CustomersModel> customers = new List<CustomersModel>();

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(_connectionString))

            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                //open the connection
                con.Open();
                //SqlDataReader is used because we are reading data from the database
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //while there are records in the database
                    while (reader.Read())
                    {
                        //store each value into the properties of customersModel
                        CustomersModel temp = new CustomersModel()
                        {
                            customerID = Convert.ToInt64(reader["customerID"].ToString()),
                            customerUserName = reader["customerUserName"].ToString(),
                            customerPassword = reader["customerPassword"].ToString(),
                            customerEmail = reader["customerEmail"].ToString(),
                            
                        };
                        //Add the customers object to the List of customers
                        customers.Add(temp);
                    }
                }
            }
            return customers;
        }


    

        public int AddCustomer(CustomersModel add)
        {

            string sqlQuery = "INSERT into Customers (customerID, customerUserName, " +
                " customerPhone, customerEmail) VALUES (@customerID, @customerUserName, " +
                " @customerPhone, @customerEmail)";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                //open connection
                con.Open();

                long customerID;
                string customerUserName, customerPhone, customerEmail;

                Console.WriteLine("Enter Customer ID");
                customerID= Convert.ToInt64(Console.ReadLine());

                Console.WriteLine("Enter Customer Username");
                customerUserName = Console.ReadLine();

                Console.WriteLine("Enter Customer Phone");
                customerPhone = Console.ReadLine();

                Console.WriteLine("Enter Customer Email");
                customerEmail = Console.ReadLine();

                
                cmd.Parameters.Add("@customerID", SqlDbType.BigInt).Value = add.customerID;
                cmd.Parameters.Add("@customerUserName", SqlDbType.VarChar).Value = add.customerUserName;
                cmd.Parameters.Add("@customerPhone", SqlDbType.VarChar).Value = add.customerPassword;
                cmd.Parameters.Add("@customerEmail", SqlDbType.VarChar).Value = add.customerEmail;
                
                return cmd.ExecuteNonQuery();
            }
        }
}
}
