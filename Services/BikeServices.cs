using BikeService.Data;
using BikeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Services
{
    public class BikeServices : IBikeServices
    {
        private readonly AppDbContext _db;

        public BikeServices(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Bike>> GetAllBikes()
        {
            try
            {
                using (_db)
                {
                    return await _db.Bikes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get all bikes from database", ex);
            }
        }

        public async Task<List<Customer>> AddBike()
        {
            List<Customer> customerList = new List<Customer>();

            customerList = await ( from customer in _db.Customers
                            select customer).ToListAsync();

            return customerList;
        }

        public async Task AddBike(Bike bike)
        {
            try
            {
                using (_db)
                {
                    bike.Id = Guid.NewGuid();
                    bike.AddedBike = DateTime.Now;
                    await _db.Bikes.AddAsync(bike);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot writing bike to database", ex);
            }
        }

        public Task<Bike> EditBike(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task PostEditBike(Bike bike)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBike(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}