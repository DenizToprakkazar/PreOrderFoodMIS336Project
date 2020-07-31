using PreOrderFoodMIS336Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreOrderFoodMIS336Project.Repository
{
    public class CustomerRepository
    {

        private PreOrderFoodEntities objpreOrderFoodEntities;


        public CustomerRepository()
        {

            objpreOrderFoodEntities = new PreOrderFoodEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {


            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in objpreOrderFoodEntities.Customer
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
    }
}