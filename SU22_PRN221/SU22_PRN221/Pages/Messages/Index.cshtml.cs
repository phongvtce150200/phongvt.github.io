using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SU22_PRN221.Database;
using SU22_PRN221.Hubs;
using SU22_PRN221.Models;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Messages
{
    public class IndexModel : PageModel
    {

        IHubContext<ChatHub> _chatHubContext;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyf;

        public IndexModel(IHubContext<ChatHub> chatHubContext, ApplicationDbContext context, UserManager<User> userManager,INotyfService notyfService)
        {
            _chatHubContext = chatHubContext;
            _context = context;
            _userManager = userManager;
            _notyf = notyfService;
        }

        public List<ChatMessage> chatMessages { get; set; } = new List<ChatMessage>();

        public IActionResult OnGet()
        {
            string getUsName = User.Identity.Name;
            if (getUsName != null)
            { 
                var getUser = _context.Users.FirstOrDefault(x => x.UserName == getUsName);
                User user = getUser;
                chatMessages = _context.chatMessages.Include(cm => cm.User).Where(cm => cm.UserId == user.Id)
                    .OrderByDescending(cm => cm.Created)
                    .Take(20).OrderBy(cm => cm.Created).ToList();
                return Page();
            }
            _notyf.Warning("Must be Loggin to chat with Admin");
            return Redirect("/identity/account/login"); ;
        }

        public IActionResult OnPost([FromBody] string content) 
        {
            string getUsName = User.Identity.Name;
            var getUser = _context.Users.FirstOrDefault(x => x.UserName == getUsName);
            User user = getUser;

            ChatMessage chatMessage = new ChatMessage()
            {
                Type = ChatMessage.Types.Sender,
                UserId = user.Id,
                Content = content,
            };

            _context.chatMessages.Add(chatMessage);
            _context.SaveChanges();

            _chatHubContext.Clients.All.SendAsync($"administratorListenMessages-{user.Id}", new
            {
                content=chatMessage.Content,
                time=chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });
            _chatHubContext.Clients.User(user.Id).SendAsync("receiveMessage", new
            {
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });

            _chatHubContext.Clients.All.SendAsync("newUserComming", new { userId=user.Id,  username=user.UserName });

            return new OkResult();
        }
    }
}
