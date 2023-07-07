using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRelacionamento.Models
{
    public class ViaCepModel
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }      
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Ibge { get; set; }
        public string? Gia { get; set; }
        public string? DDD { get; set; }
        public string? Siafi { get; set; }
        public virtual ICollection<ColaboradorModel>? Colaboradores { get; set; }

    }
}