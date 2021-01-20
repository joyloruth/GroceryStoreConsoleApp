using FoodStore.StoreBL;
using FoodStore.StoreModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class LocationsMenu
    {
        
        public void viewLocationsMenu()
        {
            var location = new LocationsLogic();
            int input = 0;


            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                       LOCATIONS MENU                           |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] VIEW ALL LOCATION(S)                    |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] ADD AN LOCATION                         |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] EDIT AN LOCATION                        |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [4] DELETE AN LOCATION                      |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5] VIEW ORDER HISTORY                      |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [6] RETURN TO MAIN MENU                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");

            input = Int32.Parse(Console.ReadLine());
            

            switch (input)
            {
                case 1:
                    Console.Clear();
                    
                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        VIEW LOCATION CATALOG                   |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    location.GetAll();
                    
                    break;

                
                case 2:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                       REGISTER A NEW LOCATION                  |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    location.Add();

                    break;

                case 3:

                    location.Delete();

                    break;

                case 4:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                       Inventory A NEW LOCATION                  |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    location.GetInventoryByLocationID();

                    break;

                case 5:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        VIEW LOCATION ORDER HISTORY             |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    location.GetOrdersByLocationID();

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

