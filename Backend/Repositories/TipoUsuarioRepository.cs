using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        public async Task<TipoUsuario> Alterar(TipoUsuario tipoUsuario)
        {
            using(GufosContext _contexto = new GufosContext()){
                // Comparamos os atributos que foram modificados através do EF
            _contexto.Entry(tipoUsuario).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            }
            return tipoUsuario;
        }
        

        public async Task<TipoUsuario> BuscarPorId(int id)
        {
            using(GufosContext _contexto = new GufosContext()){
                return await _contexto.TipoUsuario.FindAsync(id);
            }
        }

        public async Task<TipoUsuario> Excluir(TipoUsuario tipoUsuario)
        {
            using(GufosContext _contexto = new GufosContext()){
                _contexto.TipoUsuario.Remove(tipoUsuario);
            await _contexto.SaveChangesAsync();
            return tipoUsuario;

            }
        }
        

        public async Task<List<TipoUsuario>> Listar()
        {
            using(GufosContext _contexto = new GufosContext()){
                return await _contexto.TipoUsuario.ToListAsync();
            }
        }

        public async Task<TipoUsuario> Salvar(TipoUsuario tipoUsuario)
        {
            using(GufosContext _contexto = new GufosContext()){
                // Tratamos contra ataques de SQL Injection
                await _contexto.AddAsync(tipoUsuario);
                // Salvamos efetivamente o nosso objeto no banco de dados
                await _contexto.SaveChangesAsync();
                return tipoUsuario;
            }
        }
        }
    }
