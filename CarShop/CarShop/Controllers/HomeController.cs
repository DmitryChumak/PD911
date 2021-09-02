using CarShop.Models;
using CarShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        CarContext context;
        public HomeController(CarContext context)
        {
            this.context = context;
        }

        //public IActionResult Index(SortType sortType = SortType.TitleAsc, string company = "(all)")
        //{
        //    var selectListItems = new List<string> { "(all)" };
        //    selectListItems.AddRange(context.Cars.Select(x => x.Title).Distinct());
        //    IEnumerable<Car> cars = null;
        //    switch (sortType)
        //    {
        //        case SortType.TitleAsc:
        //            cars = context.Cars.OrderBy(x => x.Title).ToList();
        //            break;
        //        case SortType.ModelAsc:
        //            cars = context.Cars.OrderBy(x => x.Model).ToList();
        //            break;
        //        case SortType.PriceAsc:
        //            cars = context.Cars.OrderBy(x => x.Price).ToList();
        //            break;
        //    }
        //    if (!company.ToLower().Contains("all"))
        //    {
        //        cars = cars.Where(x => x.Title.ToLower() == company.ToLower());
        //    }
        //    return View(new CarListViewModel
        //    {
        //        Cars = cars.ToList(),
        //        Companies = new SelectList(selectListItems)
        //    });

        //}



        public IActionResult Index()
        {
            return View();           
        }


        public IActionResult CarsJson()
        {
            return  Json(context.Cars.ToList());
        }

        public IActionResult CarsList(string search = "", string company = "(all)")
        {
            var selectListItems = new List<string> { "(all)" };
            selectListItems.AddRange(context.Cars.Select(x => x.Title).Distinct());

            var cars = company == "(all)" ? 
                context.Cars.ToList() : 
                context.Cars.Where(x => x.Title.ToLower() == company.ToLower()).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                cars = cars.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(new CarListViewModel
            {
                Cars = cars,
                Companies = new SelectList(selectListItems)
            });
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (order.Name == "111")
            {
                ModelState.AddModelError("Name", "Error!");
            }
            

            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }
      
    }
}
