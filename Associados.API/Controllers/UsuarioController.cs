using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Associados.Domain.Interfaces;
using Associados.Domain.UsuarioRoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
         private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository) {
            this.repository = repository;
        }

        [Authorize]
        [HttpGet]
        public async Task <IEnumerable<Usuario>> Get()
        {
            return await this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Usuario> Get(int id)
        {
            return await this.repository.GetById(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Usuario usuario)
        {
           await this.repository.Update(usuario);
           return  Ok(usuario);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);
                return Ok
                (new 
                    {
                        message = "Deletado com sucesso!"
                    }
                );
        }


       
        [HttpPost]
        public async Task <IActionResult> Post([FromBody]Usuario item)
        {
            
            if (ModelState.IsValid)
            {
                 await this.repository.Add(item);
                 return Ok(item);
            } else
             {		
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                }
                return BadRequest(new {
                    message = errors
                });
            }
        }



        [HttpPost("authenticate")]    
         public  IActionResult Authentication ([FromBody]Usuario user)
         {
             var usuario = this.repository.AuthUser(user);

             if (usuario == null)
                return  BadRequest (new{
                    message = "Usuário Incorreto!"
                }
                );
            return Ok(new{
                token = BuildToken()
            });
         }

          public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenAssociadosApi"));
            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "TokenAssociadosApi",
                issuer: "TokenAssociadosApi",
                signingCredentials: creed
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}