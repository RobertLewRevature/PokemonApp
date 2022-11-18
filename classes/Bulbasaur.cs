namespace PokemonApp
{
    class Bulbasaur : Pokemon, IDamagable
    {
        public Bulbasaur(int lvl)
        {
            name = PokeNames.Bulbasaur.ToString();
            type = Types.GRASS.ToString();
            dexNumber = (int)PokeNames.Bulbasaur;
            level = lvl;
            hitpoints = 45;
            attack = 49;
            defense = 49;
            // defense = 81;
            speed = 45;
            moves = new string[] { "Tackle", "", "", "" };
            Damagable();
        }

        public void Damagable()
        {
            isDamagable = true;
        }
    }
}