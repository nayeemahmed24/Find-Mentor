using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class BaseCommand
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    }
}
