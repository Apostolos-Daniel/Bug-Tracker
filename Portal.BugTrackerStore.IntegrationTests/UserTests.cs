using LiteDB;
using NUnit.Framework;

namespace Tests
{
    public class UserTests
    {
        private static readonly LiteDatabase db = new LiteDatabase("BugTracker");
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //var userToFind 
        }
    }
}