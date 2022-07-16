using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using SU22_PRN221.Service;

namespace SU22_PRN221.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        private readonly IHubContext<SignalrServer> _signalRHub;
        public IndexModel(SU22_PRN221.Database.ApplicationDbContext context, IHubContext<SignalrServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IList<OrderDetails> OrderDetails { get;set; }


        public async Task OnGetAsync()
        {
            OrderDetails = await _context.orderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).ToListAsync();
        }
        public IActionResult OnGetOrder()
        {
            var obj = _context.orders.ToList();
            return StatusCode(200,obj);
        }


    }
}
