using SOLID_SimonMiller._1_S.After;

namespace SOLID_SimonMiller.Tests._1_S.After
{
    [TestClass]
    public class UserEntityTests
    {
        [TestMethod]
        public void Can_determine_it_exists()
        {
            // Arrange
            IUserEntityContext context = new UserEntityFakeContext();
            IUserEntityAuthenticator authenticator = new UserEntityAuthenticator(context);

            var existingUser = context.Users.First();
            var notAUser = new UserEntity("unknown", "passwordHashed");

            // Act
            var existsInDb = authenticator.UserExists(existingUser.LoginName);
            var shouldNotExistInDb = authenticator.UserExists(notAUser.LoginName);

            // Assert
            Assert.IsTrue(existsInDb);
            Assert.IsFalse(shouldNotExistInDb);
        }

        [TestMethod]
        public void Can_authenticate()
        {
            // Arrange
            IUserEntityContext context = new UserEntityFakeContext();
            IUserEntityAuthenticator authenticator = new UserEntityAuthenticator(context);

            var existingUser = context.Users.First();
            var notAUser = new UserEntity("unknown", "passwordHashed");

            // Act
            var shouldBeAuthenticated = authenticator.IsAuthenticated(existingUser);
            var shouldNotBeAuthenticated = authenticator.IsAuthenticated(notAUser);

            // Assert
            Assert.IsTrue(shouldBeAuthenticated);
            Assert.IsFalse(shouldNotBeAuthenticated);
        }
    }

    internal class UserEntityFakeContext : IUserEntityContext
    {
        public ICollection<UserEntity> Users { get; private init; } = new List<UserEntity>
        {
            new UserEntity("a@b.com", "hashedPasswordHere"),
            new UserEntity("b@there.com", "35c2ebff598d117b8a32909b0ed77e3a") // RIPEMD-128 Hash
        };
    }
}
