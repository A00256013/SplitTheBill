using System;
using System.Collections.Generic;
using Xunit;
using SplitTheBillLibrary;

namespace SplitTheBillTests
{
    public class BillSplitterTests
    {
        // Tests for SplitAmount method
        [Fact]
        public void SplitAmount_ReturnsCorrectValue()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            decimal totalAmount = 100;
            int numberOfPeople = 5;

            // Act
            decimal result = billSplitter.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.Equal(20, result); // Each person should pay $20
        }

        [Fact]
        public void SplitAmount_ReturnsZeroIfNumberOfPeopleIsZero()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            decimal totalAmount = 100;
            int numberOfPeople = 0; // Zero people

            // Act
            decimal result = billSplitter.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.Equal(0, result); // If no people, split amount should be zero
        }

        [Fact]
        public void SplitAmount_ReturnsZeroIfTotalAmountIsZero()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            decimal totalAmount = 0; // Zero total amount
            int numberOfPeople = 5;

            // Act
            decimal result = billSplitter.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.Equal(0, result); // If total amount is zero, split amount should be zero
        }

        // Tests for CalculateTipPerPerson method
        [Fact]
        public void CalculateTipPerPerson_ReturnsCorrectValues()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                { "Person A", 25.00m },
                { "Person B", 30.00m },
                { "Person C", 20.00m }
            };
            float tipPercentage = 15;

            // Act
            Dictionary<string, decimal> tipPerPerson = billSplitter.CalculateTipPerPerson(mealCosts, tipPercentage);

            // Assert
            Assert.Equal(3.75m, tipPerPerson["Person A"]);
            Assert.Equal(4.50m, tipPerPerson["Person B"]);
            Assert.Equal(3.00m, tipPerPerson["Person C"]);
        }

        [Fact]
        public void CalculateTipPerPerson_ReturnsZeroTipIfMealCostsEmpty()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>(); // Empty meal costs
            float tipPercentage = 15;

            // Act
            Dictionary<string, decimal> tipPerPerson = billSplitter.CalculateTipPerPerson(mealCosts, tipPercentage);

            // Assert
            Assert.Empty(tipPerPerson); // If no meal costs provided, tip per person should be empty
        }

        [Fact]
        public void CalculateTipPerPerson_ReturnsZeroTipIfTipPercentageIsZero()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                { "Person A", 25.00m },
                { "Person B", 30.00m },
                { "Person C", 20.00m }
            };
            float tipPercentage = 0; // Zero tip percentage

            // Act
            Dictionary<string, decimal> tipPerPerson = billSplitter.CalculateTipPerPerson(mealCosts, tipPercentage);

            // Assert
            Assert.Equal(0, tipPerPerson["Person A"]); // If tip percentage is zero, tip per person should be zero for all
            Assert.Equal(0, tipPerPerson["Person B"]);
            Assert.Equal(0, tipPerPerson["Person C"]);
        }

        // Tests for CalculateTipPerPerson method with total price
        [Fact]
        public void CalculateTipPerPerson_ReturnsZeroIfNumberOfPatronsIsZero()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            decimal totalPrice = 100;
            int numberOfPatrons = 0; // Zero patrons
            float tipPercentage = 20;

            // Act
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.Equal(0, tipPerPerson); // If no patrons, tip per person should be zero
        }

        [Fact]
        public void CalculateTipPerPerson_ReturnsZeroTipIfTotalPriceIsZero()
        {
            // Arrange
            BillSplitter billSplitter = new BillSplitter();
            decimal totalPrice = 0; // Zero total price
            int numberOfPatrons = 4;
            float tipPercentage = 20;

            // Act
            decimal tipPerPerson = billSplitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.Equal(0, tipPerPerson); // If total price is zero, tip per person should be zero
        }
    }
}
