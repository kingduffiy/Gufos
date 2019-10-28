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
    public class TipoUsuarioController : ControllerBase
    {
        // GufosContext _contexto = new GufosContext();

        TipoUsuarioRepository _repositorio = new TipoUsuarioRepository();

        // GET : api/TipoUsuario
        [HttpGet]
        public async Task<ActionResult<List<TipoUsuario>>> Get(){

            var TipoUsuarios = await _repositorio.Listar();

            if(TipoUsuarios == null){
                return NotFound();
            }

            return TipoUsuarios;

        }

        // GET : api/TipoUsuario2
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> Get(int id){

            // FindAsync = procura algo específico no banco
            var TipoUsuario = await _repositorio.BuscarPorId(id);

            if(TipoUsuario == null){
                return NotFound();
            }

            return TipoUsuario;

        }

        // POST api/TipoUsuario
        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario TipoUsuario){

            try
            {
                await _repositorio.Salvar(TipoUsuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return TipoUsuario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoUsuario TipoUsuario){
            // Se o id do objeto não existir, ele retorna erro 400
            if(id != TipoUsuario.TipoUsuarioId){
                return BadRequest();
            }
            
            

            try
            {

                await _repositorio.Alterar(TipoUsuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verificamos se o objeto inserido realmente existe no banco
                var TipoUsuario_valido = await _repositorio.BuscarPorId(id);

                if(TipoUsuario_valido == null){
                    return NotFound();
                }else{

                throw;
                }

                
            }
            // NoContent = retorna 204, sem nada
            return NoContent();
        }

        // DELETE api/TipoUsuario/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUsuario>> Delete(int id){
            var TipoUsuario = await _repositorio.BuscarPorId(id);
            if(TipoUsuario == null){
                return NotFound();
            }
            await _repositorio.Excluir(TipoUsuario);
            
            return TipoUsuario;
        }
    }
}