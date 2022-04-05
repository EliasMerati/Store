using System.Collections.Generic;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUsersDto
    {
        public List<GetUserDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
