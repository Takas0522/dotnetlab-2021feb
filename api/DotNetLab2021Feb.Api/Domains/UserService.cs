using DotNetLab2021Feb.Api.Datas;
using DotNetLab2021Feb.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Domains
{
    public class UserService : IUserService
    {
        private readonly IUserData _data;
        public UserService(
            IUserData data
        )
        {
            _data = data;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _data.GetUsers();
        }
    }
}
