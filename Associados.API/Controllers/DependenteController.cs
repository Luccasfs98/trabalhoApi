using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.API.DTOs;
using Associados.Domain.DependenteRoot;
using Associados.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class DependenteController : Controller
    {
        IDependenteRepository repository;

        public DependenteController(IDependenteRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Dependente>>Get()
        {
            return await this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task <Dependente> Get(int id)
        {
            return await this.repository.GetById(id);
        }

        [HttpGet("dto")]
        public async Task<IEnumerable<DependenteDTO>> GetAllDTOAsync()
        {
            var dependentes = await this.repository.GetAll();
            var depDTO = new List<DependenteDTO>();
             dependentes.ForEach(dependente =>
            {
                depDTO.Add(
                     new DependenteDTO
                    {
                        Name = dependente.Nome,
                    }
                );
            });
            return depDTO;
        }

        [HttpPost]
        public async Task <IActionResult> Post([FromBody]Dependente dependente)
        {
            await repository.Add(dependente);
            return Ok(dependente);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Dependente dependente)
        {
            await this.repository.Update(dependente);
            return Ok(dependente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!"
            });
        }
    }
}