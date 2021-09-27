using System;
using System.Threading.Tasks;
using User.Application.Entities;

namespace User.Application.Repositories
{
    public interface IUserRepository
    {
        Task Create(CantorUser command);
        Task<CantorUser> GetByLogin(string login);
    }
}