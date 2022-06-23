using System.Threading;
using Discord;
using Discord.Webhook;
using static WebhookSpammer.Config.configuration;
using static WebhookSpammer.Config.NONELoggs;

namespace WebhookSpammer.functions.discord
{
    public class WebhookSpammer
    {
        public static void SpamMessage()
        {
            new Thread(() =>
            {
                for (int i = 0; i < HowManySend; i++)
                {
                    DiscordWebhook hook = new DiscordWebhook();
                    hook.Url = WebhookURL;
                    DiscordMessage message = new DiscordMessage();
                    message.Content = Content;
                    message.TTS = TextToSpeek;
                    message.Username = Username;
                    message.AvatarUrl = UserImage;
                    hook.Send(message);
                    WriteState("Sended a Message!");
                }
                
            }).Start();
        }
    }
}