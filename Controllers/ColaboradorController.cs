using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;
using APIRelacionamento.Repositorios;
using APIRelacionamento.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIRelacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradoresRepositorios _colaboradoresRepositorios;

        public ColaboradorController(IColaboradoresRepositorios colab){
            _colaboradoresRepositorios = colab;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColaboradorModel>>> BuscarTodosColaboradores(){
            List<ColaboradorModel> colaboradores = await _colaboradoresRepositorios.BuscarTodosColaboradores();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorModel>> BuscarPorId(int id){
            ColaboradorModel colaborador = await _colaboradoresRepositorios.BuscarPorId(id);
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorModel>> Adicionar([FromBody]ColaboradorModel colaborador){
            ColaboradorModel colab = await _colaboradoresRepositorios.Adicionar(colaborador);
            return Ok(colab);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(int id){
            bool validacao = await _colaboradoresRepositorios.Apagar(id);
            return validacao;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColaboradorModel>> Atualizar(ColaboradorModel colaborador, int id){
            colaborador.idColaborador = id;
            var colab = await _colaboradoresRepositorios.Atualizar(colaborador, id);
            return Ok(colab);
        }

    }
}