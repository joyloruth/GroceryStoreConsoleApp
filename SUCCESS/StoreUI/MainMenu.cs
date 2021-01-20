using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class MainMenu
    {

        public void viewMainMenu()
        {
            int input = 0;



            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |             WELCOME TO JOY LORUTH'S GROCERY STORE              |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] GO TO PRODUCT CATALOG                   |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] CREATE AN ORDER                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] SIGN UP                                 |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [4] FIND A LOCATION                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5] VIEW SHOPPING CART                      |");
            Console.WriteLine("       +----------------------------------------------------------------+");








            input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                    var productsMenu = new ProductsMenu();
                    productsMenu.viewProductMenu();
                    break;

                case 2:
                    Console.Clear();
                    var ordersMenu = new OrdersMenu();
                    ordersMenu.viewOrdersMenu();
                    break;

                case 3:
                    Console.Clear();
                    var customersMenu = new CustomersMenu();
                    customersMenu.viewCustomersMenu();
                    break;

                case 4:
                    Console.Clear();
                    var locationsMenu = new LocationsMenu();
                    locationsMenu.viewLocationsMenu();
                    break;
                case 5:
                    Console.Clear();
                    var cartsMenu = new CartsMenu();
                    cartsMenu.viewCartMenu();
                    break;

                default:
                    var mainMenu = new MainMenu();
                    mainMenu.viewMainMenu();
                    break;
            }
        }


        public void viewMainMenu1()
        {
            int input = 0;



            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |             WELCOME TO JOY LORUTH'S GROCERY STORE              |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] MANAGER                                 |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] GUEST                                   |");
            Console.WriteLine("       +----------------------------------------------------------------+");

            input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                    var managerMenu = new ManagerMenu();
                    managerMenu.managerMainMenu();
                    break;

                case 2:
                    Console.Clear();
                    var mainMenu = new MainMenu();
                    mainMenu.viewMainMenu();
                    break;

                default:
                    var mainMenu2 = new MainMenu();
                    mainMenu2.viewMainMenu();
                    break;

            }

        }
    }
}

