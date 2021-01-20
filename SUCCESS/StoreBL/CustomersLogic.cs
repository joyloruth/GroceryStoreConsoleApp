using FoodStore.StoreDAL;
using FoodStore.StoreModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreBL
{
    class CustomersLogic : ILogics
    {
        string CONNECTION = (@"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True");
        public int Add()
        {
            SqlConnection cn = new SqlConnection(CONNECTION);


            cn.Open();
            int customerID;
            string customerUserName, customerPassword, customerEmail;

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Identification Number(Phone Number).                  ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            customerID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Create a Username.                                              ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            customerUserName = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Create a password.                                              ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            customerPassword = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter personal email.                                           ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            customerEmail = Console.ReadLine();




            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES('" + customerID + "','" + customerUserName + "','" + customerPassword + "','" + customerEmail + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine();
                Console.WriteLine("        Account Successfully Created.");
                Console.WriteLine("                                     ");
                Console.WriteLine("        Account ID: " + customerID);
                Console.WriteLine("        Account User Name: " + customerUserName);

                Console.WriteLine("        Account Email" + customerEmail);

            }
            cn.Close();
            { return i; }
        }


        public int Delete()
        {
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Account Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");

            int ID = Convert.ToInt32(Console.ReadLine());
            string sqlQuery = "DELETE from products Where productID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                int success = cmd.ExecuteNonQuery();

                if (success > 0)
                {
                    Console.WriteLine("        Account ID: " + ID);
                    Console.WriteLine("        Your Account has been deleted. ");



                }
                return success;


            }
        }

        public int Edit()
        {
            throw new NotImplementedException();
        }







        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CustomersModel> GetCustomers()
        {
            //SQL command for selecting all from customer table
            string sqlQuery = "SELECT * FROM Customers";
            string _connectionString = CONNECTION;

            //Empty list of customerViewModel to add and return
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
                        //store each value into the properties of customerViewModel
                        CustomersModel temp = new CustomersModel()
                        {
                            customerID = Convert.ToInt64(reader["customerID"]),
                            customerUserName = reader["customerUserName"].ToString(),
                            customerPassword = reader["customerPassword"].ToString(),
                            customerEmail = reader["customerEmail"].ToString(),

                        };
                        //Add the customer object to the List of customer

                        customers.Add(temp);



                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        ACCT USERID   " + " | " + temp.customerID);
                        Console.WriteLine("        ACCT USERNAME " + " | " + temp.customerUserName);
                        Console.WriteLine("        PRIMARY EMAIL " + " | " + temp.customerEmail);
                        Console.WriteLine("       +----------------------------------------------------------------+");

                    }
                }
            }
            return customers;
        }






        public CustomersModel GetCustomerById()
        {
            CustomersModel customer = new CustomersModel();
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Account Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long customerID = Convert.ToInt32(Console.ReadLine());

            string sqlQuery = "Select * from Customers where customerID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = customerID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.customerID = Convert.ToInt32(reader["customerID"]);
                        customer.customerUserName = reader["customerUserName"].ToString();
                        customer.customerEmail = reader["customerEmail"].ToString();

                    }

                    {

                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        ACCT USERID   " + " | " + customerID);
                        Console.WriteLine("        ACCT USERNAME " + " | " + customer.customerUserName);
                        Console.WriteLine("        PRIMARY EMAIL " + " | " + customer.customerEmail);
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();
                    }
                }
                return customer;
            }

        }
    }
}











    











