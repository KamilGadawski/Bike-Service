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

        public async Task AddCustomer(Customer customer)
        {
            try
            {
                using (_db)
                {
                    customer.Id = Guid.NewGuid();
                    customer.DateTimeAdd = DateTime.Now;
                    await _db.Customers.AddAsync(customer);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot writing customer to database", ex);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                using (_db)
                {
                    return await _db.Customers.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get all customers from database", ex);
            }
        }

        public async Task<Customer> GetEditCustomer(Guid id)
        {
            try
            {
                using (_db)
                {
                    return await _db.Customers.FindAsync(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find Customer.", ex);
            }
        }

        public async Task PostEditCustomer(Customer customer)
        {
            try
            {
                using (_db)
                {
                    var addedTime = _db.Customers.AsNoTracking().Where(x => x.Id == customer.Id).First().DateTimeAdd;
                    customer.DateTimeAdd = addedTime;
                    customer.Edit = DateTime.Now;

                    _db.Customers.Update(customer);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot update customer.", ex);
            }
        }

        public async Task RemoveCustomer(Guid id)
        {
            try
            {
                var customer = await _db.Customers.FindAsync(id);

                if (customer is null)
                {
                    throw new Exception("Cannot find Customer.");
                }

                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot remove customer from database.", ex);
            }
        }
    }
}
