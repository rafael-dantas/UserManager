using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.API.Controllers;
using UserManager.API.Models;
using UserManager.Data.Interface;
using UserManager.Domain;
using UserManager.Service;
using UserManager.Service.Interface;
using UserManager.Teste.Factory;
using Xunit;

namespace UserManager.Teste.TestService
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact(DisplayName = "Inserir usuario novo")]
        public void InsertUserTrue()
        {
            _userRepositoryMock.Setup(x => x.Insert(It.IsAny<User>()));

           var result = new UserService(_userRepositoryMock.Object).Insert(UserFactory.GetUser());

            Assert.True(result);
        }

        [Fact(DisplayName = "Update usuario novo")]
        public void UpdateUserTrue()
        {
            _userRepositoryMock.Setup(x => x.Update(It.IsAny<User>()));

            var result = new UserService(_userRepositoryMock.Object).Update(UserFactory.GetUser());

            Assert.True(result);
        }

        [Fact(DisplayName = "Delete usuario novo")]
        public void DeleteUserTrue()
        {
            _userRepositoryMock.Setup(x => x.Delete(new Guid()));

            var result = new UserService(_userRepositoryMock.Object).Delete(UserFactory.GetNewGuid());

            Assert.True(result);
        }
    }
}
