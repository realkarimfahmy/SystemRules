using System;
using System.Linq;
using SystemRules.RulesEngine.Conditions;
namespace SystemRules.RulesEngine
{
    public class BuyThreeGetThirdFree : BaseRule<Customer>
    {
        private readonly string _productName;

        public BuyThreeGetThirdFree(string productName)
        {
            _productName = productName;
        }

        public override void Initialize(Customer obj)
        {
            Conditions.Add(new Equals(3, obj.Products.Count(p => p.Name == _productName)));
        }

        public override Customer Apply(Customer obj)
        {
            obj.TotalValue -= obj.Products.Last(x => x.Name == _productName).Price;
            return obj;
        }
        public override void OnRuleViolated(Customer obj)
        {
            Console.WriteLine($"{this.GetType().Name}  Violated");
        }
    }
}