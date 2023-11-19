using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class BaseCommand
    {
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    }
}
