using Model.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IUserService
    {
        public Task<User?> GetAsync(string correlationId, Expression<Func<User, bool>> expression,
            CancellationToken cancellationToken);
        public Task<UserDto> CreateUser(string correlationId, UserDto userDto, CancellationToken cancellationToken);
    }
}
