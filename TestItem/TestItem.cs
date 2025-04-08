using SwinAdventure;

namespace TestItem
{
    public class Tests
    {
        private string[] _id;
        private string _name;
        private string _desc;
        private Item _item;
        
        [SetUp]
        public void Setup()
        {
            _id = new string[] {"sword", "blade"};
            _name = "a bronze sword";
            _desc = "This is a sword casted from bronze, look rusty but can be very powerfull";
            _item = new Item(_id, _name, _desc);
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_item.AreYou("sword"));
        }

        [Test]
        public void TestShortDescription() 
        {
            Assert.That(_item.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test]
        public void TestFullDesciption()
        {
            Assert.That(_item.FullDescription, Is.EqualTo("This is a sword casted from bronze, look rusty but can be very powerfull"));
        }
    }
}