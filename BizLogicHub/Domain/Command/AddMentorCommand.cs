using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model.Response;

namespace Domain.Command
{
    public class AddMentorCommand: BaseCommand,IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string ProfileDescription { get; set; }
        public string UniversityId { get; set; }
    }
}
