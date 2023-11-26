using MediatR;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class AddUniversityCommand: BaseCommand, IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
