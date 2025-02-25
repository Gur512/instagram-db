using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.DAL {
    public class PostRepository {
        private readonly InstagramDatabaseContext _context;

        public PostRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Post> GetAll() {
            return _context.Posts.ToList();
        }

        public List<Like> GetLikesByPostId(string postId) {
            return _context.Likes.Where(l => l.PostId == postId).ToList();
        }

        public Post GetPostById(string postId) {
            return _context.Posts
                           .Include(p => p.Likes)  // Make sure to include likes with the post
                           .FirstOrDefault(p => p.PostId == postId);
        }

        public List<Post> GetPosts(int userId) {
            return _context.Posts.Where(p => p.UserId == userId).ToList();
        }
    }
}
