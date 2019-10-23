using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    // Definimos nossa rota do controller e dizemos que é um controller de API
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        GufosContext _contexto = new GufosContext();

        // GET : api/Localizacao
        [HttpGet]
        public async Task<ActionResult<List<Localizacao>>> Get(){

            var localizacoes = await _contexto.Localizacao.ToListAsync();

            if(localizacoes == null){
                return NotFound();
            }

            return localizacoes;

        }

        // GET : api/Localizacao2
        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> Get(int id){

            // FindAsync = procura algo específico no banco
            var categoria = await _contexto.Localizacao.FindAsync(id);

            if(categoria == null){
                return NotFound();
            }

            return categoria;

        }

        // POST api/Localizacao
        [HttpPost]
        public async Task<ActionResult<Localizacao>> Post(Localizacao categoria){

            try
            {
                // Tratamos contra ataques de SQL Injection
                await _contexto.AddAsync(categoria);
                // Salvamos efetivamente o nosso objeto no banco de dados
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Localizacao categoria){
            // Se o id do objeto não existir, ele retorna erro 400
            if(id != categoria.LocalizacaoId){
                return BadRequest();
            }
            
            // Comparamos os atributos que foram modificados através do EF
            _contexto.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verificamos se o objeto inserido realmente existe no banco
                var categoria_valido = await _contexto.Localizacao.FindAsync(id);

                if(categoria_valido == null){
                    return NotFound();
                }else{

                throw;
                }

                
            }
            // NoContent = retorna 204, sem nada
            return NoContent();
        }

        // DELETE api/categoria/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localizacao>> Delete(int id){
            var categoria = await _contexto.Localizacao.FindAsync(id);
            if(categoria == null){
                return NotFound();
            }
            _contexto.Localizacao.Remove(categoria);
            await _contexto.SaveChangesAsync();

            return categoria;
        }
    }
}