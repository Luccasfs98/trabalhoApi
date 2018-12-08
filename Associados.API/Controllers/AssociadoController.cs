using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.API.DTOs;
using Associados.Domain.AssociadoRoot;
using Associados.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Associados.API.Controllers
{

    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        private readonly IAssociadoRepository repository;

        public AssociadoController(IAssociadoRepository repository)
        {
            this.repository = repository;
        }

         [HttpGet]
        public async Task<IEnumerable<Associado>> Get()
        {
            return await this.repository.GetAll();
        }

        [HttpGet("dto")]
        public async Task <IEnumerable<AssociadoDTO>> GetDTOs()
        {
            var associados = await this.repository.GetAll();

            var dto = new List<AssociadoDTO>();

            associados.ForEach(associado =>
            {
                var associadosDTO = new AssociadoDTO{
                    Nome = associado.Name,
                    DataCadastro = associado.DataCadastro
                };

                associado.Dependentes.ForEach( dependente =>
                {
                    associadosDTO.Dependentes.Add(
                        new DependenteDTO{
                            Name = dependente.Nome
                        }
                    );
                });

                dto.Add(associadosDTO);
            });
            return dto;
        }



        [HttpGet("{id}")]
        public async Task<Associado> Get(int id)
        {
            return await this.repository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Associado associado)
        {
            await this.repository.Add(associado);
            return Ok(associado);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Associado associado)
        {
            await this.repository.Update(associado);
            return Ok(associado);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!"
            });
        }
    }
}