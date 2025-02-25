using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.Models;

namespace instagram_application.DAL {
    public class ImageRepository {
        private readonly InstagramDatabaseContext _context;

        public ImageRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Image> GetAll() {
            return _context.Images.ToList();
        }
    }
}
