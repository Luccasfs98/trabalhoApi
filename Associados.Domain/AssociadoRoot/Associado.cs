using System;
using System.Collections.Generic;
using Associados.Domain.DependenteRoot;

namespace Associados.Domain.AssociadoRoot
{
    public class Associado : Entity
    {

        public string Name { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; } 

        public string Uf { get; set; }      

        public string Cep { get; set; }  

        public string Email { get; set; }  

        public string Cpf { get; set; } 

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }
        
        public List<Dependente> Dependentes { get; set; }
    }
}