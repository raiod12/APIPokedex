using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodekexAPI.Model
{
    public class PokemonALL
    {
        public string Id { get; set; }
        public int Pokedex_index { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public string Type { get; set; }
        public int Total { get; set; }
    }
}
