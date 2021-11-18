namespace SOLID_SimonMiller._1_S.After
{
    // ready for dependency injection registration

    /// <summary>
    /// I believe interfaces can have inline documentation. the I in SOLID talks about segregating responsibilities in an interface.
    /// So this interface is purely about authenticity of a user or user's credentials.
    /// You might argue the existance could be moved to its own interface.
    /// </summary>
    public interface IUserEntityAuthenticator
    {
        /// <summary>
        /// Checks that a given user's login name and hashed password matched in the database.
        /// This should be performed before checking if an authenticated user is in fact authorised to log in.
        /// </summary>
        bool IsAuthenticated(UserEntity user);

        /// <summary>
        /// If a login name exists in the repository, then it is deemed that the user exists.
        /// This has nothing to do with the user being locked out or disabled.
        /// </summary>
        bool UserExists(string userName);
    }
}