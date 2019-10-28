using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;

namespace Backend.Interfaces
{
    public interface IUsuario
    {
         Task<List<Usuario>> Listar();

         Task<Usuario> BuscarPorId(int id);
         
         Task<Usuario> Salvar(Usuario Usuario);

         Task<Usuario> Alterar(Usuario Usuario);

         Task<Usuario> Excluir(Usuario Usuario);
    }
}