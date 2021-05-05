using System.Collections;
using System.Collections.Generic;

namespace task.Model
{
    public interface ILevelService
    {
        public Level GetLevel(int id);
        
        public IEnumerable<Level> GetAll();

        public Level AddLevel(Level levelToAdd);

        void Delete(int levelId);

    }
}