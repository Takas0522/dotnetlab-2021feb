using DotNetLab2021Feb.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Domains
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}