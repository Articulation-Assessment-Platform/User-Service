using Azure.Messaging.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace User_Service.Messaging
{
    public class UserDeletionMessaging
    {
        private readonly string _connectionString = "Endpoint=sb://bus-articulation.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=trv17NvCsHB8Y+YFDhccpYbW1xxo3x44M+ASbGkhr1A="; 
        private readonly string _topicName = "userdeletiontopic"; 

        public UserDeletionMessaging()
        {
        }

        public async Task SendUserDeletionMessageAsync(int userId)
        {
            await using var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(_topicName);

            try
            {
                var messageBody = $"User {userId} deleted their account.";
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

                await sender.SendMessageAsync(message);
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
    }
}
