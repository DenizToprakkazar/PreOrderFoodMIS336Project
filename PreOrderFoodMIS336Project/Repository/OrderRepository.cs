using PreOrderFoodMIS336Project.Models;
using PreOrderFoodMIS336Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreOrderFoodMIS336Project.Repository
{
    public class OrderRepository
    {
        private PreOrderFoodEntities objpreOrderFoodEntities;
        public OrderRepository()
            {
            objpreOrderFoodEntities = new PreOrderFoodEntities();
            }
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Orders objOrder = new Orders();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objpreOrderFoodEntities.Orders.Add(objOrder);
            objpreOrderFoodEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailsVİewModel)
            {
                Order_Details objOrderDetail = new Order_Details();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                
                objOrderDetail.UnitPrice = item.UnitPrice;
                //objOrderDetail.Quantity = item.Quantity;
                objpreOrderFoodEntities.Order_Details.Add(objOrderDetail);
                objpreOrderFoodEntities.SaveChanges();


            }


            return true;
        }
    }

}