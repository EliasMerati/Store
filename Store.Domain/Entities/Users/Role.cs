using System.Collections.Generic;

namespace Store.Domain.Entities.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
