using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;

namespace APIRelacionamento.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepModel> ObterDadosViaCep(string cep);
    }
}