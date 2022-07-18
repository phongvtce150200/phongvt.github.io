using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Payment
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public List<CartDetails> cart;

        [BindProperty]
        public Order Order { get; set; }



        public IActionResult OnGetPayment()
        {
            string AccName = HttpContext.Session.GetString("username");
            ViewData["usn"] = AccName;
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            if (cart.Count == 0)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                var getUser = _context.Users.FirstOrDefault(x => x.UserName == AccName);
                List<CartDetails> cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
                DateTime datetime = DateTime.Now;
                TimeSpan duration = new(7, 0, 0, 0);
                Order = new Order { Id = getUser.Id, CreatedDate = datetime, ShippedDate = datetime.Add(duration), ShipAddress = getUser.Address, Freight = 20000, OrderStatus = true };

                Order.OrderDetails = new List<OrderDetails>();
                foreach (var item in cart)
                {
                    OrderDetails details = new OrderDetails()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Total = (item.Quantity * item.Product.Price) + 20000
                    };
                    Order.OrderDetails.Add(details);
                }
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _context.orders.Add(Order);
                _context.SaveChanges();

                return Redirect("/Payment/Index");
            }
        }
    }
}

