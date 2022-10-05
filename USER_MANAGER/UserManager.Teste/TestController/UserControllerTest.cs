using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.API.Contract.Request;
using UserManager.API.Controllers;
using UserManager.API.Models;
using UserManager.Domain;
using UserManager.Service.Interface;
using UserManager.Teste.Factory;
using Xunit;

namespace UserManager.Teste.TestController
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact(DisplayName = "Inserir usuario novo OK")]
        public void InsertUserOK()
        {
            _userServiceMock.Setup(x => x.Insert(It.IsAny<User>()));

            var customerController = new UserController(_userServiceMock.Object).Post(UserFactory.GetContractRequest());
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;
            
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "Inserir usuario novo BadRequest")]
        public void InsertUserBadRequest()
        {
            _userServiceMock.Setup(x => x.Insert(It.IsAny<User>()));

            var customerController = new UserController(_userServiceMock.Object).Post(UserFactory.GetContractBadRequest());
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;

            Assert.False(result.IsSuccess);
        }

        [Fact(DisplayName = "Alterar usuario OK")]
        public void UpdateUserOK()
        {
            _userServiceMock.Setup(x => x.Update(It.IsAny<User>()));

            var customerController = new UserController(_userServiceMock.Object).Put(UserFactory.GetContractRequest());
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;

            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "Alterar usuario BadRequest")]
        public void UpdateUserBadRequest()
        {
            _userServiceMock.Setup(x => x.Update(It.IsAny<User>()));

            var customerController = new UserController(_userServiceMock.Object).Put(UserFactory.GetContractBadRequest());
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;

            Assert.False(result.IsSuccess);
        }

        [Fact(DisplayName = "Delete usuario OK")]
        public void DeleteUserOK()
        {
            _userServiceMock.Setup(x => x.Delete(new Guid()));

            var customerController = new UserController(_userServiceMock.Object).Delete(new Guid().ToString());
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;

            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "Delete usuario BadRequest")]
        public void DeleteUserBadRequest()
        {
            _userServiceMock.Setup(x => x.Delete(new Guid()));

            var customerController = new UserController(_userServiceMock.Object).Delete("");
            var result = (MessageResponse)((ObjectResult)customerController.Result).Value;

            Assert.False(result.IsSuccess);
        }
    }
}
