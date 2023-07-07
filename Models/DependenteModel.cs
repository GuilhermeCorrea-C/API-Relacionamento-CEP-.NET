using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRelacionamento.Models
{
    public class DependenteModel
    {
        public int idDependente { get; set; }
        public string nome { get; set;}
        public string sobrenome { get; set; }
        public int idColaborador { get; set; }
        public virtual ColaboradorModel? Colaborador { get; set; }

    }
}