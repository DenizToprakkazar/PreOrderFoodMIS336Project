using PreOrderFoodMIS336Project.Models;
using PreOrderFoodMIS336Project.Repository;
using PreOrderFoodMIS336Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreOrderFoodMIS336Project.Controllers
{
    public class HomeController : Controller
    {
        private PreOrderFoodEntities objPreOrderFoodEntities;

        public HomeController()
        {
            objPreOrderFoodEntities = new PreOrderFoodEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentRepository objPaymentRepository = new PaymentRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentRepository.GetAllPaymentType());
            return View(objMultipleModels);
           
            


        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int ItemID)
        {
            Nullable<decimal> UnitPrice = objPreOrderFoodEntities.Item.SingleOrDefault( model => model.ItemID == ItemID).itemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objorderRepository = new OrderRepository();
            objorderRepository.AddOrder(objOrderViewModel);
            return Json(data: "Order Created", JsonRequestBehavior.AllowGet);
        }
    }
}