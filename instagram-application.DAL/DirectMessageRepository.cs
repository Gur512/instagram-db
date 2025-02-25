using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.DAL {
    public class DirectMessageRepository {
        private readonly InstagramDatabaseContext _context;

        public DirectMessageRepository(InstagramDatabaseContext context) {
            _context = context;
        }

        public List<DirectMessage> GetAll() {
            return _context.DirectMessages.ToList();
        }

        public void AddMessage(DirectMessage message) {
            _context.DirectMessages.Add(message);
            _context.SaveChanges();
        }

        public List<DirectMessage> GetMessagesBetweenUsers(int senderUserId, int receiverUserId) {
            Console.WriteLine($"Fetching messages between Sender: {senderUserId} and Receiver: {receiverUserId}");

            List<DirectMessage> messages = _context.DirectMessages
                .Where(dm => (dm.SenderUserId == senderUserId && dm.ReceiverUserId == receiverUserId) ||
                             (dm.SenderUserId == receiverUserId && dm.ReceiverUserId == senderUserId))
                .Include(dm => dm.SenderUser)
                .Include(dm => dm.ReceiverUser)
                .ToList();

            return messages
            //.OrderBy(dm => BitConverter.ToInt64(dm.SentAt, 0))
            .ToList();
        }
    }
}
