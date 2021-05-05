using System.Threading.Tasks;
using DesafioMVC.Models;

namespace DesafioMVC.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}