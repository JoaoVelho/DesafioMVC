using System;
using System.Threading.Tasks;
using DesafioMVC.Models;
using DesafioMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly UserManager<IdentityUser> _userManager;
        
        public MailController(IMailService mailService, UserManager<IdentityUser> userManager) {
            _mailService = mailService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string subject, string body) {
            try
            {
                IdentityUser user = await _userManager.GetUserAsync(User);
                MailRequest request = new MailRequest();
                request.ToEmail = user.Email;
                request.Subject = subject;
                request.Body = body; 

                await _mailService.SendEmailAsync(request);
                return Redirect(Request.Headers["referer"]);
            }
            catch (Exception)
            {
                return Redirect(Request.Headers["referer"]);
            }
        }
    }
}