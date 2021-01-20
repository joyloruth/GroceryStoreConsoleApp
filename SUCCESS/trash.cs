using FoodStore.StoreDAL;
using FoodStore.StoreModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStore
{
    class trash
    {
        private CustomerDAL data;

        //Constructor that accepts a connectionString from the Presentation Layer,
        //Use the connectionString to pass into a new instance of the Data Access Layer class
        //customersDAL
        public trash(string connectionString)
        {
            data = new CustomerDAL(connectionString);
        }

        public trash()
        {
        }

        //Gets all customers in a List of CustomersModel
        public List<CustomersModel> GetAllCustomers()
        {
            //return the List<CustomersModel> from customersDAL
            
            List<CustomersModel> customers = data.GetCustomers();
            foreach (var item in customers)
            {
                //for each item take the Height and CellNbr values,
                //use the HeightDisplay and PhoneDisplay methods
                //and store the returned values from the methods
                //into the HeightDisplay and PhoneDisplay properties of the item.
                //The DisplayHeight is done for you.
                item.customerUserName = (item.customerUserName);
            }
            return customers;
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }


        public int AddCustomer()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public int AddItem()
        {
            throw new NotImplementedException();
        }
    }
}