namespace PokemonApp
{
    abstract class Pokemon
    {
        //Fields

        //Fields are private by default. This field was explicitly declared private.
        public string name { get; set; }
        public string type { get; set; }
        public int dexNumber {get; set;}
        public int level { get; set; }
        public int hitpoints { get; set; }
        public int attack { get; set; }      
        public int defense { get; set; }
        public int speed { get; set; }
        public string[] moves { get; set; }

        //Constructors - Special methods used to instantiate or "create" an instance of a class.
        //You can have as many constructors as you need provided the signatures are different. 
        //This is a common example of method overloading. 

        //Methods

        // This method is an instance method. It can be called by an object of class Pokemon using dot-notation.
        public void IsPokemon()
        {
            Console.WriteLine($"My name is {name}.");
            Console.WriteLine($"I'm a {type} type pokemon.");
            Console.WriteLine($"Hit Points: {hitpoints}");
            Console.WriteLine($"Attack: {attack}");
            Console.WriteLine($"Defense: {defense}");
            Console.WriteLine("I know:");

            foreach (string move in moves)
            {
                Console.WriteLine($"\t{move}");
            }
        }

        /* 
        //This method is static. It can be called with dot-notation using the name of the class itself.  
        public static void Sound()
        {
            Console.WriteLine("*pokemon noises*");
        }

        //Overriding
        public override string ToString()
        {
            return $"My name is {name}, number {dexNumber}. I'm a {type} type pokemon.";
        }
        */      
        
        public void TakeDamage(int damage)
        {
            hitpoints -= damage;
            if (hitpoints < 0) hitpoints = 0;

            Console.WriteLine($"The enemy's {name} has {hitpoints} left");
        }
    }
}