using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer Get(int id);
        void Add(Customer customer);
        void Remove(int id);
        void Update(Customer customer);
        void Save();
    }
}
