namespace Store.Domain.Entities.Users
{
    public class UserRoles
    {
        public long Id { get; set; }

        public virtual User User { get; set; }
        public long UserId { get; set; }

        public Role Role { get; set; }
        public long RoleId { get; set; }
    }
}
