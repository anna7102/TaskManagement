using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
   
    [ApiController]
    [Route("api/v1/level")]
    public class LevelController : ControllerBase
    {
        private readonly IEnumerable<LevelAPI> levels = new List<LevelAPI>
        {
            new LevelAPI
            {
                id = 1,
                number = 1,
                points = 0,
                types = new List<string>
                {
                   "wizzard"
                }
            },
            new LevelAPI
            {
                id = 2,
                number = 2,
                points = 25,
                types = new List<string>
                {
                    "superman"
                }
            },
            new LevelAPI
            {
                id = 3,
                number = 3,
                points = 50,
                types = new List<string>
                {
                    "hulk"
                }
            }

        };
        /*
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LevelAPI>), 200)]
        public ActionResult<IEnumerable<LevelAPI>> GetLevels()
        {
            return Ok(levels);
           
        }
        */
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LevelAPI>), 200)]
        public ActionResult<IEnumerable<LevelAPI>> GetLevelsByType(string type)
        {
            var levelsByType = levels.Where(level =>  string.IsNullOrEmpty(type) || level.types.Contains(type));
            return Ok(levelsByType);
           
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LevelAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<LevelAPI> GetLevel(int id)
        {
            var specificLevel = levels.SingleOrDefault(level => level.id == id);
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
            levelToAdd.id = levels.Max(level => level.id) + 1;
            levelToAdd.number = levels.Max(level => level.number) + 1;
            levelToAdd.points = levels.Max(level => level.points) + 25;
            return Created("", levelToAdd);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LevelAPI), 200)]
        [ProducesResponseType(204)]
        public ActionResult<LevelAPI> UpdateLevel(int id, LevelAPI levelToUpdate)
        {
            var searchedLevel = levels.SingleOrDefault(level => level.id == id);
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
            var levelsAfterDelete = levels.Where(level => level.id != id).ToList();
            return Ok(levelsAfterDelete);
        }
    }
}