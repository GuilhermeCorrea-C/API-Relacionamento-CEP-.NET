using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Integracao.Interfaces;
using APIRelacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRelacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }
     [HttpGet("{cep}")]
     public async Task<ActionResult<ViaCepModel>> ListarDadosEndereco(string cep){
        var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);
        if(responseData != null)
        {
            return Ok(responseData);
        }
        return BadRequest("Cep nao encontrado!");
     }   
    }
}