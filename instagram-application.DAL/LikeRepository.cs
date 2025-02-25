using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;

namespace instagram_application.DAL {
    public class LikeRepository {
        private readonly InstagramDatabaseContext _context;

        public LikeRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Like> GetAll() {
            return _context.Likes.ToList();
        }
    }
}
