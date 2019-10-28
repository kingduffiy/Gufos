using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class PresencaRepository : IPresenca
    {
        public async Task<Presenca> Alterar(Presenca presenca)
        {
            using(GufosContext _contexto = new GufosContext()){
                // Comparamos os atributos que foram modificados através do EF
            _contexto.Entry(presenca).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            }
            return presenca;
        }
        

        public async Task<Presenca> BuscarPorId(int id)
        {
            using(GufosContext _contexto = new GufosContext()){
                return await _contexto.Presenca.FindAsync(id);
            }
        }

        public async Task<Presenca> Excluir(Presenca presenca)
        {
            using(GufosContext _contexto = new GufosContext()){
                _contexto.Presenca.Remove(presenca);
            await _contexto.SaveChangesAsync();
            return presenca;

            }
        }
        

        public async Task<List<Presenca>> Listar()
        {
            using(GufosContext _contexto = new GufosContext()){
                return await _contexto.Presenca.ToListAsync();
            }
        }

        public async Task<Presenca> Salvar(Presenca presenca)
        {
            using(GufosContext _contexto = new GufosContext()){
                // Tratamos contra ataques de SQL Injection
                await _contexto.AddAsync(presenca);
                // Salvamos efetivamente o nosso objeto no banco de dados
                await _contexto.SaveChangesAsync();
                return presenca;
            }
        }
        }
    }
