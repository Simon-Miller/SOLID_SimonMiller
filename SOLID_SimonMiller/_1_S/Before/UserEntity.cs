using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_SimonMiller._1_S.Before
{
    /// <summary>
    /// A user entity would contain information from a repository (database) and could contain a login name (email?) and password (hashed mby your favourite argorithm)
    /// With 'smart' entities, you often find code on entities allowing them to do things that perhaps should be placed somewhere else...
    /// </summary>
    public record class UserEntity(string LoginName, string PasswordHash)
    {
        public bool UserExists() => UsersFakeContext.Users.Any(x => x.LoginName.Equals(this.LoginName));

        /// <summary>
        /// As this is a RECORD, it should compare based on values, not on memory equality.
        /// See unit tests!
        /// </summary>
        public bool IsAuthenticated() => UsersFakeContext.Users.Any(contextUser => contextUser.Equals(this));
    }
    
    public static class UsersFakeContext
    {
        public static ICollection<UserEntity> Users { get; set; } = new List<UserEntity> 
        {
            new UserEntity("a@b.com", "hashedPasswordHere"),
            new UserEntity("b@there.com", "35c2ebff598d117b8a32909b0ed77e3a") // RIPEMD-128 Hash
        };
    }

}
