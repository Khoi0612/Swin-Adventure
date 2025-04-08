using SwinAdventure;

namespace TestPlayer
{
    public class Tests
    {
        private string _name;
        private string _desc;
        private Player _player;

        private string[] _id1;
        private string _name1;
        private string _desc1;
        private Item _item1;

        private string[] _id2;
        private string _name2;
        private string _desc2;
        private Item _item2;

        [SetUp]
        public void Setup()
        {
            _name = "Khoi";
            _desc = "the strongest man alive";
            _player = new Player(_name, _desc);

            _id1 = new string[] { "sword", "blade" };
            _name1 = "a bronze sword";
            _desc1 = "This is a sword casted from bronze, look rusty but can be very powerfull";
            _item1 = new Item(_id1, _name1, _desc1);

            _id2 = new string[] { "shovel", "spade" };
            _name2 = "a shovel";
            _desc2 = "This is a shovel casted from iron, can be very usefull";
            _item2 = new Item(_id2, _name2, _desc2);

            _player.Inventory.Put(_item1);
            _player.Inventory.Put(_item2);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems() 
        {
            Assert.That(_player.Locate("sword"), Is.EqualTo(_item1));
            Assert.That(_player.Locate("shovel"), Is.EqualTo(_item2));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(_player.Locate("me"), Is.EqualTo(_player));
            Assert.That(_player.Locate("inventory"), Is.EqualTo(_player));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(_player.Locate("gem"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(_player.FullDescription, Is.EqualTo("You are Khoi, the strongest man alive. You are carrying:\n\ta bronze sword (sword)\n\ta shovel (shovel)\n"));
        }
    }
}