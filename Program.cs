using System;
using System.Collections.Generic;

namespace pokemonappv1;
class Program
{
    static void Main(string[] args)
    {        
        // Fields
        Random rand = new Random();

        List<Pokemon> pokemonList = new List<Pokemon>();
        pokemonList.Add(new Pokemon(PokeNames.Bulbasaur.ToString(), Types.GRASS.ToString(), 10, (int)PokeNames.Bulbasaur, 29, 1));
        pokemonList.Add(new Pokemon(PokeNames.Charmander.ToString(), Types.FIRE.ToString(), 10, (int)PokeNames.Charmander, 19, 1));
        pokemonList.Add(new Pokemon(PokeNames.Squirtle.ToString(), Types.WATER.ToString(), 10, (int)PokeNames.Squirtle, 20, 1));

        bool isPlaying = false;

        do
        {
            Console.WriteLine("It's time to have a Pokemon battle!");
            Console.WriteLine("Choose your Pokemon:");
            
            Pokemon userPokemon = CheckChoice(pokemonList);
            userPokemon.IsPokemon();

            Pokemon compPokemon = pokemonList[rand.Next(0,3)];
            compPokemon.IsPokemon();

            if (BattleResult(userPokemon, compPokemon))
            {
                Console.WriteLine("You won!");
            }
            else if (BattleResult(compPokemon, userPokemon))
            {
                Console.WriteLine("You lost........");
            }
            else
            {
                Console.WriteLine("It's a draw");
            }

            bool y = false;
            bool n = false;
            do
            {
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("please enter:\n\ty\n\tn");
                // isPlaying = String.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase) ? true : false;
                
                string? keepPlaying = Console.ReadLine();
                y = String.Equals(keepPlaying, "y", StringComparison.OrdinalIgnoreCase);
                n = String.Equals(keepPlaying, "n", StringComparison.OrdinalIgnoreCase);
                if (y)
                {
                    isPlaying = true;
                }
                else
                {
                    isPlaying = false;
                }
            } while (!y && !n);
        } while (isPlaying);
    }

    public static Pokemon CheckChoice(List<Pokemon> pokeList)
    {
        bool success = false;
        string? pokeName = "";

        do
        {
            // Present user with choices
            Console.WriteLine("\tBulbasaur");
            Console.WriteLine("\tCharmander");
            Console.WriteLine("\tSquirtle");

            // Get player choice
            pokeName = Console.ReadLine();
            if (pokeName == null)
            {
                pokeName = "";
            }

            // Choice validation
            foreach (Pokemon pokemon in pokeList)
            {
                if (String.Equals(pokeName, pokemon.name, StringComparison.OrdinalIgnoreCase))
                {
                    return pokemon;
                }
            }
            
            if (!pokeList.Contains(new Pokemon { name = pokeName }))
            {
                Console.WriteLine("Invalid Choice. Please choose again:");
                success = false;
            }
            

        } while (!success);

        return new Pokemon();
    }

    public static bool BattleResult(Pokemon p1, Pokemon p2)
    {
        bool waterWins = String.Equals(p1.type, Types.WATER.ToString()) && String.Equals(p2.type, Types.FIRE.ToString());
        bool fireWins = String.Equals(p1.type, Types.FIRE.ToString()) && String.Equals(p2.type, Types.GRASS.ToString());
        bool grassWins = String.Equals(p1.type, Types.GRASS.ToString()) && String.Equals(p2.type, Types.WATER.ToString());
        
        return waterWins || fireWins || grassWins;
    }
}