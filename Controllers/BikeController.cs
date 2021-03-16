using BikeService.Models;
using BikeService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class BikeController : Controller
    {
        private readonly IBikeServices _bikeServices;
        public BikeController(IBikeServices bikeServices)
        {
            _bikeServices = bikeServices;
        }

        public async Task<IActionResult> Index()
        {
            var bikes = await _bikeServices.GetAllBikes();
            return View(bikes.OrderByDescending(x => x.AddedBike));
        }

        public async Task<IActionResult> Create()
        {
            var customers = await _bikeServices.AddBike();
            ViewBag.ListOfCustomers = customers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                await _bikeServices.AddBike(bike);
                return Redirect("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var bike = await _bikeServices.EditBike(Id);

            if (bike is null)
            {
                return NotFound();
            }

            return View(bike);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                await _bikeServices.PostEditBike(bike);
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            await _bikeServices.RemoveBike(Id);

            return RedirectToAction("Index");
        }
    }
}
