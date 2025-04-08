namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your description: ");
            string desc = Console.ReadLine();
            Location location1 = new Location("The closet", "A small, dark closet with an odd smell");
            Path path = new Path(new string[] { "north", "n" }, "a door", "You go through a door", location1);

            Player player1 = new Player(name, desc);
            player1.Location.Paths.Add(path);

            Item sword = new Item(new string[] { "sword", "blade" }, "Rusty Sword", "A rusty sword that has been used many times");
            Item shield = new Item(new string[] { "shield", "guard" }, "Rusty Shield", "A rusty shield that has been used many times");
            Item gem = new Item(new string[] { "gem", "jewellery" }, "Red Gem", "A mysterious red gem that glows a faint light");

            player1.Inventory.Put(sword);
            player1.Inventory.Put(shield);
            location1.Inventory.Put(gem);

            Bags smallBag = new Bags(new string[] { "bag", "container" }, "Small Bag", "A small bag that has visible tears on the outside");

            player1.Inventory.Put(smallBag);

            Item coin = new Item(new string[] { "coin", "currency" }, "Bronze Coin", "A shiny bronze coin that can be used to buy other items");
            smallBag.Inventory.Put(coin);

            CommandProcessor commandProcessor = new CommandProcessor();

            while (Console.ReadLine != null)
            {
                Console.Write("Command -> ");
                string command = Console.ReadLine();
                Console.WriteLine(commandProcessor.Process(player1, command.Split(' ')));
            }

        }
    }
}