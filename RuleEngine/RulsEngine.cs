using SystemRules.RulesEngine.Interfaces;

namespace SystemRules.RulesEngine
{
    public static class RulesEngine
    {
        public static T ApplyRule<T>(this T obj, IRule<T> rule) where T : class
        {
            rule.ClearConditions();
            rule.Initialize(obj);
            if (rule.IsValid())
            {
                rule.Apply(obj);
            }
            else
            {
                rule.OnRuleViolated(obj);
            }
            return obj;
        }
    }
}