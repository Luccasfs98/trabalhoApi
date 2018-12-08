using System;
using System.Collections.Generic;
using Associados.Domain.DependenteRoot;

namespace Associados.API.DTOs
{
    public class AssociadoDTO 
    {
        public string Nome;

        public DateTime DataCadastro;

       public List<DependenteDTO> Dependentes = new List<DependenteDTO>();

    }
}