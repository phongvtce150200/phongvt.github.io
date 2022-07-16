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
    public class DeleteModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public DeleteModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.orderDetails.FindAsync(id);

            if (OrderDetails != null)
            {
                _context.orderDetails.Remove(OrderDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
