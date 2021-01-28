using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore.StoreModels
{
    class LocationsModel 
    {
        public long locationID { get; set; }

        public string locationName { get; set; }

        public long locationPhone { get; set; }

        public string locationCity { get; set; }

        public string locationState { get; set;}

        public string locationDistrict { get; set;}
    }
}
