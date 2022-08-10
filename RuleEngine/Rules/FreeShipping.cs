using System;
using SystemRules.RulesEngine.Conditions;

namespace SystemRules.RulesEngine
{
    public class FreeShipping : BaseRule<Customer>
    {
        public override void Initialize(Customer obj)
        {
            Conditions.Add(new GreaterThan(10.24m, obj.TotalValue));
        }

        public override Customer Apply(Customer obj)
        {
            obj.FreeShipping = true;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}