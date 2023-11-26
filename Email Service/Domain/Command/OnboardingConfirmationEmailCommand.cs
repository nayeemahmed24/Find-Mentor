using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class OnboardingConfirmationEmailCommand: BaseCommand
    {
        public OnboardingConfirmationEmailCommand(string email, string name)
        {
            this.Email = email;
            this.Name = name;   
        }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
