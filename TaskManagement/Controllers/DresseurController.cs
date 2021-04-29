using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
   
    [ApiController]
    [Route("api/v1/dresseur")]
    public class DresseurController : ControllerBase
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DresseurAPI>), 200)]
        public ActionResult<IEnumerable<DresseurAPI>> GetDresseurs()
        {
            return Ok();
        }
        
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DresseurAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<DresseurAPI> GetDresseur(int id)
        {
          
            return Ok();
        }
        
        [HttpGet("{id}/pokemon")]
        [ProducesResponseType(typeof(IEnumerable<PokemonAPI>), 200)]
        [ProducesResponseType(204)]
        public ActionResult<IEnumerable<PokemonAPI>> GetPokemonsByDresseur(int id)
        {
            return Ok(new List<PokemonAPI>
            {
                new PokemonAPI
                {
                    Id = 1,
                    Name = "Pokemon1",
                    NumeroNational = 1,
                    types = new List<string>
                    {
                        "feu"
                    }
                }
            });
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(DresseurAPI), 201)]
        public ActionResult<DresseurAPI> AddDresseur(DresseurAPI dresseurToAdd)
        {
            return Created("", dresseurToAdd);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DresseurAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<DresseurAPI> UpdateDresseur(int id, DresseurAPI pokemonToUpdate)
        {
            return Ok();
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<DresseurAPI>), 200)]
        public ActionResult DeletePokemon(int id)
        {
            return Ok();
        }

    }
}