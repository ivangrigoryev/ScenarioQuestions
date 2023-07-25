using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScenarioQuestions.Data;
using ScenarioQuestions.Interfaces;
using ScenarioQuestions.Repository;
using ScenarioQuestions.Services;

namespace ScenarioQuestions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Customers") ?? @"Data Source=..\..\..\Customers.db";
            builder.Services.AddSqlite<DatabaseContext>(connectionString);
            builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
            builder.Services.AddScoped<CustomerService>();

            var app = builder.Build();
            Run(app.Services);
        }

        public static void Run(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();

            IServiceProvider provider = serviceScope.ServiceProvider;
            var customerService = provider.GetRequiredService<CustomerService>();

            int customerId = 12342;
            string name = "Simon Wordsworth";
            var customer = customerService.CreateCustomer(customerId, name);
            Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name}");

            string newName = "Sreeni Gotla";
            customerService.UpdateCustomerName(customerId, newName);

            var updatedCustomer = customerService.FindCustomer(customerId);
            Console.WriteLine($"Customer ID: {updatedCustomer?.Id}, Name: {updatedCustomer?.Name}");
        }
    }
}
