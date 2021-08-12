using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class AdminController : Controller
    {
        CarContext context;
        public AdminController(CarContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Cars.ToList());
        }

        public IActionResult Create(int? id)
        {
            var carToEdit = context.Cars.Find(id);
            return View(carToEdit);
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (car.CarId == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                var carToEdit = context.Cars.FirstOrDefault(x => x.CarId == car.CarId);
                carToEdit.Title = car.Title;
                carToEdit.Model = car.Model;
                carToEdit.Price = car.Price;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int carId)
        {
            context.Cars.Remove(context.Cars.Find(carId));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
