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
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
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

        public async Task UpdateUserRating(string userId, Type type)
        {
            //changes change from one rating to the next, i
            //specific implementation of rating is in the method below
            var user = GetById(userId);
            user.Rating = CalcualteUserRating(type, user.Rating);
            await _context.SaveChangesAsync();
        }

        private int CalcualteUserRating(Type type, int userRating)
        {
            var inc = 0;
            if (type == typeof(Post))
            {
                inc = 1;
            }
            else if(type == typeof(PostReply))
            {
                inc = 3;
            }

            return userRating + inc;
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            await _userManager.UpdateAsync(user);
        }
    }
}
