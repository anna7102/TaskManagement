using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using task.Model;
using TaskManagement.Helper;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
   
    [ApiController]
    [Route("api/v1/level")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService  _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        private IEnumerable<LevelAPI> _levels = new List<LevelAPI>
        {
            /*
            new LevelAPI
            {
                id = 1,
                number = 1,
                points = 0
            },
            new LevelAPI
            {
                id = 2,
                number = 2,
                points = 25
            },
            new LevelAPI
            {
                id = 3,
                number = 3,
                points = 50
            }
            
            */

        };
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LevelAPI>), 200)]
        public ActionResult<IEnumerable<LevelAPI>> GetLevels()
        {
            var allLevels = _levelService.GetAll();

            if (allLevels.Any())
            {
                return Ok(allLevels);
            }

            return NoContent();
            
        }
        
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LevelAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<LevelAPI> GetLevel(int id)
        {
          
           // var specificLevel = _levels.SingleOrDefault(level => level.id == id);
           var specificLevel = _levelService.GetLevel(id);
            if (specificLevel == null)
            {
                return NoContent();
            }
            return Ok(specificLevel);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(LevelAPI), 201)]
        public ActionResult<LevelAPI> AddLevel(LevelAPI levelToAdd)
        {
            var newLevel = _levelService.AddLevel(levelToAdd.Convert());
            if (newLevel != null)
            {
                
                return Created("", levelToAdd);
            }

            return BadRequest();
            /*
            levelToAdd.id = _levels.Max(level => level.id) + 1;
            levelToAdd.number = _levels.Max(level => level.number) + 1;
            levelToAdd.points = _levels.Max(level => level.points) + 25;
            */

        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LevelAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<LevelAPI> UpdateLevel(int id, LevelAPI levelToUpdate)
        {
            var searchedLevel = _levels.SingleOrDefault(level => level.id == id);
            if (searchedLevel != null)
            {
                searchedLevel.number = levelToUpdate.number;
                searchedLevel.points = levelToUpdate.points;
                return Ok(searchedLevel);
            }
            return NoContent();
          
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<LevelAPI>), 200)]
        public ActionResult DeleteLevel(int id)
        {
            _pokemonService.Delete(id);
            /*
            var levelsAfterDelete = _levels.Where(level => level.id != id).ToList();
            return Ok(levelsAfterDelete);
            */
        }
    }
}