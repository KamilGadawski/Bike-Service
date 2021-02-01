using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task AddCustomer(Customer customer);
        Task<Customer> GetEditCustomer(Guid id);
        Task PostEditCustomer(Customer customer);
        Task RemoveCustomer(Guid id);
    }
}
