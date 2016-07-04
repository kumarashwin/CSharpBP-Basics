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
            var currentProduct = new Product(){
                Id = 1,
                Name = "Saw",
                Description = "15-inch steel blade hand saw",
            };
            currentProduct.Vendor.CompanyName = "ABC Corp";

            var expected = "Hello Saw (1): 15-inch steel blade hand saw";
            var actual = currentProduct.SayHello();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SayHelloParameterizedConstructorTest()
        {
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";
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
    }
}
