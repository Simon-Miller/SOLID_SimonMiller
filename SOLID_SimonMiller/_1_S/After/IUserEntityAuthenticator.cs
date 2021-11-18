namespace SOLID_SimonMiller._1_S.After
{
    // ready for dependency injection registration

    public interface IUserEntityAuthenticator
    {
        bool IsAuthenticated(UserEntity user);
        bool UserExists(string userName);
    }
}