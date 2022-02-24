using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(a => a.MembershipType);
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }
        public void Remove(int id)
        {
            _context.Customers.Remove(Get(id));
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
