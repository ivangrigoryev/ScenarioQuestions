using ScenarioQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioQuestions.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? GetById(int id);

        void Save(Customer customer);
        Customer? Create(Customer customer);
    }
}
