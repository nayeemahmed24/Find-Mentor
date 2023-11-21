using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class TokenDto
    {
        public TokenDto() { }
        public TokenDto(string accessToken, int expirationTime)
        {
            this.AccessToken = accessToken;
            this.ExpirationTime = expirationTime;
        }
        public string AccessToken { get; set; }
        public int ExpirationTime { get; set; }
    }
}
