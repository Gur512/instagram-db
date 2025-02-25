using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class CommentServices {
        private readonly CommentRepository _commentRepository;

        public CommentServices(CommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetCommentsByPostId(string postId) {
            return _commentRepository.GetAll(postId);
        }

        public void AddComment(Comment comment) {
            _commentRepository.AddComment(comment);
        }

        public List<Comment> GetComments(string postid) {
            return _commentRepository.GetComments(postid);
        }
    }
}
