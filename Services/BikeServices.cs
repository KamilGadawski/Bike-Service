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

        public Task AddBike()
        {
            throw new NotImplementedException();
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