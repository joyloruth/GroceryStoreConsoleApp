using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class ManagerMenu
    {
        public void managerMainMenu()
        {
            int input = 0;



            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                        MANAGER  lOGIN                          |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] LOGIN                                   |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] ADD INVENTORY                           |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] REMOVE INVENTORY                        |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [4]                                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5]                                         |");
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
    }
}
    
