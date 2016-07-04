using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in invertory
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
        }
        public Product(int productId, string productName, string productDescription) : this()
        {
            Id = productId;
            Name = productName;
            Description = productDescription;
        }

        private string _productName;
        private string _description;
        private int _productId;
        private Vendor _vendor;

        public int Id
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Name
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public Vendor Vendor
        {
            get
            {
                if (_vendor == null)
                {
                    _vendor = new Vendor();
                }
                return _vendor;
            }
            set { _vendor = value; }
        }

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.Name, "sales@abc.com");

            var result = LoggingService.LogAction("saying hello");

            return $"Hello {Name} ({Id}): {Description}";
        }
    }
}
