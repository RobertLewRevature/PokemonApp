using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp
{
    class Charmander : Pokemon
    {
        public Charmander(int lvl)
        {
            name = PokeNames.Charmander.ToString();
            type = Types.FIRE.ToString();
            dexNumber = (int)PokeNames.Charmander;
            level = lvl;
            hitpoints = 39;
            attack = 52;
            // attack = 187;
            defense = 43;
            speed = 65;
            moves = new string[] { "Scratch", "", "", "" };
        }
    }
}