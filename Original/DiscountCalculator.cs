using System;
using SystemRules.Refactor;

namespace SystemRules.Original
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                // retired discount 5%
                discount = .05m;
            }

            if (customer.DateOfBirth.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Month == DateTime.Today.Month)
            {
                // birthday 10%
                discount = Math.Max(discount, .10m);
            }

            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    // after 1 year, loyal customers get 10%
                    discount = Math.Max(discount, .10m);
                    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                    {
                        // after 5 years, 12%
                        discount = Math.Max(discount, .12m);
                        if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                        {
                            // after 10 years, 20%
                            discount = Math.Max(discount, .2m);
                        }
                    }

                    if (customer.DateOfBirth.Day == DateTime.Today.Day &&
                        customer.DateOfBirth.Month == DateTime.Today.Month)
                    {
                        // birthday additional 10%
                        discount += .10m;
                    }
                }
            }
            else
            {
                // first time purchase discount of 15%
                discount = Math.Max(discount, .15m);
            }

            return discount;
        }
    }
}