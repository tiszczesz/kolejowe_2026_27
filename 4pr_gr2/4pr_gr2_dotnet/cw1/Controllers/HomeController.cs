using cw1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw1.controllers
{
    public class HomeController : Controller
    {
        private RentalRepo _db ;
        public HomeController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("mysql");
            _db = new RentalRepo(connectionString);
        }
       
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var items = _db.GetAllItems();
            return View(items);
        }
        [HttpGet]
        public ActionResult Rental(int id)
        {
            var viewModel = new RentalViewModel();
            viewModel.ActualItem = _db.GetItemById(id);
            return View(viewModel);
        }  
        [HttpPost]
        public ActionResult Rental(RentalViewModel vm)
        {
            vm.ActualItem = _db.GetItemById(vm.ActualItem.Id);
            vm.MyRentalItem.ActualItem = vm.ActualItem;
            vm.MyRentalItem.ItemId = vm.ActualItem.Id;
          //  if (ModelState.IsValid)
            {
              

                // Save the rental item to the database
                var rentalItem = new RentalItem
                {
                    ItemId = vm.ActualItem.Id,
                    Duration = vm.MyRentalItem.Duration,
                    Description = vm.MyRentalItem.Description
                };
                // Here you would typically call a method in your repository to save the rental item
                 _db.SaveRentalItem(rentalItem);
                return RedirectToAction("RentalList");
            }
            return View(vm);
        }  
        
        public ActionResult RentalList()
        {
            var rentalItems = _db.GetAllRentalItems();
            return View(rentalItems);
        }

    }
}
