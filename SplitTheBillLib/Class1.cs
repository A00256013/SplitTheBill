using System;
using System.Collections.Generic;

namespace SplitTheBillLibrary
{
    public class BillSplitter
    {
        // Method to split the total amount evenly among a specified number of people
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
                throw new ArgumentException("Number of people must be greater than zero.");

            return totalAmount / numberOfPeople;
        }

        // Method to calculate the tip amount for each person based on individual meal costs and tip percentage
        public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
                throw new ArgumentException("Meal costs dictionary cannot be null or empty.");

            Dictionary<string, decimal> tipPerPerson = new Dictionary<string, decimal>();

            foreach (var entry in mealCosts)
            {
                decimal tipAmount = entry.Value * (decimal)(tipPercentage / 100);
                tipPerPerson.Add(entry.Key, tipAmount);
            }

            return tipPerPerson;
        }

        // Method to calculate the tip amount per person based on total price, number of patrons, and tip percentage
        public decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0)
                throw new ArgumentException("Number of patrons must be greater than zero.");

            decimal tipAmount = totalPrice * (decimal)(tipPercentage / 100);
            return tipAmount / numberOfPatrons;
        }
    }
}
