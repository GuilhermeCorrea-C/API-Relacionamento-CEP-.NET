using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIRelacionamento.Models
{
    public class ColaboradorModel
    {
        public int idColaborador { get; set; }
        public string nome { get; set; }
        public decimal salario { get; set; }
        public string CepColaborador { get; set; }

        [JsonIgnore]
        public virtual ViaCepModel? ViaCep{ get; set; }

        public ICollection<DependenteModel>? ListaDependentes {get; set;}

    }
}