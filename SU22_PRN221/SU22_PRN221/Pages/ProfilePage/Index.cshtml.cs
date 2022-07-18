using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SU22_PRN221.Pages.ProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<User> userManager)
        { 
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public new User User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [Phone]
        public string PhoneNumber { get; set; }


        public void OnGet()
        {
            GetAccount();
        }

        public async Task<IActionResult> OnPostAsync(string Address,string PhoneNumber)
        {
            var getuser = _userManager.GetUserAsync(HttpContext.User);
            User usr = await getuser;
            User.FirstName = GetAccount().FirstName;
            User.LastName = GetAccount().LastName;

            usr.Address = Address;
            usr.PhoneNumber = PhoneNumber;

            
            try
            {
                await _userManager.UpdateAsync(usr);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Home/Index");
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        public User GetAccount()
        {
            var usn = HttpContext.Session.GetString("username");
            User = _context.Users.SingleOrDefault(a => a.UserName.Equals(usn));
            return User;
        }
    }
}
