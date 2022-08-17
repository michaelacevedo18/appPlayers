using Core.Dtos;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ResponseDto _response;
        public PlayersController(ApplicationDbContext db)
        {
            _response = new ResponseDto();
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var lista = await _db.Players.Include(x=>x.Team).Include(x=>x.Position).ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de jugadores";
            _response.IsExitoso = true;
            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _db.Players.FindAsync(id);
            _response.Resultado = player;
            _response.Mensaje = "Datos del jugador" + player.Id;
            _response.IsExitoso = true;
            return Ok(_response);  //Status code 200
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer([FromBody] Player player)
        {
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetPlayer", new { id = player.Id }, player); //Status code 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPlayer(int id, [FromBody] Player player)
        {
            if (id != player.Id)
            {
                return BadRequest("Id del jugador no coincide");
            }
            _db.Update(player);
            await _db.SaveChangesAsync();
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            _db.Players.Remove(player);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
