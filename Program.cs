using System.Text.RegularExpressions;

namespace PokemonApp;
class Program
{
    static void Main(string[] args)
    {
        
        Random rand = new Random();

        // int damage = ((int)(((int)((int)((((int)((2 * 73)/5) + 2) * 40 * 187) / 81) / 50) + 2) * 1.5 * 2 * 1) * rand.Next(217, 256)) / 255;
        
        // System.Console.WriteLine(damage);
       
        PlayGame();
    }

    static void PlayGame()
    {
        // Fields
        Random rand = new Random();

        // Dictionary of Moves
        Dictionary<string, int> moveList = new Dictionary<string, int>();
        moveList.Add("Tackle", 35);
        moveList.Add("Scratch", 40);

        bool isPlaying = false;

        do
        {
            // Player welcome
            Console.WriteLine("It's time to have a Pokemon battle!");
            Console.WriteLine("Choose your Pokemon:");

            // Pokemon selection
            Pokemon userPokemon = ValidatePlayerChoice();
            // Pokemon userPokemon = new Charmander(73);
            userPokemon.IsPokemon();
            Pokemon compPokemon = ComputerSelection(rand);
            // Pokemon compPokemon = new Bulbasaur(5);
            compPokemon.IsPokemon();

            BattleLoop(moveList, userPokemon, compPokemon, rand);
            // isPlaying = TestBattle(moveList, userPokemon, compPokemon, rand);

            isPlaying = Quit();
        } while (isPlaying);
    }

    static Pokemon ValidatePlayerChoice()
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
            if (String.Equals(pokeName, PokeNames.Bulbasaur.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return new Bulbasaur(5);
            }
            else if (String.Equals(pokeName, PokeNames.Charmander.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return new Charmander(5);
            }
            else if (String.Equals(pokeName, PokeNames.Squirtle.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return new Squirtle(5);
            }
            else
            {
                Console.WriteLine("Invalid Choice. Please choose again:");
                success = false;
            }
            

        } while (!success);

        return null;
    }

    static Pokemon ComputerSelection(Random rand)
    {
        int compNum = rand.Next(0, 99) % 3;
        switch (compNum)
        {
            case 0:
                return new Bulbasaur(5);
            case 1:
                return new Charmander(5);
            case 2:
                return new Squirtle(5);
            default:
                return null;
        }
        
    }

    static float TypeAdvantage(Pokemon p1, Pokemon p2)
    {
        float type = 1.0f;
        bool waterWins = String.Equals(p1.type, Types.WATER.ToString()) && String.Equals(p2.type, Types.FIRE.ToString());
        bool fireWins = String.Equals(p1.type, Types.FIRE.ToString()) && String.Equals(p2.type, Types.GRASS.ToString());
        bool grassWins = String.Equals(p1.type, Types.GRASS.ToString()) && String.Equals(p2.type, Types.WATER.ToString());

        if (waterWins || fireWins || grassWins)
        {
            type = 2.0f;
        }
        else if (!waterWins || !fireWins || !grassWins)
        {
            type = 0.5f;
        }
        
        return type;
    }

    static void BattleLoop(Dictionary<string, int> moves, Pokemon player, Pokemon comp, Random rand)
    {
        int playerInitiative = rand.Next(1, 21) + player.speed;
        int compInitiative = rand.Next(1, 21) + comp.speed;
        bool isPlayerFirst = playerInitiative > compInitiative ? true : false;

        bool fighting = true;

        while(fighting)
        {
            if (isPlayerFirst)
            {
                // Player's turn
                Console.WriteLine($"Player's {player.name}'s turn.");
                fighting = TurnLogic(moves, player, comp, rand);
                if (!fighting) break;

                // Computer's turn
                Console.WriteLine($"Computer's {comp.name}'s turn.");
                fighting = TurnLogic(moves, comp, player, rand);
                if (!fighting) break;
            }
            else
            {
                // Computer's turn
                Console.WriteLine($"Computer's {comp.name}'s turn.");
                fighting = TurnLogic(moves, comp, player, rand);
                if (!fighting) break;

                // Player's turn
                Console.WriteLine($"Player's {player.name}'s turn.");
                fighting = TurnLogic(moves, player, comp, rand);
                if (!fighting) break;
            }
        }
    }

    /*
    static bool TestBattle(Dictionary<string, int> moves, Pokemon player, Pokemon comp, Random rand)
    {
        bool stillFighting = true;
        for (int i = 0; i < 10; ++i)
        {
            // Player's turn
                Console.WriteLine($"Player's {player.name}'s turn.");
                stillFighting = TurnLogic(moves, player, comp, rand);
                if (!stillFighting) return false;

                // Computer's turn
                Console.WriteLine($"Computer's {comp.name}'s turn.");
                TurnLogic(moves, comp, player, rand);
                if (!stillFighting) return false;
        }
        return stillFighting;
    }
    */

    static bool TurnLogic(Dictionary<string, int> moves, Pokemon poke1, Pokemon poke2, Random rand)
    {
        Console.Write("Press any key to continue:");
        Console.ReadLine();

        poke2.TakeDamage(CalculateDamage(moves, poke1, poke2, rand));

        if (poke2.hitpoints <= 0)
        {
            Console.WriteLine($"Enemy {poke2.name} has fainted\n");
            return false;
        }

        Console.WriteLine();

        return true;
    }

    static int CalculateDamage(Dictionary<string, int> moves, Pokemon attacker, Pokemon defender, Random rand)
    {
        // Initial values;
        int power = moves[attacker.moves[0]];
        float advantage = TypeAdvantage(attacker, defender);

        int damage = ((int)(((int)((int)((((int)((2 * attacker.level)/5) + 2) * power * attacker.attack) / defender.defense) / 50) + 2) * advantage) * rand.Next(217, 256)) / 255;

        Console.WriteLine($"{damage} dealt");

        return damage;
    }

    private static bool Quit()
    {
        bool quit = true;
        Regex rg = new Regex(@"q", RegexOptions.IgnoreCase);
        do
        {
            Console.WriteLine("Type \"q\" to quit or hit any key to play again.");
            // isPlaying = String.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase) ? true : false;

            string? keepPlaying = Console.ReadLine();
            quit = rg.Match(keepPlaying).Success;
            if (quit)
            {
                return false;
            }
        } while (quit);
        return true;
    }
}