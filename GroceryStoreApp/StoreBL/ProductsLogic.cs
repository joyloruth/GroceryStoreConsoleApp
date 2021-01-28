using FoodStore.StoreModels;
using FoodStore.StoreUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreBL


{
    class ProductsLogic

    {
        //Connection string
        string CONNECTION = @"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True";

        //Empty list of productViewModel to add and return
        List<ProductsModel> productslist = new List<ProductsModel>();

        public ProductsLogic()
        {
            products = new List<ProductsModel>();
        }


        private List<ProductsModel> products;




        ////GET PRODUCTS////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Returns a list of all products

        public List<ProductsModel> GetProducts()
        {
            string sqlQuery = "SELECT * FROM products";






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
                        ProductsModel temp = new ProductsModel()
                        {
                            productID = Convert.ToInt32(reader["productID"]),
                            productName = reader["productName"].ToString(),

                            productPrice = Convert.ToDouble(reader["productPrice"]),
                            productQuantity = Convert.ToInt32(reader["ProductQuantity"]),

                            productLocationID = Convert.ToInt32(reader["productLocationID"])

                        };

                        //Add the product object to the List of product
                        productslist.Add(temp);

                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        PRODUCT ID       " + " | " + temp.productID);
                        Console.WriteLine("        PRODUCT NAME     " + " | " + temp.productName);
                        Console.WriteLine("        PRODUCT PRICE    " + " | " + temp.productPrice);
                        Console.WriteLine("        PRODUCT QUANTITY " + " | " + temp.productQuantity);
                        Console.WriteLine("        PRODUCT LOCATION " + " | " + temp.productLocationID);
                        Console.WriteLine("       +----------------------------------------------------------------+");


                    }
                }
            }
            return productslist;
        }




        ////DELETE PRODUCT//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Removes a product by its productID
        public int DeleteProduct()
        {
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Order Identification Number you would like to Remove. ");
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
                try
                {
                    if (success > 0)
                    {
                        Console.WriteLine("Successfully Remove Inventory");
                        Console.WriteLine("Product ID: " + ID);

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    var mm = new MainMenu();
                    mm.viewMainMenu();
                }
                return success;


            }

        }



        ////ADD PRODUCT///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Saves product to database

        public int AddProduct()
        {

            SqlConnection cn = new SqlConnection(CONNECTION);


            cn.Open();


            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Order Identification Number.                          ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Name.                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            string productName = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Quantity ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            int productQuantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Price amount. ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            double productPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Location ID ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            int productLocationID = Convert.ToInt32(Console.ReadLine());


            SqlCommand cmd = new SqlCommand("INSERT INTO products VALUES('" + productID + "','" + productName + "','" + productPrice + "','" + productQuantity + "','" + productLocationID + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine();
                Console.WriteLine("The product(s) listed below has successfully added to the inventory:");
                Console.WriteLine();
                Console.WriteLine("Product ID: " + productID);
                Console.WriteLine("Product Name: " + productName);
                Console.WriteLine("Product Price: " + productPrice);
                Console.WriteLine("Product Quantity: " + productQuantity);
                Console.WriteLine("Product LocationID: " + productLocationID);
            }
            cn.Close();
            { return i; }
        }




        ////GET PRODUCT BY ID ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Retrieves product by ID
        public ProductsModel GetProductByID()
        {
            ProductsModel product = new ProductsModel();
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productID = Convert.ToInt32(Console.ReadLine());

            string sqlQuery = "Select * from products where productID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productID;

                //SqlDataReader is used because we are reading data from the database
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.productID = Convert.ToInt32(reader["productID"]);
                        product.productName = reader["productName"].ToString();
                        product.productPrice = Convert.ToDouble(reader["productPrice"]);
                        product.productQuantity = Convert.ToInt32(reader["productQuantity"]);
                        product.productLocationID = Convert.ToInt32(reader["productLocationID"]);

                        Console.WriteLine("Add Product quantity");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        product.Addstock(amount);

                    }

                    {




                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        PRODUCT ID       " + " | " + productID);
                        Console.WriteLine("        PRODUCT NAME     " + " | " + product.productName);
                        Console.WriteLine("        PRODUCT PRICE    " + " | " + product.productPrice);
                        Console.WriteLine("        PRODUCT QUANTITY " + " | " + product.productQuantity);
                        Console.WriteLine("        PRODUCT LOCATION " + " | " + product.productLocationID);

                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();

                    }
                }
                return product;
            }
        }



        public int EditProduct()
        {
            ProductsModel edit = new ProductsModel();

            string sqlQuery = "Update products Set productName=@productName, productPrice=@productPrice, " +
               "productQuantity=@productQuantity Where productID=@productID";

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product Name ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product Price ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product Quantity ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Location ID ");
            Console.WriteLine("       +----------------------------------------------------------------+");

            long productID = Convert.ToInt32(Console.ReadLine());

            string productName = Console.ReadLine();
            double productPrice = Convert.ToDouble(Console.ReadLine());
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            long productLocationID = Convert.ToInt32(Console.ReadLine());




            //No need to use SqlDataReader here since we are just using the Sql Query to persist to database

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                //Open connection
                con.Open();
                cmd.Parameters.Add("@productID", SqlDbType.Int).Value = edit.productID;
                cmd.Parameters.Add("@productName", SqlDbType.VarChar).Value = edit.productName;

                cmd.Parameters.Add("@productPrice", SqlDbType.Int).Value = edit.productPrice;
                cmd.Parameters.Add("@productQuantity", SqlDbType.Int).Value = edit.productQuantity;
                cmd.Parameters.Add("@productLocationID", SqlDbType.Int).Value = edit.productLocationID;

                Console.WriteLine(productName);

                return cmd.ExecuteNonQuery();
            }


        }
        public ProductsModel Gwrong()
        {
            List<ProductsModel> products = new List<ProductsModel>();
            ProductsModel product = new ProductsModel();




            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Location ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productLocationID = Convert.ToInt32(Console.ReadLine());

            string sqlQuery = "Select * from products where productLocationID=@productLocationID";

            //Using SqlConnection to establish connection to database
            using (SqlConnection con = new SqlConnection(CONNECTION))

            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@productLocationID", SqlDbType.Int).Value = productLocationID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductsModel temp = new ProductsModel();
                        {
                            product.productID = Convert.ToInt32(reader["productID"]);
                            product.productName = reader["productName"].ToString();
                            product.productPrice = Convert.ToDouble(reader["productPrice"]);
                            product.productQuantity = Convert.ToInt32(reader["productQuantity"]);
                            product.productLocationID = Convert.ToInt32(reader["productLocationID"]);
                        }

                        products.Add(product);


                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        PRODUCT ID       " + " | " + product.productID);
                        Console.WriteLine("        PRODUCT NAME     " + " | " + product.productName);
                        Console.WriteLine("        PRODUCT PRICE    " + " | " + product.productPrice);
                        Console.WriteLine("        PRODUCT QUANTITY " + " | " + product.productQuantity);
                        Console.WriteLine("        PRODUCT LOCATION " + " | " + product.productLocationID);

                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();


                    }

                }
                return product;
            }
        }

        public ProductsModel GetProductByLocationID()
        {
            List<ProductsModel> products = new List<ProductsModel>();
            ProductsModel product = new ProductsModel();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Location ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productID = Convert.ToInt32(Console.ReadLine());

            string sqlQuery = "Select * from products where productLocationID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery

            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductsModel temp = new ProductsModel();
                        {
                            product.productID = Convert.ToInt32(reader["productID"]);
                            product.productName = reader["productName"].ToString();
                            product.productPrice = Convert.ToDouble(reader["productPrice"]);
                            product.productQuantity = Convert.ToInt32(reader["productQuantity"]);
                            product.productLocationID = Convert.ToInt32(reader["productLocationID"]);


                        }
                        products.Add(temp);




                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        PRODUCT ID       " + " | " + productID);
                        Console.WriteLine("        PRODUCT NAME     " + " | " + product.productName);
                        Console.WriteLine("        PRODUCT PRICE    " + " | " + product.productPrice);
                        Console.WriteLine("        PRODUCT QUANTITY " + " | " + product.productQuantity);
                        Console.WriteLine("        PRODUCT LOCATION " + " | " + product.productLocationID);

                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();

                    }
                }
                return product;


            }
        }

        public List<ProductsModel> Cart()
        {
            string sqlQuery = "SELECT * FROM products WHERE P";






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
                        ProductsModel temp = new ProductsModel()
                        {
                            productID = Convert.ToInt32(reader["productID"]),
                            productName = reader["productName"].ToString(),

                            productPrice = Convert.ToDouble(reader["productPrice"]),
                            productQuantity = Convert.ToInt32(reader["ProductQuantity"]),

                            productLocationID = Convert.ToInt32(reader["productLocationID"])

                        };

                        //Add the product object to the List of product
                        productslist.Add(temp);

                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        PRODUCT ID       " + " | " + temp.productID);
                        Console.WriteLine("        PRODUCT NAME     " + " | " + temp.productName);
                        Console.WriteLine("        PRODUCT PRICE    " + " | " + temp.productPrice);
                        Console.WriteLine("        PRODUCT QUANTITY " + " | " + temp.productQuantity);
                        Console.WriteLine("        PRODUCT LOCATION " + " | " + temp.productLocationID);
                        Console.WriteLine("       +----------------------------------------------------------------+");

                        foreach (ProductsModel line in productslist)
                        {
                            List<ProductsModel> secondlist = new List<ProductsModel>();



                            ProductsModel temp2 = new ProductsModel()
                            {
                                productID = Convert.ToInt32(reader["productID"]),
                                productName = reader["productName"].ToString(),

                                productPrice = Convert.ToDouble(reader["productPrice"]),
                                productQuantity = Convert.ToInt32(reader["ProductQuantity"]),

                                productLocationID = Convert.ToInt32(reader["productLocationID"])

                            };

                            secondlist.Add(temp2);
                        }
                    }
                }
            }
            return productslist;

        }
        public int AddProducttoCart()
        {

            SqlConnection cn = new SqlConnection(CONNECTION);


            cn.Open();


            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Order Identification Number.                          ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Name.                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            string productName = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Quantity ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            int productQuantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Price amount. ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            double productPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Product Location ID ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            int productLocationID = Convert.ToInt32(Console.ReadLine());


            SqlCommand cmd = new SqlCommand("INSERT INTO products VALUES('" + productID + "','" + productName + "','" + productPrice + "','" + productQuantity + "','" + productLocationID + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine();
                Console.WriteLine("The product(s) listed below has successfully added to the inventory:");
                Console.WriteLine();
                Console.WriteLine("Product ID: " + productID);
                Console.WriteLine("Product Name: " + productName);
                Console.WriteLine("Product Price: " + productPrice);
                Console.WriteLine("Product Quantity: " + productQuantity);
                Console.WriteLine("Product LocationID: " + productLocationID);
            }
            cn.Close();
            { return i; }
        }

    }
}















