using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Services
{
    public interface IBikeServices
    {
        Task<IEnumerable<Bike>> GetAllBikes();
        Task<List<Customer>> AddBike();
        Task AddBike(Bike bike);
        Task<Bike> EditBike(Guid id);
        Task PostEditBike(Bike bike);
        Task RemoveBike(Guid id);
    }
}
