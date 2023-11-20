using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Interfaces
{
    public interface ITokenHandler
    {
        public string GenerateAccessToken(User user);
    }
}
