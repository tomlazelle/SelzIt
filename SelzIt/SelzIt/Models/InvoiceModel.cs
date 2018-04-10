using System;
using System.Collections.Generic;
using System.Linq;

namespace SelzIt.Models
{
    public class InvoiceModel
    {
        public AddressModel BusinessAddress { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Subtotal()
        {
            return Items.Sum(x => x.Subtotal).ToString("C");
        }
        public string Discount()
        {
            return Items.Sum(x => x.Discount).ToString("C");
        }

        public string Total()
        {
            return Items.Sum(x => x.Total).ToString("C");
        }
        public string Tax()
        {
            return Items.Sum(x => x.TaxAmount).ToString("C");
        }

    }

    public class InvoiceItem
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPct { get; set; }
        public decimal Subtotal => (Amount - Discount) * Quantity;
        public decimal TaxAmount => TaxPct >= 0.00m ? Subtotal * TaxPct : 0;
        public decimal Total => Subtotal + TaxAmount;
    }
    public class AddressModel
    {
        public string BusinessName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}