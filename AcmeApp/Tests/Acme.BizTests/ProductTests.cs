using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;

namespace Acme.BizTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void SayHelloTest()
        {
            var currentProduct = new Product()
            {
                Id = 1,
                Name = "Saw",
                Description = "15-inch steel blade hand saw",
            };
            currentProduct.Vendor.CompanyName = "ABC Corp";

            var expected = "Hello Saw (1): 15-inch steel blade hand saw\n" +
                "Available on ";
            var actual = currentProduct.SayHello();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SayHelloParameterizedConstructorTest()
        {
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw\n" +
                "Available on ";
            var actual = currentProduct.SayHello();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductIsNull()
        {
            Product currentProduct = null;

            var actual = currentProduct?.Vendor?.CompanyName;

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void ConvertMetersToInches()
        {
            var expected = 78.74;

            var actual = 2 * Product.InchesPerMeter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPriceTest()
        {
            var currentProduct = new Product();
            var expected = 0.96m;
            var actual = currentProduct.MinimumPrice;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductNameFormat()
        {
            var currentProduct = new Product();
            currentProduct.Name = "  Steel Hammer   ";
            var expected = "Steel Hammer";

            var actual = currentProduct.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductNameTooShort()
        {
            var currentProduct = new Product();
            currentProduct.Name = "Aw";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            var actual = currentProduct.Name;
            var actualMessage = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNameTooLong()
        {
            var currentProduct = new Product();
            currentProduct.Name = "Steel Bladed Hand Saw";

            string expected = null;
            string expectedMessage = "Product Name cannon be more than 20 characters";

            var actual = currentProduct.Name;
            var actualMessage = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNameCorrect()
        {
            var currentProduct = new Product();
            currentProduct.Name = "Saw";

            string expected = "Saw";
            string expectedMessage = null;

            var actual = currentProduct.Name;
            var actualMessage = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void CategoryDefaultValue()
        {
            var currentProduct = new Product();

            var expected = "Tools";

            var actual = currentProduct.Category;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CategoryNewValue()
        {
            var currentProduct = new Product();

            currentProduct.Category = "Garden";

            var expected = "Garden";

            var actual = currentProduct.Category;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SequenceDefaultValue()
        {
            var currentProduct = new Product();

            var expected = 1;

            var actual = currentProduct.SequenceNumber;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SequenceNewValue()
        {
            var currentProduct = new Product();

            currentProduct.SequenceNumber = 5;

            var expected = 5;

            var actual = currentProduct.SequenceNumber;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ProductCodeDefaultValue()
        {
            var currentProduct = new Product();

            var expected = "Tools-1";

            var actual = currentProduct.ProductCode;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSuggestedPriceTest()
        {
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            var expected = 55m;

            var actual = currentProduct.CalculateSuggestPrice(10m);

            Assert.AreEqual(expected, actual);
        }
    }
}
