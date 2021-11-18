namespace SOLID_SimonMiller._1_S.After
{
    /// <summary>
    /// Acts as a service providing the ability to check if a given username exists in the repository,
    /// and also to check the user authenticates with the given username and password hash.
    /// </summary>
    public class UserEntityAuthenticator : IUserEntityAuthenticator
    {
        public UserEntityAuthenticator(IUserEntityContext context)
        {
            this.context = context;
        }

        readonly IUserEntityContext context;

        /// <summary>
        /// If a login name exists in the repository, then it is deemed that the user exists.
        /// This has nothing to do with the user being locked out or disabled.
        /// </summary>
        public bool UserExists(string userName) => context.Users.Any(x => x.LoginName == userName);

        /// <summary>
        /// Checks that a given user's login name and hashed password matched in the database.
        /// This should be performed before checking if an authenticated user is in fact authorised to log in.
        /// </summary>
        public bool IsAuthenticated(UserEntity user) => context.Users.Any(contextUser => user == contextUser);
    }
}
