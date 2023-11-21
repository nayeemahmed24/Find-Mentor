using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Entities;
using Repository;
using Service.Abstraction;
using System.Linq.Expressions;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper) {  
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User?> GetAsync(string correlationId, Expression<Func<User, bool>> expression, CancellationToken cancellationToken)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(expression, cancellationToken);
            return user;
        }

        public async Task<UserDto> CreateUser(string correlationId, UserDto userDto, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<UserDto,User>(userDto);
            var response = await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            UserDto userRes = _mapper.Map<User, UserDto>(response.Entity);
            userRes.Password = null;
            return userRes;
        }
    }
}