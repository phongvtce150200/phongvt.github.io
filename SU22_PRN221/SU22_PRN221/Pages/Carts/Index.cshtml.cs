using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public IndexModel(ApplicationDbContext context ,INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }


        public List<CartDetails> cart;
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Cart carts { get; set; }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            string AccName = HttpContext.Session.GetString("username");
            string AccID = HttpContext.Session.GetString("accID");
            string userid = HttpContext.Session.GetString("userid");
            ViewData["uid"] = userid;
            ViewData["aID"] = AccID;
            ViewData["usn"] = AccName;
        }

        public IActionResult OnGetAddToCart(int id)
        {
            string AccName = HttpContext.Session.GetString("username");
            string AccID = HttpContext.Session.GetString("accID");
            string userid = HttpContext.Session.GetString("userid");
            ViewData["uid"] = userid;
            ViewData["aID"] = AccID;
            ViewData["usn"] = AccName;

            if (!string.IsNullOrEmpty(AccName))
            {
                var getUser = _context.Users.FirstOrDefault(x => x.UserName == AccName);
                var getCart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);
                if (getCart == null)
                {
                    carts = new Cart { Id = getUser.Id, CartStatus = true };
                    _context.carts.Add(carts);
                    _context.SaveChanges();
                }
                var pod = new Product();
                cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
                if (String.IsNullOrEmpty(getUser.Address) || String.IsNullOrEmpty(getUser.PhoneNumber))
                    return RedirectToPage("/ProfilePage/Index");
                if (cart == null)
                {
                    var Product = _context.products.FirstOrDefault(x => x.ProductId == id);
                    var GetCart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);
                    cart = new List<CartDetails>();
                    cart.Add(new CartDetails
                    {
                        CartId = getCart.CartId,
                        ProductId = Product.ProductId,
                        Product = _context.products.FirstOrDefault(x => x.ProductId == id),
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    string cartObj = JsonConvert.SerializeObject(cart);
                    HttpContext.Session.SetString("CartObj", cartObj);
                }
                else
                {
                    int index = Exists(cart, id);
                    if (index == -1)
                    {
                        cart.Add(new CartDetails
                        {
                            Product = _context.products.FirstOrDefault(x => x.ProductId == id),
                            Quantity = 1
                        });
                    }
                    else
                        cart[index].Quantity++;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    string cartObj = JsonConvert.SerializeObject(cart);
                    HttpContext.Session.SetString("cartObj", cartObj);
                }
                _notyf.Success("Add Product To Cart Successfully");
                return Page();
            }
            else
            {
                ViewData["MustLogin"] = "You have to login to buy this CartDetails(s)!";
                _notyf.Warning("You have to login to buy this CartDetails(s)!");
                return Redirect("/identity/account/login");
            }
        }

        public void OnGetInCrease(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            if (index == -1)
            {
                cart.Add(new CartDetails
                {
                    Product = _context.products.FirstOrDefault(x => x.ProductId == id),
                    Quantity = 1
                });
            }
            else
                cart[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            string cartObj = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cartObj", cartObj);
        }

        public void OnGetDecrease(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            if (index == -1)
            {
                try
                {
                    cart.RemoveAt(index);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                catch
                {
                    cart = new List<CartDetails>();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }

            else
                if (cart[index].Quantity > 1)
                cart[index].Quantity--;
            else
                cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            string cartObj = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cartObj", cartObj);
        }

        public void OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }

        public IActionResult OnGetCheckOut()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/CheckOut/Index");
            }
        }

        public IActionResult OnPostCheckOut()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                string AccName = HttpContext.Session.GetString("username");
                var getUser = _context.Users.FirstOrDefault(x => x.UserName == AccName);
                List<CartDetails> cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
                DateTime datetime = DateTime.Now;
                TimeSpan duration = new(7, 0, 0, 0);
                Order.Id = getUser.Id;
                Order.CreatedDate = datetime;
                Order.ShippedDate = datetime.Add(duration);
                Order.ShipAddress = getUser.Address;
                Order.Freight = 20000;
                Order.OrderStatus = true;

                Order.OrderDetails = new List<OrderDetails>();
                foreach (var item in cart)
                {
                    var pro = _context.products.FirstOrDefault(x => x.ProductId == item.ProductId);
                    OrderDetails details = new OrderDetails()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Total = (pro.Price * item.Quantity) + 20000
                    };
                    Order.OrderDetails.Add(details);
                }
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _context.orders.Add(Order);
                _context.SaveChanges();

                return Redirect("/CheckOut/Index");
            }
        }
        private int Exists(List<CartDetails> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                    return i;
            }
            return -1;
        }
    }
}
