using MediatR;
using Model.Response;

namespace Domain.Command
{
    public class RegisterCommand: BaseCommand, IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
