using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIRelacionamento.Data;
using APIRelacionamento.Models;
using APIRelacionamento.Repositorios.Interfaces;

namespace APIRelacionamento.Repositorios
{
    public class DependentesRepositorio : IDependentesRepositorio
    {   
        private readonly SistemaConsultasDBContext _dbContext;

        public DependentesRepositorio(SistemaConsultasDBContext db){
            _dbContext = db;
        }

         public async Task<DependenteModel> BuscarPorId(int id)
        {
            return await _dbContext.Dependentes.FirstOrDefaultAsync(x => x.idDependente == id);
        }

        public async Task<List<DependenteModel>> BuscarTodosDependentes()
        {
            return await _dbContext.Dependentes.ToListAsync();
        }
        
    

        public async Task<DependenteModel> Adicionar(DependenteModel dependente)
        {
            await _dbContext.Dependentes.AddAsync(dependente);
            await _dbContext.SaveChangesAsync();

            return dependente;
        }

        public async Task<bool> Apagar(int id)
        {
            var dependentePorId = await BuscarPorId(id);
            if(dependentePorId == null){
                throw new Exception($"Dependente do Id {id} não encontrado.");
            }
            _dbContext.Dependentes.Remove(dependentePorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<DependenteModel> Atualizar(DependenteModel dependente, int id)
        {
            var dependentePorId = await BuscarPorId(id);
            if(dependentePorId == null){
                throw new Exception($"Dependente do Id {id} não encontrado.");
            } 
            dependentePorId.idDependente = dependente.idDependente;
            dependentePorId.nome = dependente.nome;
            dependentePorId.sobrenome = dependente.sobrenome;
            dependentePorId.idColaborador = dependente.idColaborador;

            _dbContext.Dependentes.Update(dependentePorId);
            await _dbContext.SaveChangesAsync();

            return dependentePorId;
        }

       
    }
}