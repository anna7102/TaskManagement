using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
   
    [ApiController]
    [Route("api/v1/pokemon")]
    public class PokemonController : ControllerBase
    {
        private IEnumerable<PokemonAPI> _pokemons = new List<PokemonAPI>
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
            },
            new PokemonAPI
            {
                Id = 2,
                Name = "Pokemon2",
                NumeroNational = 2,
                types = new List<string>
                {
                    "eau"
                }
            },
            new PokemonAPI
            {
                Id = 3,
                Name = "Pokemon3",
                NumeroNational = 3,
                types = new List<string>
                {
                    "eau"
                }
            },

        };
       
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PokemonAPI>), 200)]
        public ActionResult<IEnumerable<PokemonAPI>> GetPokemonsByType(string type)
        {
            var pokemons = _pokemons.Where(pokemon =>  string.IsNullOrEmpty(type) || pokemon.types.Contains(type));
            return Ok(pokemons);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PokemonAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<PokemonAPI> GetPokemon(int id)
        {
            var specificPokemon = _pokemons.SingleOrDefault(pokemon => pokemon.Id == id);
            if (specificPokemon == null)
            {
                return NoContent();
            }
            return Ok(specificPokemon);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(PokemonAPI), 201)]
        public ActionResult<PokemonAPI> AddPokemon(PokemonAPI pokemonToAdd)
        {
            pokemonToAdd.Id = _pokemons.Max(pokemon => pokemon.Id) + 1;
            pokemonToAdd.NumeroNational = _pokemons.Max(pokemon => pokemon.NumeroNational) + 1;
            return Created("", pokemonToAdd);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PokemonAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<PokemonAPI> UpdatePokemon(int id, PokemonAPI pokemonToUpdate)
        {
            var searchedPokemon = _pokemons.SingleOrDefault(pokemon => pokemon.Id == id);
            if (searchedPokemon != null)
            {
                searchedPokemon.NumeroNational = pokemonToUpdate.NumeroNational;
                searchedPokemon.Name = pokemonToUpdate.Name;
                return Ok(searchedPokemon);
            }
            return NoContent();
          
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<PokemonAPI>), 200)]
        public ActionResult DeletePokemon(int id)
        {
            var pokemonsAfterDelete = _pokemons.Where(pokemon => pokemon.Id != id).ToList();
            return Ok(pokemonsAfterDelete);
        }
    }
}