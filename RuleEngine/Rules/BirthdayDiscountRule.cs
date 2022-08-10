using System;
using SystemRules;
using SystemRules.Refactor;
using SystemRules.RuleEngine.Conditions;
using SystemRules.RulesEngine;

namespace RulesPattern.StoreExample.Rules
{
    public class BirthdayDiscountRule : BaseRule<Customer>
    {
        public override void Initialize(Customer obj)
        {
            Conditions.Add(new ConditionExtension(CustomerExtensions.IsBirthday(obj)));
        }

        public override Customer Apply(Customer obj)
        {
            obj.Discount += .10m;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}