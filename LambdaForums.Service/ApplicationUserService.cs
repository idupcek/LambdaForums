using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            return _userManager.Users.FirstOrDefault(
                user => user.Id == id);
        }

        public Task IncrementRating(string id, Type type)
        {
            throw new NotImplementedException();
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            await _userManager.UpdateAsync(user);
        }
    }
}
