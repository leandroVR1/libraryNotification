using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.Webhooks;

namespace ExceptionNotification
{
    public class SlackExceptionNotifier
    {
        private readonly string _webhookUrl;

        public SlackExceptionNotifier(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task NotifyAsync(Exception exception, string additionalInfo = null)
        {
            var client = new SlackClient(_webhookUrl);

            var message = new SlackMessage
            {
                Text = $"Se ha producido una excepción: {exception.Message}",
                Attachments = new List<SlackAttachment>
                {
                    new SlackAttachment
                    {
                        Color = "danger",
                        Title = exception.GetType().Name,
                        Text = additionalInfo ?? "No se proporcionó información adicional",
                        Footer = "Timestamp",
                        Timestamp = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()

                    }
                }
            };

            await client.PostAsync(message);
        }
    }
}
