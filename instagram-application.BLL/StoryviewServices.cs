using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class StoryviewServices {
        private readonly StoryviewRepository _storyviewRepository;

        public StoryviewServices(StoryviewRepository storyRepository) {
            _storyviewRepository = storyRepository;
        }

        public List<Storyview> GetUsers() {
            return _storyviewRepository.GetAll();
        }

        public List<User> GetStoryViewers(int storyId) {
            return _storyviewRepository.GetStoryViewers(storyId);
        }

        public void RecordStoryView(int storyid, int userid) {
             _storyviewRepository.RecordStoryView(storyid, userid);
        }
    }
}
