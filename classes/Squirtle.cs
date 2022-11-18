namespace PokemonApp
{
    class Squirtle : Pokemon, IDamagable
    {
        public Squirtle(int lvl)
        {
            name = PokeNames.Squirtle.ToString();
            type = Types.WATER.ToString();
            dexNumber = (int)PokeNames.Squirtle;
            level = lvl;
            hitpoints = 44;
            attack = 48;
            defense = 65;
            speed = 43;
            moves = new string[] { "Tackle", "", "", "" };
            Damagable();
        }

        public void Damagable()
        {
            isDamagable = true;
        }
    }
}