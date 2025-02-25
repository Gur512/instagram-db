using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.DAL {
    public class UserRepository {
        private readonly InstagramDatabaseContext _context;

        public UserRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<User> GetAll() {
            return _context.Users.ToList();
        }

        public User GetUserbyid(int id) {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<Post> GetPostsWithImages(int userId) {
            return _context.Posts
                           .Where(p => p.UserId == userId)
                           .Include(p => p.Images)  
                           .ToList();
        }

        public List<Story> GetStories(int userId) {
            return _context.Stories.Where(s => s.UserId == userId).ToList() ;
        }

        public List<Comment> GetComments(string postId) {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public int GetUserIdByUsername(string username) {
            User user = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null) {
                return user.UserId;  
            }

            return 0;  
        }
    }
}
