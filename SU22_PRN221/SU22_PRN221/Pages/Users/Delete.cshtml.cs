using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Users

{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public DeleteModel(SU22_PRN221.Database.ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        [BindProperty]
        public User User2 { get; set; }

        public async Task<IActionResult> OnGetAsync(String Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            User2 = await _context.Users.FirstOrDefaultAsync(m => m.Id.Equals(Id));

            if (User2 == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(String Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            User2 = await _context.Users.FindAsync(Id);

            if (User2 != null)
            {
                _context.Users.Remove(User2);
                await _context.SaveChangesAsync();
            }
            _notyf.Success("Delete User Successfully");
            return RedirectToPage("./Index");
        }
    }
}
