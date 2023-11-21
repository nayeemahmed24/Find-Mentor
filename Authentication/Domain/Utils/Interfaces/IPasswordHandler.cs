using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Interfaces
{
    public interface IPasswordHandler
    {
        public string HashPassword(string password);
        public bool Verify(string password, string userPassword);
    }
}
