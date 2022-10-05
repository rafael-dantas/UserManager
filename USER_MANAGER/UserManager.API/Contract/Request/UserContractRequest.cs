using System;
using UserManager.Domain;

namespace UserManager.API.Contract.Request
{
    public class UserContractRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static implicit operator User(UserContractRequest contract) =>
            new User
            {
                Id = contract.Id,
                Name = contract.Name,
                Email = contract.Email
            };
    }
}
