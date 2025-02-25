using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.BLL {
    public class PostServices {
        private readonly InstagramDatabaseContext _context;
        private readonly PostRepository _postRepository;
        private readonly UserRepository _userRepository;

        public PostServices( InstagramDatabaseContext context,PostRepository postRepository, UserRepository userRepository) {
            _context = context;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public List<Post> GetPosts() {
            return _postRepository.GetAll();
        }

        //public void AddLike(string postId, int userId) {
        //    Like like = new Like {
        //        PostId = postId,
        //        UserId = userId
        //    };

        //    _postRepository.AddLike(like);
        //}        
        public List<Like> GetLikes(string postId) {
            return _postRepository.GetLikesByPostId(postId);
        }

        public Post GetPostById(string postId) {
            return _postRepository.GetPostById(postId);
        }

        public List<Post> GetPosts(int userid) {
            return _postRepository.GetPosts(userid);
        }

        public void AddLikeToPost(string postId, int userId) {
            Post post = _postRepository.GetPostById(postId);
            if (post != null) {
                bool alreadyLiked = false;
                foreach (Like like in post.Likes) {
                    if (like.UserId == userId) {
                        alreadyLiked = true;
                    }
                }
                // I have to us this specific exception becuase my application break at this point
                // and ask me to use this....
                if (!alreadyLiked) {
                    post.Likes.Add(new Like { UserId = userId, PostId = postId });
                    try {
                        _context.SaveChanges();
                    }
                    catch (DbUpdateException ex) {
                        // Log the main exception message
                        Console.WriteLine("Error: " + ex.Message);

                        if (ex.InnerException != null) {
                            Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                        }
                    }
                }
            }
        }

    }
}
