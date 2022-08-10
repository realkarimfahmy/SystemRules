using SystemRules.RulesEngine.Interfaces;

namespace SystemRules.RuleEngine.Conditions
{
    internal class ConditionExtension : ICondition
    {
        private readonly bool _extension;

        public ConditionExtension(bool extension)
        {
            _extension = extension;
        }

        public bool IsSatisfied()
        {
            return _extension;
        }
    }
}
