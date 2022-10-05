using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.API.Contract.Request;
using UserManager.Domain;

namespace UserManager.Teste.Factory
{
    public class UserFactory
    {
        public static User GetUser() =>
            new User
            {
                Id = new Guid(),
                Name = "User Test1",
                Email = "teste@teste.com"
            };


        public static UserContractRequest GetContractRequest() =>
            new UserContractRequest
            {
                Id = new Guid(),
                Name = "Contract Request",
                Email = "contract@contract.cm"
            };

        public static UserContractRequest GetContractBadRequest() =>
            new UserContractRequest
            {
                Id = new Guid(),
                Name = "",
                Email = ""
            };

        public static Guid GetNewGuid() =>
            new Guid();
    }
}
