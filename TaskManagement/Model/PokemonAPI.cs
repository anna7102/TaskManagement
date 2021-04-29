using System.Collections;
using System.Collections.Generic;

namespace TaskManagement.Model
{
    public class PokemonAPI
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int NumeroNational { get; set; }
        
        public IEnumerable<string> types { get; set; }
 
    }
}