namespace SystemRules.RulesEngine.Interfaces
{
    public interface IRule<T>
    {
        void ClearConditions();
        void Initialize(T obj);
        bool IsValid();
        T Apply(T obj);
        void OnRuleViolated(T obj);
    }
}