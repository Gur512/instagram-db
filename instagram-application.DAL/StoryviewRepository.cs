using instagram_application.Models;

namespace instagram_application.DAL {
    public class StoryviewRepository {
        private readonly InstagramDatabaseContext _context;

        public StoryviewRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<Storyview> GetAll() {
            return _context.Storyviews.ToList();
        }

        public List<User> GetStoryViewers(int storyId) {
            List<User> viewers = _context.Storyviews
                                  .Where(sv => sv.StoryId == storyId)
                                  .Select(sv => sv.User)
                                  .ToList();

            return viewers;
        }

        public void RecordStoryView(int storyId, int userId) {
            bool alreadyViewed = _context.Storyviews
                                                 .Any(sv => sv.StoryId == storyId && sv.UserId == userId);

            if (!alreadyViewed) {
                Storyview storyView = new Storyview {
                    StoryId = storyId,
                    UserId = userId,
                };

                _context.Storyviews.Add(storyView);
                _context.SaveChanges();
            }
        }

    }
}
