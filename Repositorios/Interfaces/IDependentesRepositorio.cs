using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;

namespace APIRelacionamento.Repositorios.Interfaces
{
    public interface IDependentesRepositorio
    {

        Task<List<DependenteModel>> BuscarTodosDependentes();

        Task<DependenteModel> BuscarPorId(int id);

        Task<DependenteModel> Adicionar(DependenteModel feriado);

        Task<DependenteModel> Atualizar(DependenteModel feriado, int id);

        Task<bool> Apagar(int id);
    } 
    
}