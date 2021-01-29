using FoodStore.StoreBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class OrdersMenu
    {
        public void viewOrdersMenu()
        {
            int input = 0;

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                         ORDERS MENU                            |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] VIEW ORDERS HISTORY                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] ADD AN ORDER                            |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3]                                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [4] DELETE AN ORDER                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5] RETURN TO MAIN MENU                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");





            input = Int32.Parse(Console.ReadLine());
            var order = new OrdersLogic();
            var products = new ProductsLogic();

            switch (input)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                          ORDER CATALOG                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");


                    order.GetOrders();
                    break;

                case 2:

                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        CREATE AN ORDER                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    order.Add();
                    break;

                case 3:
                    
                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                   DELETE A ORDER FROM INVENTORY                |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    order.Delete();
                    break;


                case 5:

               
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        CREATE AN ORDER                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("        Choose an item to add to cart");
                    
                    //products.GetProducts();
                    //order.GetCart();
                    break;


                default:

                    Console.Clear();
                    var mainmenu = new MainMenu();
                    mainmenu.viewMainMenu();
                    break;

                    
            }
        }
    }
}
