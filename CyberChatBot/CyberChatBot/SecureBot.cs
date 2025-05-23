using System.Media;
using System.Runtime.InteropServices;

namespace CyberChatBot
{
    public class SecureBot : SecureBotBase // Main class that implements the SecureBot functionality
    {
        public override void DisplayAsciiArt() // Displays ASCII art logo in console
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

        public override void PlayVoiceGreeting() // Plays a voice greeting using a .wav file (Windows only)
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

        public override void SimulateTyping(string message) // Simulates typing effect for messages output by SecureBot
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("SecureBot: ");
            Console.ResetColor();

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // Typing effect delay
            }
            Console.WriteLine();
        }

        public void AskIfNeedAnythingElse(string keyword)
        {
            string[] responses = {
                $"Is there anything else you'd like to know about {keyword}?(yes/no)",
                $"Can I assist you with anything further related to {keyword}?(yes/no)",
                $"Would you like help with something else about {keyword}?(yes/no)",
                $"Is there another fact I can give you regarding {keyword}?(yes/no)"
            };
            SimulateTyping(responses[new Random().Next(responses.Length)]);
        }
    }
}
