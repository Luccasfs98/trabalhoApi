using System;

namespace Associados.Domain.DependenteRoot
{
    public class Dependente : Entity
    {

        public string Nome { get; set; }   

        public string GrauParentesco { get; set; }

        public DateTime DataNascimento { get; set; }
        
    }
}