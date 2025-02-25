using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;

namespace instagram_application.DAL {
    public class FollowRepository {
        private readonly InstagramDatabaseContext _context;

        public FollowRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Follow> GetAll() {
            return _context.Follows.ToList();
        }

        public List<User> GetFollowers(int userId) {
            // Fetch and return the list of followers for the given user
            return _context.Follows
                .Where(f => f.FollowingUserId == userId)
                .Select(f => f.FollowerUser)
                .ToList();
        }

        public List<User> GetFollowing(int userId) {
            // Fetch and return the list of following for the given user
            return _context.Follows
                .Where(f => f.FollowerUserId == userId)
                .Select(f => f.FollowingUser)
                .ToList();
        }                                                                                                                                  
    }
}
