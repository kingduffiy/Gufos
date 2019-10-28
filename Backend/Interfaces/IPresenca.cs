using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;

namespace Backend.Interfaces
{
    public interface IPresenca
    {
         Task<List<Presenca>> Listar();

         Task<Presenca> BuscarPorId(int id);
         
         Task<Presenca> Salvar(Presenca categoria);

         Task<Presenca> Alterar(Presenca categoria);

         Task<Presenca> Excluir(Presenca categoria);
    }
}