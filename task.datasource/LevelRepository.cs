using System;
using System.Collections.Generic;
using System.Linq;
using task.Model;

namespace task.datasource
{
    public class LevelRepository : ILevelRepository
    {
        private IEnumerable<Level> _levels = new List<Level>
        {
            
            new Level
            {
                id = 1,
                number = 1,
                points = 0
            },
            new Level
            {
                id = 2,
                number = 2,
                points = 25
            },
            new Level
            {
                id = 3,
                number = 3,
                points = 50
            }
            
            

        };

        public IEnumerable<Level> GetAll()
        {
            return _levels;
        }

        public Level Get(int id)
        {
            return _levels.FirstOrDefault(level => level.id == id);
        }

        public int AddLevel(Level level)
        {
            int maxId = _levels.Max(level => level.id);
            int maxNumber = _levels.Max(level => level.number);
            int maxPoints = _levels.Max(level => level.points);
            level.id = maxId + 1;
            level.number = maxNumber + 1;
            level.points =  maxPoints + 25;
            _levels = _levels.Concat(new List<Level> {level});
            return level.id;
        }

        public void DeleteLevel(int levelId)
        {
             var levelToDelete =   _levels.FirstOrDefault(level => level.id == levelId);
             if (levelToDelete != null)
             {
                 var levelList = _levels.ToList();
                 levelList.Remove(levelToDelete);
                 _levels = levelList;
             }
             

        }
    }
}