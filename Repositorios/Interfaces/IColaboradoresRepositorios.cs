using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRelacionamento.Models;

namespace APIRelacionamento.Repositorios.Interfaces
{
    public interface IColaboradoresRepositorios
    {
    
        Task<List<ColaboradorModel>> BuscarTodosColaboradores();

        Task<ColaboradorModel> BuscarPorId(int id);

        Task<ColaboradorModel> Adicionar(ColaboradorModel feriado);

        Task<ColaboradorModel> Atualizar(ColaboradorModel feriado, int id);

        Task<bool> Apagar(int id);
    } 
    
}