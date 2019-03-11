namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class User
    {
        public User() { }

        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
    }
}
