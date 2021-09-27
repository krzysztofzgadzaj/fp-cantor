using System;

namespace User.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(Guid ownerId);
    }
}