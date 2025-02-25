using instagram_application.DAL;
using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.BLL {
    public class UserServices {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository) {
            _userRepository = userRepository;
        }
                                                                                                                                                                                                                                                            
        public List<User> GetUsers() {
            return _userRepository.GetAll();
        }

        public User GetUserById(int userid) {
            return _userRepository.GetUserbyid(userid);
        }

        public List<Post> GetImages(int userid) {
            return _userRepository.GetPostsWithImages(userid);
        }

        public List<Story> GetStories(int userid) {
            return _userRepository.GetStories(userid);
        }
        public List<Comment> GetComments(string postId) {
            return _userRepository.GetComments(postId);
        }

        public int GetUserIdByUsername(string username) {
            return _userRepository.GetUserIdByUsername(username);
        }
    }
}
