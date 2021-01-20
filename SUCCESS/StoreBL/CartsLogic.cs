using FoodStore.StoreModels;
using FoodStore.StoreModels.ModelImplementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreBL
{
    class CartsLogic : ILogics
    {
        string CONNECTION = @"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True";
        public int Add()
        {

            SqlConnection cn = new SqlConnection(CONNECTION);

            //open connection
            cn.Open();


            Console.WriteLine("Enter Cart Order ID");
            int cartOrderID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product ID");
            int cartProductID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter quantity.");
            int cartQuantity = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("INSERT INTO carts VALUES('" + cartOrderID + "','" + cartProductID + "','" + cartQuantity + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Next, is checkout.");

                Console.WriteLine("Order ID: " + cartOrderID);
                Console.WriteLine("Product ID: " + cartProductID);
                Console.WriteLine("Quantity: " + cartQuantity);


            }
            cn.Close();
            { return i; }
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public int Edit()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {

        }

        public ProductsModel GetInventoryByCartOrderID()
        {
            List<ProductsModel> products = new List<ProductsModel>();
            ProductsModel product = new ProductsModel();

            List<CartsModel> carts = new List<CartsModel>();
            CartsModel cart = new CartsModel();



            // Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Order ID Number ");
            // Console.WriteLine("       +----------------------------------------------------------------+");
            // long productID = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Cart Order ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            int cartOrderID = Convert.ToInt32(Console.ReadLine());

            //string sqlQuerys = "Select * from locations where locationID=@ID";

            //"SELECT * FROM Products INNER JOIN Locations ON Locations.locationID = Products.productLocationID" + "WHERE locationID=@locationID" + "AND productID=@productID";
            string sqlQuery = "SELECT * FROM Carts INNER JOIN Products ON Carts.cartProductID = Products.productID WHERE cartOrderID=@cartOrderID";


            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@cartOrderID", SqlDbType.Int).Value = cartOrderID;
                //cmd.Parameters.Add("@productID", SqlDbType.Int).Value = productID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        ProductsModel temp = new ProductsModel();
                        {
                            //cartOrderID = Convert.ToInt32(reader["cartOrderID"]);
                            //cart.cartProductID = Convert.ToInt32(reader["cartProductID"]);
                            // cart.cartQuantity = Convert.ToInt32(reader["cartQuantity"]);

                            product.productID = Convert.ToInt32(reader["productID"]);
                            product.productName = reader["productName"].ToString();
                            product.productPrice = Convert.ToDouble(reader["productPrice"]);
                            product.productQuantity = Convert.ToInt32(reader["productQuantity"]);
                            product.productLocationID = Convert.ToInt32(reader["productLocationID"]);

                        }

                        products.Add(temp);





                        Console.WriteLine();
                       // Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");

                        
                        Console.WriteLine();
                        Console.WriteLine("        PRODUCT NAME      " + " | " + product.productName);
                        Console.WriteLine("        PRODUCT QUANTITY  " + " | " + product.productQuantity);
                        Console.WriteLine("        PRODUCT PRICE     " + " | " + product.productPrice);

                        Console.WriteLine();
                        Console.WriteLine("        PRODUCT ID        " + " | " + product.productID);
                        Console.WriteLine("        PRODUCT LOCATION ID" + " | " + product.productLocationID);
                        
                       
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();

                    }
                    
                }
                return product;

            }


        }

    }
}



