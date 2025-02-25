using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class LikeServices {
        private readonly LikeRepository _likeRepository;

        public LikeServices(LikeRepository likeRepository) {
            _likeRepository = likeRepository;
        }

        public List<Like> GetLikes() {
            return _likeRepository.GetAll();
        }

    }
}
