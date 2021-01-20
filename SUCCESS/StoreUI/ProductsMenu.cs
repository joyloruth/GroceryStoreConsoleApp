using FoodStore.StoreBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreUI
{
    class ProductsMenu
    {
        public void viewProductMenu()
        {
            int input = 0;
            var product = new ProductsLogic();

            var mainMenu = new MainMenu();
            


          


            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       |                        PRODUCTS MENU                           |");
            Console.WriteLine("       |                                                                |");
            Console.WriteLine("       +================================================================+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [1] VIEW PRODUCT CATALOG                    |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [2] ADD A PRODUCT                           |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [3] FIND A PRODUCT                          |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [4] DELETE A PRODUCT                        |");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("       +----------------------------------------------------------------+");
            Console.WriteLine("       |                    [5] RETURN TO MAIN MENU                     |");
            Console.WriteLine("       +----------------------------------------------------------------+");



            input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                        VIEW PRODUCT CATALOG                    |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    product.GetProducts();
                    mainMenu.viewMainMenu();

                   

                    break;

                case 2:
                    
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                    ADD A PRODUCT TO INVENTORY                  |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    product.AddProducttoCart();
                    mainMenu.viewMainMenu();


                    break;



                case 3:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                   GET A PRODUCT IN INVENTORY                  |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    product.GetProductByID();
                    mainMenu.viewMainMenu();


                    break;

               
                
                case 4:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                  DELETE A PRODUCT FROM INVENTORY               |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    product.DeleteProduct();
                    mainMenu.viewMainMenu();

                    break;

                case 5:
                    Console.Clear();

                    Console.WriteLine("       +----------------------------------------------------------------+");
                    Console.WriteLine("       |                  GET A PRODUCT BY LOCATION                     |");
                    Console.WriteLine("       +----------------------------------------------------------------+");

                    product.Gwrong();

                    break;

                case 6:
                    Console.Clear();

                    product.EditProduct();

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