using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domains;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    // Definimos nossa rota do controller e dizemos que é um controller de API
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        // GufosContext _contexto = new GufosContext();

        EventoRepository _repositorio = new EventoRepository();

        // GET : api/Evento
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get(){

            var eventos = await _repositorio.Listar();

            if(eventos == null){
                return NotFound();
            }

            return eventos;

        }

        // GET : api/Evento2
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id){

            // FindAsync = procura algo específico no banco
            var evento = await _repositorio.BuscarPorId(id);

            if(evento == null){
                return NotFound();
            }

            return evento;

        }

        // POST api/Evento
        [HttpPost]
        public async Task<ActionResult<Evento>> Post(Evento evento){

            try
            {
                await _repositorio.Salvar(evento);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return evento;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Evento evento){
            // Se o id do objeto não existir, ele retorna erro 400
            if(id != evento.EventoId){
                return BadRequest();
            }
            
            

            try
            {

                await _repositorio.Alterar(evento);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verificamos se o objeto inserido realmente existe no banco
                var evento_valido = await _repositorio.BuscarPorId(id);

                if(evento_valido == null){
                    return NotFound();
                }else{

                throw;
                }

                
            }
            // NoContent = retorna 204, sem nada
            return NoContent();
        }

        // DELETE api/evento/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> Delete(int id){
            var evento = await _repositorio.BuscarPorId(id);
            if(evento == null){
                return NotFound();
            }
            await _repositorio.Excluir(evento);
            
            return evento;
        }
    }
}