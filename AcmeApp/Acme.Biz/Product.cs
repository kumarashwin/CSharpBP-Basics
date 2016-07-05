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
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;

        public Product()
        {
            Console.WriteLine("Product instance created");
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string productDescription) : this()
        {
            Id = productId;
            Name = productName;
            Description = productDescription;
        }

        private string _productName;
        private Vendor _vendor;
        private DateTime? _availability;
        
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name
        {
            get
            {
                var formattedValue = _productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannon be more than 20 characters";
                }
                else
                {
                    _productName = value;
                }
            }
        }
        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => $"{Category}-{SequenceNumber}";
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
        public DateTime? Availability { get; set; }
        public string ValidationMessage { get; set; }
        public decimal Cost { get; set; }
        public decimal CalculateSuggestPrice(decimal markupPercernt) =>
            this.Cost + (this.Cost * markupPercernt / 100);

        public string SayHello()
        {

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.Name, "sales@abc.com");

            var result = LoggingService.LogAction("saying hello");

            return $"Hello {Name} ({Id}): {Description}\n" +
                $"Available on {Availability?.ToShortDateString()}";
        }
        public override string ToString() => $"{this.Name} ({Id})";

    }
}
