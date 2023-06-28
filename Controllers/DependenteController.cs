using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Data;
using APIRelacionamento.Models;
using APIRelacionamento.Repositorios;
using APIRelacionamento.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIRelacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependenteController : ControllerBase
    {
        private readonly  IDependentesRepositorio _dependentesRepositorio;

        public DependenteController(IDependentesRepositorio dependentesRepositorio)
        {
            _dependentesRepositorio = dependentesRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<DependenteModel>>> BuscarTodosDependentes()
        {
           List<DependenteModel> lista =  await _dependentesRepositorio.BuscarTodosDependentes();
           return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DependenteModel>> BuscarDependentePorId(int id)
        {
            var depen = await _dependentesRepositorio.BuscarPorId(id);
            return Ok(depen);
        }

        [HttpPost]
        public async Task<ActionResult<DependenteModel>> Adicionar([FromBody]DependenteModel dependente)
        {
            var depen = await _dependentesRepositorio.Adicionar(dependente);
            return Ok(depen);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DependenteModel>> Atualizar(DependenteModel dependente, int id)
        {   
            dependente.idDependente = id;
            var depen = await _dependentesRepositorio.Atualizar(dependente, id);
            return Ok(depen);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            var boolea =await _dependentesRepositorio.Apagar(id);

            return Ok(boolea);
        }
    }
}