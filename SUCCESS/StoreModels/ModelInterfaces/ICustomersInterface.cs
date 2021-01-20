using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreModels
{
    interface ICustomersInterface
    {
        public long customerID { get; set; }

        public string customerUserName { get; set; }

        public string customerPassword { get; set; }

        public string customerEmail { get; set; }
    }
}
