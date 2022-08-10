using System;
using SystemRules;
using SystemRules.Refactor;
using SystemRules.RuleEngine.Conditions;
using SystemRules.RulesEngine;

namespace RulesPattern.StoreExample.Rules
{
    public class NewCustomerRule : BaseRule<Customer>
    {
        public override void Initialize(Customer obj)
        {
            Conditions.Add(new ConditionExtension(CustomerExtensions.IsExisting(obj)));
        }

        public override Customer Apply(Customer obj)
        {
            obj.Discount += 0.15m;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}