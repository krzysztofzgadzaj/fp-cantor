using System;
using User.Application.Entities;

namespace User.Application.Dto
{
    public sealed class UserDto
    {
        public Guid Id { get; set; } 
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EmailAddress { get; set; }
        
        public static explicit operator UserDto(CantorUser user) =>
            new UserDto()
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                EmailAddress = user.EmailAddress
            };
    }
}