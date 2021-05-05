using System.Collections.Generic;
using task.Model;
using TaskManagement.Model;

namespace TaskManagement.Helper
{
    using System;
    using System.Linq;

    public static class ModelConverter
    {
        public static LevelAPI Convert(this Level source)
        {
            return new LevelAPI
            {
                id = source.id,
                number = source.number,
                points = source.points,
            };
        }

        public static Level Convert(this LevelAPI source)
        {
            return new Level
            {
                id = source.id,
                number = source.number,
                points = source.points,
            };
        }
    }
}