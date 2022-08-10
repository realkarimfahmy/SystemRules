using System;
using SystemRules;
using SystemRules.Refactor;
using SystemRules.RuleEngine.Conditions;
using SystemRules.RulesEngine;

namespace RulesPattern.StoreExample.Rules
{
    public class LoyalCustomerRule : BaseRule<Customer>
    {
        private readonly int _yearsAsCustomer;
        private readonly decimal _discount;
        private readonly DateTime _date;

        public LoyalCustomerRule(int yearsAsCustomer, decimal discount, DateTime? date = null)
        {
            _yearsAsCustomer = yearsAsCustomer;
            _discount = discount;
            _date = date.ToValueOrDefault();
        }

        public override void Initialize(Customer obj)
        {
            Conditions.Add(new ConditionExtension(CustomerExtensions.HasBeenLoyalForYears(obj, _yearsAsCustomer, _date)));
            Conditions.Add(new ConditionExtension(CustomerExtensions.IsBirthday(obj)));
        }

        public override Customer Apply(Customer obj)
        {
            obj.Discount += _discount;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}