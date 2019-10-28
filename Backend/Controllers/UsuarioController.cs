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
    public class UsuarioController : ControllerBase
    {
        // GufosContext _contexto = new GufosContext();

        UsuarioRepository _repositorio = new UsuarioRepository();

        // GET : api/Usuario
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get(){

            var Usuarios = await _repositorio.Listar();

            if(Usuarios == null){
                return NotFound();
            }

            return Usuarios;

        }

        // GET : api/Usuario2
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id){

            // FindAsync = procura algo específico no banco
            var Usuario = await _repositorio.BuscarPorId(id);

            if(Usuario == null){
                return NotFound();
            }

            return Usuario;

        }

        // POST api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario Usuario){

            try
            {
                await _repositorio.Salvar(Usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return Usuario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario Usuario){
            // Se o id do objeto não existir, ele retorna erro 400
            if(id != Usuario.UsuarioId){
                return BadRequest();
            }
            
            

            try
            {

                await _repositorio.Alterar(Usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verificamos se o objeto inserido realmente existe no banco
                var Usuario_valido = await _repositorio.BuscarPorId(id);

                if(Usuario_valido == null){
                    return NotFound();
                }else{

                throw;
                }

                
            }
            // NoContent = retorna 204, sem nada
            return NoContent();
        }

        // DELETE api/Usuario/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id){
            var Usuario = await _repositorio.BuscarPorId(id);
            if(Usuario == null){
                return NotFound();
            }
            await _repositorio.Excluir(Usuario);
            
            return Usuario;
        }
    }
}