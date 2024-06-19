using Azure.Messaging.ServiceBus;
using System.Text;
using System.Text.Json;
using User_Service.DTO;

namespace User_Service.Messaging
{
    public class UserRegisterMessaging
    {
        private readonly string _connectionString = "Endpoint=sb://bus-articulation.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=trv17NvCsHB8Y+YFDhccpYbW1xxo3x44M+ASbGkhr1A=";
        private readonly string _topicName = "userregistertopic";

        public UserRegisterMessaging()
        {
        }

        public async Task SendUserRegister(int userId, string email, string password, string role)
        {
            await using var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(_topicName);

            try
            {
                var message = new UserRegistrationBody
                {
                    Id = userId,
                    Email = email,
                    Password = password,
                    Role = role
                };

                string messageBody = JsonSerializer.Serialize(message);
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(messageBody);

                // Send the message
                await sender.SendMessageAsync(serviceBusMessage);
            }
            finally
            {
                await sender.CloseAsync();
            }
        }
    }
}
