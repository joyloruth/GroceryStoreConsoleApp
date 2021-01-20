using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FoodStore.StoreDB
{
    class SQL
    {
        SqlConnection cn = new SqlConnection(@"Data Source = GLENDOWN\SQLEXPRESS; Initial Catalog = GroceryStore; Integrated Security = True");
    }
}
