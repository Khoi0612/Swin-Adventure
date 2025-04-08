using SwinAdventure;

namespace TestLocation
{
    public class Tests
    {
        private Player _player;
        private Location _location;
        private LookCommand _command;
        private Item _item1;
        private Item _item2;
        private Item _item3;
        
        [SetUp]
        public void Setup()
        {
            _player = new Player("Khoi", "The dumb");
            _location = new Location("Small Closet", "A small dark closet, with an odd smell.");
            _command = new LookCommand();
            _item1 = new Item(new string[] { "shovel", "spade" }, "Rusty Shovel", "A rustry shovel that has been used many times.");
            _item2 = new Item(new string[] { "gem", "jewellery" }, "Red Gem", "A bright red gem that emmits curious light.");
            _item3 = new Item(new string[] { "sword", "blade" }, "Rusty Gem", "A rustry sword that has been used many times.");

            _location.Inventory.Put(_item1);
            _location.Inventory.Put(_item2);
            _player.Inventory.Put(_item3);
            _player.Location = _location;
        }

        [Test]
        public void TestLocationIdentifyThemself()
        {
            Assert.That(_location.Locate("room"), Is.EqualTo(_location));
        }

        [Test]
        public void TestLocationLocateItems()
        {
            Assert.That(_location.Locate("shovel"), Is.EqualTo(_item1));
            Assert.That(_location.Locate("gem"), Is.EqualTo(_item2));
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            Assert.That(_player.Locate("shovel"), Is.EqualTo(_item1));
            Assert.That(_player.Locate("gem"), Is.EqualTo(_item2));
        }

        [Test]
        public void TestPlayerLookAtLocation()
        {
            Assert.That(_command.Execute(_player, new string[] {"look"}), Is.EqualTo("You are in a Small Closet\nA small dark closet, with an odd smell.\nIn this room you can see:\n\tRusty Shovel (shovel)\n\tRed Gem (gem)\n"));
        }
    }
}