using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Application.Entities;
using User.Application.Repositories;
using User.Infrastructure.Persistence.Context;

namespace User.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext userContext)
        {
            _context = userContext;
        }
        
        public async Task Create(CantorUser user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<CantorUser> GetByLogin(string login) =>
            await _context.Users
                .FirstOrDefaultAsync(x => x.Login == login);
    }
}