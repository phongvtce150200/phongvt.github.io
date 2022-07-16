using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public CreateModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "ShipAddress");
        ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ProductName");
            return Page();
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.orderDetails.Add(OrderDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
