using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Data;
using APIRelacionamento.Integracao.Interfaces;
using APIRelacionamento.Integracao.Refit;
using APIRelacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIRelacionamento.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao 
    {
        private readonly SistemaConsultasDBContext _dbContext;

        private readonly IViaCepIntegracaoRefit _ViaCepIntegracaoRefit;

        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit, SistemaConsultasDBContext db)
        {
            _dbContext = db;
            _ViaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        public async Task<ViaCepModel> ObterDadosViaCep(string cep)
        {
            var dados = await _ViaCepIntegracaoRefit.ObterDadosViaCep(cep);
            
            if(dados.IsSuccessStatusCode){
                var VCM = dados.Content;

                await _dbContext.InfoCep.AddAsync(VCM);
                await _dbContext.SaveChangesAsync();

                return VCM;
            }

            return null;
        }
    }
}