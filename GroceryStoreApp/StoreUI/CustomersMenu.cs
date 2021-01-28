using FoodStore.StoreBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class CustomersMenu
    {
        public void viewCustomersMenu()
        {
            int input = 0;


            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                       CUSTOMERS MENU                           |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] VIEW CUSTOMER CATALOG                   |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] CREATE AN ACCOUNT                       |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] FIND AN ACCOUNT                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] DELETE ACCOUNT                          |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5] RETURN TO MAIN MENU                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");

            input = Int32.Parse(Console.ReadLine());

            var customer = new CustomersLogic();

            switch (input)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                       CREATE A ACCOUNT                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    customer.GetCustomers();

                    break;

                case 2:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                       CREATE A ACCOUNT                         |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    customer.Add();
                    break;

                case 3:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                         FIND AN ACCOUNT                        |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    customer.GetCustomerById();
                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                       DELETE AN ACCOUNT                        |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    customer.Delete();
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

