using FoodStore.StoreBL;
using FoodStore.StoreDAL;
using FoodStore.StoreModels;
using FoodStore.StoreUI;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Serilog;
using System.Collections;

namespace FoodStore
{
    class Start
    {
        public static List<OrdersModel> ShoppingCart { get; set; }
        static void Main(string[] args)
        {
            var mainmenu = new MainMenu();
             mainmenu.viewMainMenu();

           

           


            
            
            

           
            //pm.Addstock(30);
            //pm.WithdrawStock(20);
            //Console.WriteLine(pm.stock);

            

            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Joy\logs\LogFile.log").CreateLogger();
            
            Log.Information("This is sample information");

            try
            {
                int a = 2;
                int b = 0;
                Log.Debug("The values are {0} and {0}", a, b);
                int c = a / b;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Some error occurred");
            }

            Log.CloseAndFlush();
            Console.WriteLine("Completed");
            Console.ReadKey();


           

            
        }

       



         public static void AddToCart(ProductsModel item)
         {
               /// ShoppingCart.Add(new ProductsModel() { productID = item.productID, productQuantity = item.productQuantity });
         }


        

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(@"log.txt")
                 .CreateLogger();
        }
    }

}

            







































        





    