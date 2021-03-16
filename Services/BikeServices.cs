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

        public async Task<Bike> EditBike(Guid id)
        {
            try
            {
                using (_db)
                {
                    return await _db.Bikes.FindAsync(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find Bike.", ex);
            }
        }

        public async Task PostEditBike(Bike bike)
        {
            try
            {
                using (_db)
                {
                    DateTime addedTime = _db.Bikes.AsNoTracking().Where(x => x.Id == bike.Id).First().AddedBike;
                    bike.AddedBike = addedTime;

                    _db.Bikes.Update(bike);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot update customer.", ex);
            }
        }

        public async Task RemoveBike(Guid id)
        {
            try
            {
                using (_db)
                {
                    var bike = await _db.Bikes.FindAsync(id);

                    if (bike is null)
                    {
                        throw new Exception("Cannot find Bike.");
                    }

                    _db.Bikes.Remove(bike);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Cannot remove bike from database.", ex);
            }
        }

    }
}