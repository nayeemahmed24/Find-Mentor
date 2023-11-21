using MediatR;
using Model.Response;
namespace Domain.Command
{
    public class LoginCommand: BaseCommand, IRequest<CommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
