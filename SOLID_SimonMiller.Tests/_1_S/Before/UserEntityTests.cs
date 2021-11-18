using SOLID_SimonMiller._1_S.Before;

namespace SOLID_SimonMiller.Tests._1_S.Before
{
    [TestClass]
    public class UserEntityTests
    {
        [TestMethod]
        public void Can_determine_it_exists()
        {
            // Arrange
            var existingUser = UsersFakeContext.Users.First();
            var notAUser = new UserEntity("unknown", "passwordHashed");

            // purely to demonstrate that a RECORD compares values, NOT memory addresses.
            var copyOfExistingUser = new UserEntity("a@b.com", "hashedPasswordHere");

            // Act
            var existsInDb = existingUser.UserExists();
            var existsInDbToo = copyOfExistingUser.UserExists();
            var shouldNotExistInDb = notAUser.UserExists();

            // Assert
            Assert.IsTrue(existsInDb);
            Assert.IsTrue(existsInDbToo);
            Assert.IsFalse(shouldNotExistInDb);
        }

        [TestMethod]
        public void Can_authenticate()
        {
            // Arrange
            var existingUser = UsersFakeContext.Users.First();
            var notAUser = new UserEntity("unknown", "passwordHashed");

            // Act
            var shouldBeAuthenticated = existingUser.IsAuthenticated();
            var shouldNotBeAuthenticated = notAUser.IsAuthenticated();

            // Assert
            Assert.IsTrue(shouldBeAuthenticated);
            Assert.IsFalse(shouldNotBeAuthenticated);
        }
    }
}
