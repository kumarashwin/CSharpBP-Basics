using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true,
                "Order from Acme Inc.\n" +
                "Product: Tools-1\n" +
                "Quantity: 12\n" +
                "Instructions: Standard delivery");

            var actual = vendor.PlaceOrder(product, 12);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderThreeParamsTest()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true,
                "Order from Acme Inc.\n" +
                "Product: Tools-1\n" +
                "Quantity: 12\n" +
                "Deliver By: 2017-10-25\n" +
                "Instructions: Standard delivery");

            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2017,10,25,0,0,0, new TimeSpan(-7,0,0)));

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderNullProductException()
        {
            var vendor = new Vendor();

            var actual = vendor.PlaceOrder(null, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrderOutOfRangeQuantityException()
        {
            var vendor = new Vendor();

            var actual = vendor.PlaceOrder(new Product(1, "Saw", ""), 0);
        }

        [TestMethod]
        public void PlaceOrderTestWithAddress()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test With Address");

            var actual = vendor.PlaceOrder(product, 12,
                                           Vendor.IncludeAddress.Yes,
                                           Vendor.SendCopy.No);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void PlaceOrderNoDeliveryDate()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true,
                "Order from Acme Inc.\n" +
                "Product: Tools-1\n" +
                "Quantity: 12\n" +
                "Instructions: Deliver to Suite 42");

            var actual = vendor.PlaceOrder(product, 12, instructions: "Deliver to Suite 42");

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var vendor = new Vendor() {
                VendorId = 1,
                CompanyName = "ABC Corp"};
            var expected = "Vendor: ABC Corp";

            var actual = vendor.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}