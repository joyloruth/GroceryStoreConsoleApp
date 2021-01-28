using FoodStore.StoreModels;
using FoodStore.StoreModels.ModelImplementations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreBL
{
    class OrdersLogic : ILogics
    {   //database Connection
        string CONNECTION = @"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True";

        //adds a orders to database
        public int Add()
        {

            SqlConnection cn = new SqlConnection(CONNECTION);

            //open connection
            cn.Open();


            Console.WriteLine("Enter Order ID");
            int orderID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Order Date");
            string orderDate = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES('" + orderID + "','" + orderDate + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Your order is completed. Thank you for shopping with us");

                Console.WriteLine("Order ID: " + orderID);
                Console.WriteLine("Order ID: " + orderDate);


            }
            cn.Close();
            { return i; }
        }


        public int Delete()
        {
            Console.WriteLine("Enter Order ID # you would like to delete.");
            int ID = Convert.ToInt32(Console.ReadLine());
            string sqlQuery = "DELETE from orders Where orderID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                //open connection
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                return cmd.ExecuteNonQuery();


            }
        }

        public int Edit()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {

        }



        public int AddProductoCart()
        {
            SqlConnection cn = new SqlConnection(CONNECTION);

            //Open Connection
            cn.Open();
            int orderID;

            Console.WriteLine("Choose a product to add to cart");
            orderID = Convert.ToInt32(Console.ReadLine());



            //using SqlCommand passing in the SqlConnection and the sqlQuery
            SqlCommand cmd = new SqlCommand("INSERT INTO orders VALUES('" + orderID + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Your order is completed");

                Console.WriteLine("Order ID: " + orderID);


            }
            cn.Close();
            { return i; }
        }



        public int add()
        {

            SqlConnection cn = new SqlConnection(CONNECTION);

            OrdersModel orderlist = new OrdersModel();

            //open connection
            cn.Open();
            int orderID;

            Console.WriteLine("Enter Order ID");
            orderID = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("INSERT INTO orders VALUES('" + orderID + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Your order is completed");

                Console.WriteLine("Order ID: " + orderID);


            }
            cn.Close();
            { return i; }
        }


        public List<OrdersModel> GetOrders()
        {
            string sqlQuery = "SELECT * FROM orders";
            List<OrdersModel> orderslist = new List<OrdersModel>();

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))

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
                        //store each value into the properties of productViewModel
                        OrdersModel temp = new OrdersModel()
                        {
                            orderID = Convert.ToInt32(reader["orderID"]),
                            orderDate = reader["orderDate"].ToString(),


                        };

                        //Add the product object to the List of product
                        orderslist.Add(temp);

                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        ORDER ID         " + " | " + temp.orderID);
                        Console.WriteLine("        ORDER DATE       " + " | " + temp.orderDate);


                    }
                }
            }
            return orderslist;
        }




        /*  public ArrayList GetCart()
          {
              string sqlQuery = "SELECT * FROM Orders INNER JOIN Carts ON Orders.orderID = Carts.cartOrderID " + "WHERE Orders.orderID=@ID";
              //"SELECT * FROM Products INNER JOIN Locations ON Locations.locationID = Products.productLocationID" + "WHERE locationID=@locationID" + "AND productID=@productID";


              int orderID = Convert.ToInt32(Console.ReadLine());

              //Using SqlConnection to establish connection to database
              //using SqlCommand passing in the SqlConnection and the sqlQuery
              using (SqlConnection con = new SqlConnection(CONNECTION))

              using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
              {
                  cmd.Parameters.Add("@ID", SqlDbType.Int).Value = orderID;

                  //open the connection
                  con.Open();


                  //SqlDataReader is used because we are reading data from the database
                  using (SqlDataReader reader = cmd.ExecuteReader())
                  {
                      //while there are records in the database


                      while (reader.Read())
                      {

                          List<CartsModel> cartslist = new List<CartsModel>();
                          List<ProductsModel> productslist = new List<ProductsModel>();
                          List<OrdersModel> orderslist = new List<OrdersModel>();

                          //store each value into the properties of productViewModel

                          CartsModel carts = new CartsModel()
                          {
                              cartProductID = Convert.ToInt32(reader["cartProductID"]),


                          };

                          OrdersModel orders = new OrdersModel()
                          {
                              orderID = Convert.ToInt32(reader["orderID"]),


                          };

                          ProductsModel products = new ProductsModel()
                          {

                              productID = Convert.ToInt32(reader["productID"]),
                              productName = reader["productName"].ToString(),

                              productPrice = Convert.ToDouble(reader["productPrice"]),
                              productQuantity = Convert.ToInt32(reader["ProductQuantity"]),

                              productLocationID = Convert.ToInt32(reader["productLocationID"])

                          };

                          ArrayList array = new ArrayList();
                          //Add the product object to the List of product
                          array.Add(products);
                          array.Add(orders);
                          array.Add(carts);

                          Console.WriteLine("       +================================================================+");
                          Console.WriteLine("       +----------------------------------------------------------------+");
                          Console.WriteLine("        PRODUCT ID       " + " | " + products.productID);
                          Console.WriteLine("        PRODUCT NAME     " + " | " + products.productName);
                          Console.WriteLine("        PRODUCT PRICE    " + " | " + products.productPrice);
                          Console.WriteLine("        PRODUCT QUANTITY " + " | " + carts.cartQuantity);
                          Console.WriteLine("        PRODUCT ORDERDATE" + " | " + orders.orderDate);
                          Console.WriteLine("        ORDER ID         " + " | " + orders.orderID);
                          Console.WriteLine("        ORDERDATE        " + " | " + orders.orderDate);
                          Console.WriteLine("       +----------------------------------------------------------------+");


                          foreach (ProductsModel line in array)
                          {
                              Console.WriteLine(line.productCartID);

                          }


                      }
        */





    }

}
  
    


    

