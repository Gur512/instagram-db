using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instagram_application.DAL;
using instagram_application.Models;

namespace instagram_application.BLL {
    public class DirectMessageServices {
        private readonly DirectMessageRepository _repository;

        public DirectMessageServices(DirectMessageRepository repository) {
            _repository = repository;
        }

        public List<DirectMessage> GetDirectMessages(int senderid, int receiverid) {
            return _repository.GetMessagesBetweenUsers(senderid, receiverid);
        }

        public List<DirectMessage> GetDirectMessagesForUser(int userId) {
            return _repository.GetAll()
                .Where(dm => dm.SenderUserId == userId || dm.ReceiverUserId == userId)
                .OrderBy(dm => dm.SentAt)
                .ToList();
        }

        public void SendMessage(int senderid, int receiverid, string text) {
            DirectMessage message = new DirectMessage {
                SenderUserId = senderid,
                ReceiverUserId = receiverid,
                TextMessage = text,
            };

            _repository.AddMessage(message);
        }
    }
}
