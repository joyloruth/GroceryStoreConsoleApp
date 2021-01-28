using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreDAL
{
    class ProductDAL
    {
        
        
           string _connectionString = (@"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True");
        
        public int AddProduct()
        {

            SqlConnection cn = new SqlConnection(@"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True");


            cn.Open();
            int productID, productPrice, productQuantity;
            string productName;

            Console.WriteLine("Enter ID");
            productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Name");
            productName = Console.ReadLine();

            Console.WriteLine("Enter Product Quantity");
            productPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Price");
            productQuantity = (int)Convert.ToDouble(Console.ReadLine());





            SqlCommand cmd = new SqlCommand("INSERT INTO products VALUES('" + productID + "','" + productName + "','" + productPrice + "','" + productQuantity + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine("Successful Connection");
            }
            cn.Close();
            { return i; }
        }
    }
}
