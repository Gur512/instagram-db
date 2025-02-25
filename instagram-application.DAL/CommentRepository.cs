using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;

namespace instagram_application.DAL {
    public class CommentRepository {
        private readonly InstagramDatabaseContext _context;

        public CommentRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Comment> GetAll(string postId) {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public void AddComment(Comment comment) {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetComments(string postId) {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }
    }
}
