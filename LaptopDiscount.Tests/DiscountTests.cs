using NUnit.Framework;

namespace LaptopDiscount.Tests
{
    public class EmployeeDiscountTests
    {
        private EmployeeDiscount _employeeDiscount;

        [SetUp]
        public void Setup()
        {
            _employeeDiscount = new EmployeeDiscount();
        }

        [Test]
        public void CalculateDiscountedPrice_PartTimeEmployee_NoDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = 100m;
            var expectedPrice = 100m; // for 0%

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "Part-time employees should not receive a discount.");
        }

        [Test]
        public void CalculateDiscountedPrice_PartialLoadEmployee_5PercentDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartialLoad;
            _employeeDiscount.Price = 100m;
            var expectedPrice = 95m; // for 5%

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "Partial load employees should receive a 5% discount.");
        }

        [Test]
        public void CalculateDiscountedPrice_FullTimeEmployee_10PercentDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.FullTime;
            _employeeDiscount.Price = 100m;
            var expectedPrice = 90m; // for 10%

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "Full-time employees should receive a 10% discount.");
        }

        [Test]
        public void CalculateDiscountedPrice_CompanyPurchasingEmployee_20PercentDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.CompanyPurchasing;
            _employeeDiscount.Price = 100m;
            var expectedPrice = 80m; // for 20%

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "Company purchasing employees should receive a 20% discount.");
        }

        [Test]
        public void CalculateDiscountedPrice_HighPriceFullTimeEmployee_10PercentDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.FullTime;
            _employeeDiscount.Price = 1000m;
            var expectedPrice = 900m; // 10% discount for higher priced items.

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "Full-time employees should receive a 10% discount on higher priced items.");
        }

        [Test]
        public void CalculateDiscountedPrice_ZeroPriceNoDiscount_Ash()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = 0m;
            var expectedPrice = 0m; // 0% discount when price is 0 or less

            // Act
            var actualPrice = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), "There should be no discount on items priced at zero.");
        }
    }
}
