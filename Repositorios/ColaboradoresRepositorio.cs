using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Data;
using APIRelacionamento.Models;
using APIRelacionamento.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIRelacionamento.Repositorios
{
    public class ColaboradoresRepositorio : IColaboradoresRepositorios
    {

        private readonly SistemaConsultasDBContext _dbContext;        

        public ColaboradoresRepositorio(SistemaConsultasDBContext db){
            _dbContext = db;
        }
         public async Task<ColaboradorModel> BuscarPorId(int id)
        {
            return await _dbContext.Colaboradores.Include(c => c.ListaDependentes).SingleOrDefaultAsync( x => x.idColaborador == id);
        }

        public async Task<List<ColaboradorModel>> BuscarTodosColaboradores()
        {
            return await _dbContext.Colaboradores.Include(c => c.ListaDependentes).ToListAsync();
        }
        public async Task<ColaboradorModel> Adicionar(ColaboradorModel colaborador)
        {
            await _dbContext.Colaboradores.AddAsync(colaborador);
            await _dbContext.SaveChangesAsync();

            return colaborador;
        }

        public async Task<bool> Apagar(int id)
        {
            var ColaboradorPorId = await BuscarPorId(id);
            if(ColaboradorPorId == null){
                return false;
            }
            else{
                _dbContext.Colaboradores.Remove(ColaboradorPorId);
                await _dbContext.SaveChangesAsync();

                return true;
            }

        }

        public async Task<ColaboradorModel> Atualizar(ColaboradorModel colaborador, int id)
        {
            var ColaboradorPorId = await BuscarPorId(id);
            if(ColaboradorPorId == null){
                throw new Exception($"Colaborador para o Id {id} não encontrado!");
            }
            ColaboradorPorId.idColaborador = colaborador.idColaborador;
            ColaboradorPorId.nome = colaborador.nome;
            ColaboradorPorId.salario = colaborador.salario;
            ColaboradorPorId.ListaDependentes = colaborador.ListaDependentes;

            _dbContext.Update(ColaboradorPorId);
            await _dbContext.SaveChangesAsync();

            return ColaboradorPorId;
        }

       
    }
}