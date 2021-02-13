using DotNetLab2021Feb.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Datas
{
    public interface IUserData
    {
        Task<IEnumerable<User>> GetUsers();
    }
}