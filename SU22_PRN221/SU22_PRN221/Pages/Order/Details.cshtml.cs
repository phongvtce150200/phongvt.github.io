using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public DetailsModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.orderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).FirstOrDefaultAsync(m => m.OrderId == id);

            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
