using FoodStore.StoreBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class CartsMenu
    {
        public void viewCartMenu()
        {
            var cartmenu = new CartsMenu();
            var mainMenu = new MainMenu();
            int input = 0;

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                         SHOPPING CART MENU                     |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] VIEW ORDERS MENU                        |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] ADD AN ORDER                            |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] VIEW ORDERS HISTORY                     |");
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
            var cart = new CartsLogic();
            var products = new ProductsLogic();


            switch (input)
            {
                case 1:

                    break;

                case 2:

                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        ADD TO SHOPPING CART                    |");
                    Console.WriteLine("       +----------------------------------------------------------------+");
                    products.GetProducts();
                    cart.Add();
                    cart.Add();
                    mainMenu.viewMainMenu();

                    break;

                case 3:
                    // products.GetProducts();
                    cart.GetInventoryByCartOrderID();

                    cartmenu.viewCartMenu();

                    mainMenu.viewMainMenu();



                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                   DELETE A ORDER FROM INVENTORY                |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    cart.Delete();
                    break;


                case 5:


                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        CREATE AN ORDER                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("        Choose an item to add to cart");

                    // products.GetProducts();
                    cart.GetInventoryByCartOrderID();

                    cartmenu.viewCartMenu();

                    mainMenu.viewMainMenu();
                    break;


                default:

                    Console.Clear();
                    var mainmenu = new MainMenu();
                    mainmenu.viewMainMenu();
                    break;


            }
        }

        public void addproductCart()
        {
            int input = 0;
            input = Int32.Parse(Console.ReadLine());
            var cart = new CartsLogic();
            var products = new ProductsLogic();


            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |             WELCOME TO JOY LORUTH'S GROCERY STORE              |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] ADD ANOTHER PRODUCT                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] MAIN MENU                                  |");
            Console.WriteLine("       +----------------------------------------------------------------+");

            input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                    products.GetProducts();
                    cart.Add();

                    break;

                case 2:
                    Console.Clear();


                    break;

                default:
                    var mainMenu2 = new MainMenu();
                    mainMenu2.viewMainMenu();
                    break;

            }

        }
    }
}

