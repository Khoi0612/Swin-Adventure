using SwinAdventure;
using System.Xml.Linq;

namespace TestBags
{
    public class Tests
    {
        private string[] _idB1;
        private string _nameB1;
        private string _descriptionB1;
        private Bags _b1;

        private string[] _idB2;
        private string _nameB2;
        private string _descriptionB2;
        private Bags _b2;

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
            _idB1 = new string[] { "bags 1" };
            _nameB1 = "bag 1";
            _descriptionB1 = "This is a bag";
            _b1 = new Bags(_idB1, _nameB1, _descriptionB1);

            _idB2 = new string[] { "bags 2" };
            _nameB2 = "bag 2";
            _descriptionB2 = "This is another bag";
            _b2 = new Bags(_idB2, _nameB2, _descriptionB2);

            _id1 = new string[] { "sword", "blade" };
            _name1 = "a bronze sword";
            _desc1 = "This is a sword casted from bronze, look rusty but can be very powerfull";
            _item1 = new Item(_id1, _name1, _desc1);

            _id2 = new string[] { "shovel", "spade" };
            _name2 = "a shovel";
            _desc2 = "This is a shovel casted from iron, can be very usefull";
            _item2 = new Item(_id2, _name2, _desc2);

            _b1.Inventory.Put(_item1);
            _b2.Inventory.Put(_item2);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.That(_b1.Locate("sword"), Is.EqualTo(_item1));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(_b1.Locate("bags 1"), Is.EqualTo(_b1));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(_b1.Locate("gem"), Is.EqualTo(null));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.That(_b1.FullDescription, Is.EqualTo("In the bag 1 you can see:\n\ta bronze sword (sword)\n"));
        }

        [Test]
        public void TestBagInBag()
        {
            _b1.Inventory.Put(_b2);
            Assert.That(_b1.Locate("bags 2"), Is.EqualTo(_b2));
            Assert.That(_b1.Locate("sword"), Is.EqualTo(_item1));
            Assert.That(_b1.Locate("shovel"), Is.EqualTo(null));
        }
    }
}