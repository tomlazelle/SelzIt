using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Microsoft.AspNetCore.Mvc;
using SelzIt.Models;

namespace SelzIt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new InvoiceModel
            {
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        Quantity = 1,
                        Amount = 10,
                        Discount = 1,
                        Description = "test",
                        TaxPct = .0825m
                    }
                },
                BusinessAddress = new AddressModel
                {
                    Address1 = "123 Main St South",
                    Address2 = "bldg #B",
                    BusinessName = "Abba Zabba",
                    City = "Austin",
                    PostalCode = "78748",
                    State = "TX"
                },
                Date = DateTime.Now,
                Email = "a@b.com",
                Id = DateTime.Now.ToString("yyyMMdd456789789"),
                Phone = "805-555-1234"
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}