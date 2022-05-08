using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyFirstApp.Models.API;
using MyFirstApp.Models.Interfaces;
using MyFirstApp.DTO;



namespace MyFirstApp.Models.Services
{
    public class IdentityUserService : IUser
    {
        // Connect to Identity’s “User Manager” to do the database work
        private UserManager<AppUser> _userManager;
        // Manage AppUser 
        public IdentityUserService(UserManager<AppUser> manager)
        {
            _userManager = manager;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            // Use FindByNameAsync
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    UserDTO userDto = new UserDTO
                    {
                        Id = user.Id,
                        Username = user.UserName,
                    };
                    return userDto;
                }
               
            }
            return null;
        }
      
        public async Task<UserDTO> Register(RegisterDTO data, ModelStateDictionary modelState)
        {
            var user = new AppUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
           
            if (result.Succeeded)
            {
                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    
                    error.Code.Contains("Password") ? /* key name will be -> */nameof(data.Password) :
                    error.Code.Contains("Email") ? /* key name will be -> */nameof(data.Email) :
                    error.Code.Contains("UserName") ? /* key name will be -> */nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }
    }
}
