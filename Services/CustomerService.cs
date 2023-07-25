using ScenarioQuestions.Interfaces;
using ScenarioQuestions.Models;

namespace ScenarioQuestions.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void UpdateCustomerName(int customerId, string newName)
        {
            var customer = _customerRepository.GetById(customerId);
            if (customer != null)
            {
                customer.Name = newName;
                _customerRepository.Save(customer);
            }
        }

        public Customer CreateCustomer(int customerId, string newName)
        {
            var customer = new Customer { Id = customerId, Name = newName, RegistrationDate = DateTime.Now };
            _customerRepository.Create(customer);
            return customer;
        }

        public Customer? FindCustomer(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }
    }
}