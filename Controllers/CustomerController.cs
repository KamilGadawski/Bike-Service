using BikeService.Data;
using BikeService.Models;
using BikeService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerServices.GetAllCustomers();
            return View(customers.OrderByDescending(x => x.DateTimeAdd));
        }

        // GET - CREATE CUSTOMER
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE CUSTOMER
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerServices.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET - EDIT CUSTOMER
        public async Task<IActionResult> Edit(Guid Id)
        {
            var customer = await _customerServices.GetEditCustomer(Id);

            if (customer is null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST - UPDATE CUSTOMER
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerServices.PostEditCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            await _customerServices.RemoveCustomer(Id);

            return RedirectToAction("Index");
        }
    }
}
