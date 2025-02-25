using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class ImageServices {
        private readonly ImageRepository _imageRepository;

        public ImageServices(ImageRepository imageRepository) {
            _imageRepository = imageRepository;
        }

        public List<Image> GetImages() {
            return _imageRepository.GetAll();
        }
    }
}
