using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreModels
{
    interface IProductsInterface
    {
        public int productID { get; set; }

        public string productName { get; set; }

        public int productQuantity { get; set; }

        public double productPrice{ get; set; }
    }

}
