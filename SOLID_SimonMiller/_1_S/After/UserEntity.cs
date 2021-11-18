namespace SOLID_SimonMiller._1_S.After
{
    /// <summary>
    /// S in SOLID - This entity now has just a single responsibility: Of representing the information flowing around a system 
    /// purely for the holding credentials of a user than could be used to authorising, and authenticating.
    /// </summary>
    public record class UserEntity(string LoginName, string PasswordHash);

    /*
        I decided this is an excellent use case for a RECORD, as this causes equality checks to be based on property values,
        not on memory addresses of instances as is normal for reference types.
     */
}
