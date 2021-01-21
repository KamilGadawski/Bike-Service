using BikeService.Data;
using BikeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppDbContext _db;

        public CustomerServices(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                customer.Id = Guid.NewGuid();
                customer.DateTimeAdd = DateTime.Now;
                _db.Customers.Add(customer);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot writing customer to database", ex);
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customer = _db.Customers.OrderByDescending(x => x.DateTimeAdd);
            return customer;
        }

        public Customer GetEditCustomer(Guid id)
        {
            try
            {
                return _db.Customers.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find Customer.", ex);
            }
        }

        public void PostEditCustomer(Customer customer)
        {
            try
            {
                customer.DateTimeAdd = _db.Customers.AsNoTracking().Single(x => x.Id == customer.Id).DateTimeAdd;
                customer.Edit = DateTime.Now;

                _db.Customers.Update(customer);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot update customer.", ex);
            }
        }

        public void RemoveCustomer(Guid id)
        {
            try
            {
                var customer = _db.Customers.Find(id);

                if (customer == null)
                {
                    throw new Exception("Cannot find Customer.");
                }

                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot remove customer from database.", ex);
            }
        }
    }
}
