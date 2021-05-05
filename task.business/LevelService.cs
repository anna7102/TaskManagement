using System;
using System.Collections.Generic;
using task.Model;

namespace task.business
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public Level GetLevel(int id)
        {
            return _levelRepository.Get(id);
        }

        public IEnumerable<Level> GetAll()
        {
            return _levelRepository.GetAll();
        }

        public Level AddLevel(Level levelToAdd)
        {
            var id = _levelRepository.AddLevel(levelToAdd);
            if (id == 0)
            {
                return null;
            }

            return this.GetLevel(id);
        }

        public void Delete(int levelId)
        {
            _levelRepository.DeleteLevel(levelId);
        }
    }
}