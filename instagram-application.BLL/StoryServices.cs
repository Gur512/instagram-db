using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.BLL {
    public class StoryServices {
        private readonly StoryRepository _storyRepository;

        public StoryServices(StoryRepository storyRepository) {
            _storyRepository = storyRepository;
        }

        public List<Story> GetStories() {
            return _storyRepository.GetAll();
        }
    }
}
