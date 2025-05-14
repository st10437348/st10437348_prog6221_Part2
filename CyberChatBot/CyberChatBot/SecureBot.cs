using System.Media;
using System.Runtime.InteropServices;

namespace CyberChatBot
{
    public class SecureBot : SecureBotBase
    {
        public override void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"
+------------------------------------------------------------+
|                                                            |
|    _____                            ____        _          |
|   / ____|                          |  _ \      | |         |
|  | (___   ___  ___ _   _ _ __ ___  | |_) | ___ | |_        |
|   \___ \ / _ \/ __| | | | '__/ _ \ |  _ < / _ \| __|       |
|   ____) |  __/ (__| |_| | | |  __/ | |_) | (_) | |_        |
|  |_____/ \___|\___|\__,_|_|  \___| |____/ \___/ \__|       |
|                                                            |
+------------------------------------------------------------+
");
            Console.ResetColor();
        }

        public override void PlayVoiceGreeting()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    string filePath = "Audio/welcome.wav";
                    SoundPlayer player = new SoundPlayer(filePath);
                    player.Play();
                    Thread.Sleep(7000);
                }
                else
                {
                    Console.WriteLine("Voice greeting is not supported on this platform.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not play voice greeting: " + ex.Message);
                Console.ResetColor();
            }
        }

        public override void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n" + new string('-', 60));
            Console.ResetColor();
        }

        public override void SimulateTyping(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("SecureBot: ");
            Console.ResetColor();

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        public void AskIfNeedAnythingElse()
        {
            string[] responses = {
                "Is there anything else you'd like to know?",
                "Can I assist you with anything further?",
                "Would you like help with something else?",
                "Is there another question I can answer for you?"
            };
            SimulateTyping(responses[new Random().Next(responses.Length)]);
        }

        public void AskHowAreYou()
        {
            string[] responses = {
                "I'm always ready and running smoothly, thanks for asking!",
                "I'm functioning perfectly, ready to assist you!",
                "All systems are go, thanks for asking!",
                "I'm doing great, thank you for checking in!"
            };
            SimulateTyping(responses[new Random().Next(responses.Length)]);
        }
    }
}