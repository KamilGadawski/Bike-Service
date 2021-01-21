﻿using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Services
{
    public interface ICustomerServices
    {
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        Customer GetEditCustomer(Guid id);
        void PostEditCustomer(Customer customer);
        void RemoveCustomer(Guid id);
    }
}