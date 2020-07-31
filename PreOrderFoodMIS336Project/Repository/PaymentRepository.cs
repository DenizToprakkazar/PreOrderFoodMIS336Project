using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using PreOrderFoodMIS336Project.Models;
using System.Web.Mvc;

namespace PreOrderFoodMIS336Project.Repository
{
    public class PaymentRepository
    {

        private PreOrderFoodEntities objpreOrderFoodEntities;

        public PaymentRepository()
        {
            objpreOrderFoodEntities = new PreOrderFoodEntities();
           }

        public IEnumerable<SelectListItem> GetAllPaymentType()
            {


            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in objpreOrderFoodEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentType,
                                      Value = obj.PaymentTypeID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
    }

}