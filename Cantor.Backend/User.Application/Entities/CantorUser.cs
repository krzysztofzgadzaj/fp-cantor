using System;

namespace User.Application.Entities
{
    public sealed class CantorUser
    {
        public CantorUser(
            Guid id,
            string login, 
            string firstName, 
            string secondName, 
            string emailAddress, 
            byte[] password)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            SecondName = secondName;
            EmailAddress = emailAddress;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }
    }
}