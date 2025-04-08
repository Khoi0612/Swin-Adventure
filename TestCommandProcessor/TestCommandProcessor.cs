using SwinAdventure;

namespace TestCommandProcessor
{
    public class Tests
    {
        private Player _player;
        private Location _source;
        private Location _destination;
        private Item _item1;
        private Item _item2;
        private Item _item3;
        private Item _item4;
        private Bags _bag;
        private SwinAdventure.Path _path;
        private CommandProcessor _command;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Khoi", "the strong");
            _source = new Location("Hallway", "a well lit hallway");
            _destination = new Location("School", "a terible place");
            _player.Location = _source;
            _item1 = new Item(new string[] { "sword" }, "Excalibur", "A legendery sword used by King Authur");
            _item2 = new Item(new string[] { "cane" }, "Aqua Magia", "A powerful cane that induced high concentration of mana");
            _item3 = new Item(new string[] { "calculator" }, "Casio", "A useful tool for calculating simple mathematics");
            _item4 = new Item(new string[] { "coin" }, "Gold Coin", "A valuable gold coin");
            _bag = new Bags(new string[] { "bag" }, "Small bag", "A small bag");
            _player.Inventory.Put(_item1);
            _player.Inventory.Put(_item2);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_item4);
            _source.Inventory.Put(_item3);
            _path = new SwinAdventure.Path(new string[] { "north" }, "A door", "You crawl through a door", _destination);
            _source.Paths.Add(_path);
            _command = new CommandProcessor();
        }

        [Test]
        public void TestLook()
        {
            Assert.That(_command.Process(_player, new string[] { "look" }), Is.EqualTo("You are in a Hallway\na well lit hallway\nIn this room you can see:\n\tCasio (calculator)\n"));
            Assert.That(_command.Process(_player, new string[] { "look", "at", "me" }), Is.EqualTo("You are Khoi, the strong. You are carrying:\n\tExcalibur (sword)\n\tAqua Magia (cane)\n\tSmall bag (bag)\n"));
            Assert.That(_command.Process(_player, new string[] { "look", "at", "sword" }), Is.EqualTo("A legendery sword used by King Authur"));
            Assert.That(_command.Process(_player, new string[] { "look", "at", "coin", "in", "bag" }), Is.EqualTo("A valuable gold coin"));
        }

        [Test]
        public void TestMove()
        {
            Assert.That(_command.Process(_player, new string[] { "move", "north" }), Is.EqualTo("You crawl through a door"));
            Assert.That(_command.Process(_player, new string[] { "look" }), Is.EqualTo("You are in a School\na terible place"));
            _command.Process(_player, new string[] { "move", "north" });
            Assert.That(_player.Location, Is.EqualTo(_destination));
        }

        [Test]
        public void TestInvalidCommand()
        {
            Assert.That(_command.Process(_player, new string[] { "hi", "everyone" }), Is.EqualTo("I don't understand hi everyone"));
        }
    }
}