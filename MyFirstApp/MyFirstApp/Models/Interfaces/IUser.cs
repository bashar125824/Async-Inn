using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyFirstApp.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Interfaces
{
    public class IUser
    {
        public interface IUserService
        {
            public Task<UserDTO> Register(RegisterDTO data, ModelStateDictionary modelState);
            public Task<UserDTO> Authenticate(string username, string password);
        }
    }
}
