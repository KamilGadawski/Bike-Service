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
            _bikeServices= bikeServices;
        }

        public async Task<IActionResult> Index()
        {
            var bikes = await _bikeServices.GetAllBikes();
            return View(bikes.OrderByDescending(x => x.AddedBike));
        }
    }
}
