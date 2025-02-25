using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;

namespace instagram_application.DAL {
    public class StoryRepository {
        private readonly InstagramDatabaseContext _context;

        public StoryRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Story> GetAll() {
            return _context.Stories.ToList();
        }
    }
}
