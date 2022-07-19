using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SU22_PRN221.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;

namespace SU22_PRN221.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly INotyfService _notyf;

        public LoginModel(SignInManager<User> signInManager,
            ILogger<LoginModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            INotyfService notyf)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _notyf = notyf;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var us = await _userManager.FindByNameAsync(Input.UserName);
                    var userInRole = await _userManager.IsInRoleAsync(us, "Admin");
                    HttpContext.Session.SetString("username", Input.UserName);
                    if (userInRole == true)
                    {
                        return RedirectToPage("/Categories/Index");
                    }
                    else
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    _notyf.Warning("Wrong Username Or Password!");
                    return Page();
                }
            }
            _notyf.Warning("Required Field Cant Be Null");
            // If we got this far, something failed, redisplay form
            return Page();
        }
        public IActionResult OnGetLogout()
        {

            /* cart = SessionHelper.GetObjectFromJson<List<CartDetails>>(HttpContext.Session, "cart");
             foreach (var item in cart)
             {
                 CartDetails cartDetails = new CartDetails()
                 {
                     Cart = _context.carts.FirstOrDefault(c => c.CartId == item.CartId),
                     CartId = item.CartId,
                     ProductId = item.ProductId,
                     Quantity = item.Quantity,
                     Product = item.Product
                 };
                 Cart.CartDetails.Add(cartDetails);
             }
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             _context.SaveChanges();*/
            _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Home/Index");

        }
    }
}
