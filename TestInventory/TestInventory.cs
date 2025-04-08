using SwinAdventure;

namespace TestInventory
{
    public class Tests
    {
        private Inventory _inventory;

        private string[] _id1;
        private string _name1;
        private string _desc1;
        private Item _item1;

        private string[] _id2;
        private string _name2;
        private string _desc2;
        private Item _item2;

        private string[] _id3;
        private string _name3;
        private string _desc3;
        private Item _item3;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();

            _id1 = new string[] { "sword", "blade" };
            _name1 = "a bronze sword";
            _desc1 = "This is a sword casted from bronze, look rusty but can be very powerfull";
            _item1 = new Item(_id1, _name1, _desc1);

            _id2 = new string[] { "shovel", "spade" };
            _name2 = "a shovel";
            _desc2 = "This is a shovel casted from iron, can be very usefull";
            _item2 = new Item(_id2, _name2, _desc2);

            _id3 = new string[] { "gem", "jewellery" };
            _name3 = "a gem";
            _desc3 = "This is a mysterious gem that can grant user amazing abilities";
            _item3 = new Item(_id3, _name3, _desc3);

            _inventory.Put(_item1);
            _inventory.Put(_item2);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.HasItem("gem"));
        }

        [Test]
        public void TestFetchItem() 
        {
            Assert.That(_inventory.Fetch("sword"), Is.EqualTo(_item1));
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.That(_inventory.Take("sword"), Is.EqualTo(_item1));
            Assert.IsFalse(_inventory.HasItem("sword"));
        }

        [Test]
        public void TestItemList()
        {
            Assert.That(_inventory.ItemList, Is.EqualTo("\ta bronze sword (sword)\n\ta shovel (shovel)\n"));
        }
    }
}