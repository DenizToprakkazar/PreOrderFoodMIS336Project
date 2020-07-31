using PreOrderFoodMIS336Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreOrderFoodMIS336Project.Repository
{
    public class ItemRepository
    {
        private PreOrderFoodEntities objpreOrderFoodEntities;
   

        public ItemRepository()
        {
        
            objpreOrderFoodEntities = new PreOrderFoodEntities();
            }

        public IEnumerable<SelectListItem> GetAllItems()
         {


            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in objpreOrderFoodEntities.Item
                                  select new SelectListItem()
                                  {
                                      Text = obj.itemName,
                                      Value = obj.ItemID.ToString(),
                                      Selected = false
                                  }).ToList();

            return objSelectListItems;
         }

    }
}