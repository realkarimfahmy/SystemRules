using System;
using SystemRules;
using SystemRules.Refactor;
using SystemRules.RuleEngine.Conditions;
using SystemRules.RulesEngine;

namespace RulesPattern.StoreExample.Rules
{
    public class RetiredDiscountRule : BaseRule<Customer>
    {
        public override void Initialize(Customer obj)
        {
            Conditions.Add(new ConditionExtension(CustomerExtensions.IsRetired(obj)));
        }

        public override Customer Apply(Customer obj)
        {
            obj.Discount += .05m;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}