namespace SOLID_SimonMiller._4_I.After
{
    // Command / Query segregation.

    // we could possible go further and make a generic interface for all IQuery<T> and ICommand<T>  but for demo purposes. YAGNI.  (You Ain't Gonna Need It)

    public interface IUserRepositoryQuery
    {
        IEnumerable<User> GetUsersByExpression(Func<User, bool> predicate);
    }

    public interface IUserRepositoryCommand
    {
        User InsertUser(string userName);
        void UpdateUser(User user, int? oldId);
        void DeleteUser(User user);
    }

    public record class User(string Name, int Id = 0);

    public class Repository : IUserRepositoryQuery, IUserRepositoryCommand
    {
        private List<User> _users = new List<User>();

        public IEnumerable<User> GetUsersByExpression(Func<User, bool> predicate) => this._users.Where(predicate);

        public void DeleteUser(User user) => this._users.Remove(user);

        public User InsertUser(string userName)
        {
            var newId = this._users.Max(x => x.Id) + 1;
            var newUser = new User(userName, newId);
            this._users.Add(newUser);

            return newUser;
        }

        /// <summary>
        /// lots that we could improve on.  Indeed, had we written with TDD, I'd still have broken tests.
        /// What should happen in user ID doesn't exist?
        /// That First instead of FirstOrDefault would cause an exception, so developers should see in issue.
        /// But ideally, this isn't something that should be captured by developer testing or worse, QA.
        /// </summary>
        public void UpdateUser(User user, int? oldId)
        {
            int id = oldId ?? user.Id;
            var idx = this._users.IndexOf(this._users.First(x => x.Id == id));
            this._users[idx] = user;
        }
    }
}
