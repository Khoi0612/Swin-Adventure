using SwinAdventure;

namespace TestMoveCommand
{
    public class Tests
    {
        private Player _player;
        private Location _source;
        private Location _dest;
        private SwinAdventure.Path _path;
        private MoveCommand _command;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Khoi", "The strong");
            _source = new Location("Hallway", "a well lit hallway");
            _dest = new Location("Small Closet", "a small, dark closet with an odd smell");
            _path = new SwinAdventure.Path(new string[] { "north", "n" }, "a door", "You go through a door", _dest);
            _player.Location = _source;
            _source.Paths.Add(_path);
            _command = new MoveCommand();
        }

        [Test]
        public void TestLeaveLocation()
        {
            Assert.That(_command.Execute(_player, new string[] { "move", "north" }), Is.EqualTo("You go through a door"));
            _command.Execute(_player, new string[] { "move", "north" });
            Assert.That(_player.Location, Is.EqualTo(_dest));
        }

        [Test]
        public void TestNotLeaveLocation()
        {
            Assert.That(_command.Execute(_player, new string[] { "move", "where" }), Is.EqualTo("There are no path in this direction"));
            _command.Execute(_player, new string[] { "move", "where" });
            Assert.That(_player.Location, Is.EqualTo(_source));
        }
    }
}