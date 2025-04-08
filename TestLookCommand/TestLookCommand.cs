using NuGet.Frameworks;
using SwinAdventure;

namespace TestLookCommand
{
    public class Tests
    {
        LookCommand _look;

        private string _name;
        private string _desc;
        private Player _player;

        private string[] _id1;
        private string _name1;
        private string _desc1;
        private Item _item1;

        private string[] _idB1;
        private string _nameB1;
        private string _descriptionB1;
        private Bags _b1;


        [SetUp]
        public void Setup()
        {
            _look = new LookCommand();

            _name = "Khoi";
            _desc = "the strongest man alive";
            _player = new Player(_name, _desc);

            _id1 = new string[] { "gem", "jewelry" };
            _name1 = "a red gem";
            _desc1 = "This is a bright red gem";
            _item1 = new Item(_id1, _name1, _desc1);

            _idB1 = new string[] { "bags 1" };
            _nameB1 = "bag 1";
            _descriptionB1 = "This is a bag";
            _b1 = new Bags(_idB1, _nameB1, _descriptionB1);
        }

        [Test]
        public void TestLookAtMe()
        {
            _player.Inventory.Put(_item1);
            Assert.That(_look.Execute(_player, new string[] {"look", "at", "inventory"}), Is.EqualTo("You are Khoi, the strongest man alive. You are carrying:\n\ta red gem (gem)\n"));
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_item1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo("This is a bright red gem"));
        }

        [Test]
        public void TestLookAtUnk()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem"}), Is.EqualTo("I cannot find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_item1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" }), Is.EqualTo("This is a bright red gem"));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _b1.Inventory.Put(_item1);
            _player.Inventory.Put(_b1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bags 1" }), Is.EqualTo("This is a bright red gem"));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            _b1.Inventory.Put(_item1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bags 1" }), Is.EqualTo("I cannot find bags 1"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_b1);
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bags 1" }), Is.EqualTo("I cannot find the gem in the bag 1"));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "around", "here"}), Is.EqualTo("What do you want to look at?"));
            Assert.That(_look.Execute(_player, new string[] { "hello", "my", "name"}), Is.EqualTo("Error in look input"));
            Assert.That(_look.Execute(_player, new string[] { "look", "around" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "me", "at", "bags"}), Is.EqualTo("What do you want to look in?"));

        }
    }
}