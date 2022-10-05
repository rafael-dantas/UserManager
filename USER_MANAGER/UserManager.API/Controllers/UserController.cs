using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManager.API.Contract.Request;
using UserManager.API.Models;
using UserManager.Service.Interface;

namespace UserManager.API.Controllers
{

    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSevice;

        public UserController(IUserService userService)
        {
            _userSevice = userService;
        }       

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] UserContractRequest user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email))
            {
                _userSevice.Insert(user);

                return Ok(new MessageResponse { Mensagem = "Usuário inserido com sucesso!", IsSuccess = true });
            }

            return BadRequest(new MessageResponse { Mensagem = "Dados Incorretos", IsSuccess = false });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put([FromBody] UserContractRequest user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email) && user.Id != null)
            {
                _userSevice.Update(user);

                return Ok(new MessageResponse{ Mensagem = "Usuário alterado com sucesso!", IsSuccess = true });
            }

            return BadRequest(new MessageResponse { Mensagem = "Erro ao processar requisição", IsSuccess = false });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromQuery] string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                _userSevice.Delete(new Guid(Id));

                return Ok(new MessageResponse  { Mensagem = "Usuário excluido com sucesso!", IsSuccess = true });
            }

            return BadRequest(new MessageResponse  { Mensagem = "Erro ao processar requisição", IsSuccess = false });
        }
    }
}
