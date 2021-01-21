﻿using BikeService.Data;
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
        //private readonly AppDbContext _db;

        //public CustomerController(AppDbContext db)
        //{
        //    _db = db;
        //}

        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public IActionResult Index()
        {
            var customers = _customerServices.GetAllCustomers();
            return View(customers);
        }

        // GET - CREATE CUSTOMER
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE CUSTOMER
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerServices.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET - EDIT CUSTOMER
        public IActionResult Edit(Guid Id)
        {
            var customer = _customerServices.GetEditCustomer(Id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST - UPDATE CUSTOMER
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerServices.PostEditCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Delete(Guid Id)
        {
            _customerServices.RemoveCustomer(Id);

            return RedirectToAction("Index");
        }
    }
}