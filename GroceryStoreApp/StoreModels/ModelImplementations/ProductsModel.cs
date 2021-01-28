using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreModels
{
    class ProductsModel 
    {
        public int productID { get; set; }
        public string productName { get; set; }

        public int productQuantity;
        public double productPrice { get; set; }

        public int productLocationID{ get; set; }

        public int productOrderID { get; set; }
      
       // public List<ProductsModel> productCartID { get; set; }

        //public List<ProductsModel> productslist;






        public int Addstock(int amount)
        {

            amount = 0;
            productQuantity = amount + productQuantity;

            return productQuantity;
        }

        public int WithdrawStock(int amount)
        {
           productQuantity = amount -= productQuantity;

            return productQuantity;
        }
    
}
}
