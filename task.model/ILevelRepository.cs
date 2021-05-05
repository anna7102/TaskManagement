using System.Collections.Generic;

namespace task.Model
{
    public interface ILevelRepository
    {
        IEnumerable<Level> GetAll();

        Level Get(int id);

        int AddLevel(Level level);
        void DeleteLevel(int levelId);
    }
}