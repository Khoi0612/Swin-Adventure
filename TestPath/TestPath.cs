using SwinAdventure;

namespace TestPath
{
    public class Tests
    {
        private Player _player;
        private Location _source;
        private Location _dest;
        private SwinAdventure.Path _path;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Khoi", "The strong");
            _source = new Location("Hallway", "a well lit hallway");
            _dest = new Location("Small Closet", "a small, dark closet with an odd smell");
            _path = new SwinAdventure.Path(new string[] { "north", "n" }, "a door", "You go through a door", _dest);
            _player.Location.Paths.Add(_path);
        }

        [Test]
        public void TestMove()
        {
            _path.Move(_player);
            Assert.That(_player.Location, Is.EqualTo(_dest));
        }


        [Test]
        public void TestIdentifyPathFromLocation()
        {
            Assert.That(_player.Location.LocatePath("north"), Is.EqualTo(_path));
            Assert.That(_player.Location.LocatePath("n"), Is.EqualTo(_path));
        }
    }
}