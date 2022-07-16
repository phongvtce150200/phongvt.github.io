using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public EditModel(SU22_PRN221.Database.ApplicationDbContext context)
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
           ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "ShipAddress");
           ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ProductName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(OrderDetails.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.orderDetails.Any(e => e.OrderId == id);
        }
    }
}
