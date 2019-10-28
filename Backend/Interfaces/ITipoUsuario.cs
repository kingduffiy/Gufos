using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;

namespace Backend.Interfaces
{
    public interface ITipoUsuario
    {
         Task<List<TipoUsuario>> Listar();

         Task<TipoUsuario> BuscarPorId(int id);
         
         Task<TipoUsuario> Salvar(TipoUsuario TipoUsuario);

         Task<TipoUsuario> Alterar(TipoUsuario TipoUsuario);

         Task<TipoUsuario> Excluir(TipoUsuario TipoUsuario);
    }
}