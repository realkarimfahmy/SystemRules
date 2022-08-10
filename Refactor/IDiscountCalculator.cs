namespace SystemRules.Refactor
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscountPercentage(Customer customer);
    }
}