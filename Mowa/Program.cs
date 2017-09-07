namespace Mowa
{
    using System;
    using System.Threading.Tasks;

    using Discord;
    using Discord.WebSocket;

    public class Program
    {
        private DiscordSocketClient client;

        public static void Main(string[] args) 
            => new Program().MainAsync().GetAwaiter().GetResult();


        public async Task MainAsync()
        {
            this.client = new DiscordSocketClient();
            this.client.Log += this.Log;

            var token = 
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }
        
    }
}
