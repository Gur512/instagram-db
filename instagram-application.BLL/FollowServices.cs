using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class FollowServices {
        private readonly FollowRepository _followRepository;

        public FollowServices(FollowRepository followRepository) {
            _followRepository = followRepository;
        }

        public List<User> GetFollowers(int userid) {
            return _followRepository.GetFollowers(userid);
        }

        public List<User> GetFollowing(int userid) {
            return _followRepository.GetFollowing(userid);
        }

    }
}
