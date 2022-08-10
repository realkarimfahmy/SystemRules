using RulesPattern.StoreExample.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemRules.RulesEngine;

namespace SystemRules
{
    class Program
    {
        static void Main(string[] args)
        {
            var productA = new Product { Price = 100, Name = "Apple Watch" };
            var productB = new Product { Price = 50, Name = "Samsung Watch" };

            var customer = new Customer
            {
                Products = new List<Product> { productA, productB, productA, productA },
                DateOfFirstPurchase = DateTime.Now.AddYears(-2),
                DateOfBirth = DateTime.Now.AddYears(-5),
            };
            customer.TotalValue = customer.Products.Sum(p => p.Price);

            var ruleManager = new CustomerRuleManager(customer);
            var result = ruleManager.Run();
        }
    }
    public class CustomerRuleManager
    {
        private readonly Customer _customer;

        public CustomerRuleManager(Customer customer)
        {
            _customer = customer;
        }

        public Customer Run()
        {
            _customer
                .ApplyRule(new BirthdayDiscountRule())
                .ApplyRule(new BuyThreeGetThirdFree("Apple Watch"))
                .ApplyRule(new FreeShipping())
                .ApplyRule(new LoyalCustomerRule(5, 0.12m))
                .ApplyRule(new NewCustomerRule())
                .ApplyRule(new RetiredDiscountRule());

            return _customer;
        }
    }
}
