using Microsoft.EntityFrameworkCore;
using ScenarioQuestions.Data;
using ScenarioQuestions.Interfaces;
using ScenarioQuestions.Models;

namespace ScenarioQuestions.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _dbContext;

        public CustomerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer? GetById(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public void Save(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }

        public Customer? Create(Customer customer)
        {
            if (GetById(customer.Id) == null)
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }
            
            return GetById(customer.Id);
        }
    }
}
