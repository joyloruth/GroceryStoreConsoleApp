using FoodStore.StoreModels;
using FoodStore.StoreModels.ModelImplementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreBL
{
    class LocationsLogic : ILogics
    {

        string CONNECTION = @"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True";
        public int Add()
        {
            SqlConnection cn = new SqlConnection(CONNECTION);

            //Open Connection
            cn.Open();
            int locationID;
            string locationName, locationPhone, locationCity, locationState, locationDistrict;

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter the Location Number.                  ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Location Name                                             ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationName = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter Location Contact Number.                                 ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationPhone = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter Location City.                                           ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationCity = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter Location State.                                           ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationState = Console.ReadLine();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter Location District                                          ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            locationDistrict = Console.ReadLine();



            
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            SqlCommand cmd = new SqlCommand("INSERT INTO locations VALUES('" + locationID + "','" + locationName + "','" + locationPhone + "','" + locationCity + "','" + locationState + "','" + locationDistrict + "')", cn);


            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Console.WriteLine();
                Console.WriteLine("        Location Successfully Created.");
                Console.WriteLine("                                     ");
                Console.WriteLine("        LOCATION ID : " + locationID);
                Console.WriteLine("        LOCATION NAME : " + locationName);
                Console.WriteLine("        LOCATION PHONE : " + locationPhone);
                Console.WriteLine("        LOCATION CITY :" + locationCity);
                Console.WriteLine("        LOCATION STATE : " + locationState);
                Console.WriteLine("        LOCATION DISTRICT : " + locationDistrict);



            }
            cn.Close();
            { return i; }
        }

        public int Delete()
        {
            Console.WriteLine("Enter Location ID # you would like to delete.");
            int ID = Convert.ToInt32(Console.ReadLine());
            string sqlQuery = "DELETE from orders Where orderID=@ID";

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                return cmd.ExecuteNonQuery();


            }
        }

        public int Edit()
        {
            throw new NotImplementedException();
        }


        string _connectionString = @"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True";
        public List<LocationsModel> GetAll()
        {
            //SQL command for selecting all from customers table
            string sqlQuery = "SELECT * FROM Locations";
            

            //Empty list of customersModel to add and return
            List<LocationsModel> locations = new List<LocationsModel>();

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
                        //store each value into the properties of customersViewModel
                        LocationsModel temp = new LocationsModel()
                        {
                            locationID = Convert.ToInt64(reader["locationID"]),
                            locationName = reader["locationName"].ToString(),
                            locationPhone = Convert.ToInt64(reader["locationPhone"].ToString()),
                            locationCity = reader["locationCity"].ToString(),
                            locationState = reader["locationState"].ToString(),
                            locationDistrict = reader["locationDistrict"].ToString()

                        };
                        //Add the customers object to the List of customers

                        locations.Add(temp);



                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        LOCATION ID   " + " | " + temp.locationID);
                        Console.WriteLine("        LOCATION NAME " + " | " + temp.locationName);
                        Console.WriteLine("        LOCATION PHONE" + " | " + temp.locationPhone);
                        Console.WriteLine("        LOCATION CITY " + " | " + temp.locationCity);
                        Console.WriteLine("        LOCATION STATE" + " | " + temp.locationState);
                        Console.WriteLine("        LOCATION DISTRICT " + " | " + temp.locationDistrict);
                        Console.WriteLine("       +----------------------------------------------------------------+");

                    }
                }
            }
            return locations;
        }

        void ILogics.GetAll()
        {
            throw new NotImplementedException();
        }



        public LocationsModel GetInventoryByLocationID()
        {
            LocationsModel location = new LocationsModel();
            ProductsModel inventory = new ProductsModel();

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Location ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long productID = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Product ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long locationID = Convert.ToInt64(Console.ReadLine());

            string sqlQuerys = "Select * from locations where locationID=@ID";

            string sqlQuery = "SELECT * FROM Products INNER JOIN Locations ON Locations.locationID = Products.productLocationID" + "WHERE locationID=@locationID" + "AND productID=@productID";


            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@locationID", SqlDbType.Int).Value = locationID;
                cmd.Parameters.Add("@productID", SqlDbType.Int).Value = productID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        location.locationID = Convert.ToInt32(reader["locationID"]);
                        location.locationName = reader["locationName"].ToString();
                        location.locationPhone = Convert.ToInt32(reader["locationID"]);
                        location.locationCity = reader["locationName"].ToString();
                        location.locationState = reader["locationName"].ToString(); ;
                        location.locationDistrict = reader["locationDistrict"].ToString();

                        inventory.productID = Convert.ToInt32(reader["productID"]);
                        inventory.productQuantity = Convert.ToInt32(reader["productQuantity"]);

                    }

                    {

                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        LOCATION ID       " + " | " + locationID);
                        Console.WriteLine("        LOCATION NAME     " + " | " + location.locationName);
                        Console.WriteLine("        LOCATION PHONE    " + " | " + location.locationPhone);
                        Console.WriteLine("        LOCATION STATE    " + " | " + location.locationState);
                        Console.WriteLine();
                        Console.WriteLine("        PRODUCT ID        " + " | " + productID);
                        Console.WriteLine("        PRODUCT NAME      " + " | " + inventory.productName);
                        Console.WriteLine("        PRODUCT QUANTITY  " + " | " + inventory.productQuantity);
                        

                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();

                    }
                }
                return location;
            }
        }

        public OrdersModel GetOrdersByLocationID()
        {
            OrdersModel location = new OrdersModel();
            OrderLocationsModel inventory = new OrderLocationsModel();

            //Console.WriteLine("       +----------------------------------------------------------------+");
            //Console.WriteLine("         Enter your Location ID Number ");
            //Console.WriteLine("       +----------------------------------------------------------------+");
            //long productID = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("         Enter your Location ID Number ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            long locationID = Convert.ToInt64(Console.ReadLine());

            //string sqlQuerys = "Select * from locations where locationID=@ID";

            string sqlQuery = "SELECT * FROM OrderLocations INNER JOIN Locations ON OrderLocations.locationID = Locations.LocationID" + "WHERE locationID=@locationID";

           
            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(CONNECTION))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@locationID", SqlDbType.Int).Value = locationID;
                //cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = locationID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        location.orderID = Convert.ToInt32(reader["locationID"]);
                        

                        inventory.locationID = Convert.ToInt32(reader["productID"]);
                        inventory.orderID= Convert.ToInt32(reader["productQuantity"]);

                    }

                    {

                        Console.WriteLine();
                        Console.WriteLine("       +================================================================+");
                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine("        LOCATION ID       " + " | " + locationID);
                        Console.WriteLine("        LOCATION NAME     " + " | " + location.orderDate);
                        Console.WriteLine("        LOCATION PHONE    " + " | " + location.orderID);
                       
                        

                        Console.WriteLine("       +----------------------------------------------------------------+");
                        Console.WriteLine();

                    }
                }
                return location;
            }
        }

    }
}

    
