using SwinAdventure;

namespace TestIdentifiableObject
{
    public class Tests
    {
        private IdentifiableObject _testableObject;
        private IdentifiableObject _testableObject2;
        private string[] _testableString;
        private string[] _testableString2;

        [SetUp]
        public void Setup()
        {
            _testableString = new string[] { "fred", "bob" };
            _testableObject = new IdentifiableObject(_testableString);
            _testableString2 = new string[] { };
            _testableObject2 = new IdentifiableObject(_testableString2);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testableObject.AreYou("fred"));
            Assert.IsTrue(_testableObject.AreYou("bob"));
        }

        [Test]
        public void TestNotareYou()
        {
            Assert.IsFalse(_testableObject.AreYou("wilma"));
            Assert.IsFalse(_testableObject.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testableObject.AreYou("FRED"));
            Assert.IsTrue(_testableObject.AreYou("bOb"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.That(_testableObject.FirstId, Is.EqualTo("fred"));
        }

        [Test]
        public void TestFirstIdWithNoId()
        {
            Assert.That(_testableObject2.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddId()
        {
            _testableObject.AddIdentifier("Wilma");
            Assert.IsTrue(_testableObject.AreYou("fred"));
            Assert.IsTrue(_testableObject.AreYou("bob"));
            Assert.IsTrue(_testableObject.AreYou("wilma"));
        }
    }
}