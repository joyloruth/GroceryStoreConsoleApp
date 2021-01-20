using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreModels.ModelImplementations
{
    class ManagerModel
    {
        public long managerID { get; set; }
        public string managerUserName { get; set; }
        public string managerPassword { get; set; }

        HashMap<string, string> map = new HashMap<string, string>();


    }

    
    
    
}
