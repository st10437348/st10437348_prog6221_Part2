using System;
using System.Collections.Generic;

namespace CyberChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CyberChatBot";

            SecureBot bot = new SecureBot();
            bot.DisplayAsciiArt();
            bot.PlayVoiceGreeting();

            bot.PrintDivider();
            bot.SimulateTyping("Hello! I'm SecureBot, your personal guide to navigating the world of cybersecurity with confidence and clarity.");
            bot.SimulateTyping("Before we begin, may I know your name?");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userName = Console.ReadLine();

            bot.PrintDivider();
            bot.SimulateTyping($"It's a pleasure to meet you, {userName}. Together, we'll explore how to stay safe and smart online.");

            // Ask how the user is
            bot.SimulateTyping("How are you feeling today?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userMood = Console.ReadLine().ToLower();

            string[] positiveResponses = {
                "That's fantastic! A positive mindset is a great shield against cyber threats.",
                "Wonderful to hear! Let's make your online journey even safer today.",
                "Awesome! Staying informed is the key to staying secure.",
                "Great news! Together, we can tackle any cybersecurity challenge."
            };

            string[] negativeResponses = {
                "I'm sorry to hear that. Perhaps learning a few security tips will brighten your day.",
                "Thanks for sharing. Remember, protecting yourself online is a positive step forward.",
                "I understand. Let's focus on something productive like online safety.",
                "No worries, I'm here to guide you with patience and care."
            };

            if (userMood.Contains("good") || userMood.Contains("great") || userMood.Contains("fine") || userMood.Contains("well") || userMood.Contains("okay"))
            {
                bot.SimulateTyping(positiveResponses[new Random().Next(positiveResponses.Length)]);
            }
            else
            {
                bot.SimulateTyping(negativeResponses[new Random().Next(negativeResponses.Length)]);
            }

            // Interests
            bot.SimulateTyping("What area of cybersecurity sparks your curiosity? (e.g., privacy, scams, passwords, phishing, malware, VPN, safe browsing, identity theft, encryption, firewalls)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userInterest = Console.ReadLine().ToLower();

            bot.SimulateTyping($"I'll remember that you're interested in {userInterest}. That's a crucial topic!");

            bot.SimulateTyping("Ask me anything about cybersecurity, or you can ask 'what can I ask you' or 'what do you know' for more options. Type 'exit' to leave anytime.");

            var keywordResponses = new Dictionary<string, List<string>>()
            {
                { "password", new List<string> { "Strong passwords should be at least 12 characters with a mix of letters, numbers, and symbols.", "Consider using a password manager to safely store complex passwords.", "Avoid using personal information like birthdays in your passwords." } },
                { "scam", new List<string> { "Be skeptical of unsolicited requests for sensitive information.", "Always verify the source before clicking links or sharing details.", "Report scams to relevant authorities to protect others." } },
                { "privacy", new List<string> { "Limit the personal information you share on social platforms.", "Review app permissions regularly and disable what you don't use.", "Consider using privacy-focused browsers or extensions." } },
                { "phishing", new List<string> { "Look out for poor grammar and suspicious links in emails.", "Always verify sender addresses carefully.", "Don't click on links from unknown sources without verifying them." } },
                { "malware", new List<string> { "Install reputable antivirus software and keep it updated.", "Be cautious with email attachments from unknown senders.", "Backup your data regularly to avoid ransomware threats." } },
                { "vpn", new List<string> { "A VPN encrypts your internet traffic, making public Wi-Fi safer.", "Choose a VPN provider with a strict no-logs policy.", "Use VPNs to access geo-restricted content securely." } },
                { "safe browsing", new List<string> { "Always look for HTTPS before entering sensitive info.", "Consider using browser security extensions.", "Be mindful of the sites you visit and their credibility." } },
                { "identity theft", new List<string> { "Monitor your credit reports for unusual activities.", "Never share personal info over unsecured networks.", "Use multifactor authentication whenever possible." } },
                { "encryption", new List<string> { "Encrypt sensitive files to prevent unauthorized access.", "Use end-to-end encrypted messaging apps for privacy.", "Encryption ensures that data is unreadable without the correct key." } },
                { "firewalls", new List<string> { "Enable firewalls to block unauthorized access.", "Both hardware and software firewalls add layers of security.", "Regularly update firewall rules to stay protected." } },
                { "help", new List<string> { "Of course! Just let me know the topic you're curious about.", "I'm here to assist. What would you like to learn today?" } },
                { "thank you", new List<string> { "You're welcome! Happy to help anytime.", "Glad to be of assistance. Stay safe!" } },
                { "understand", new List<string> { "Let me rephrase that for you...", "Here's another way to look at it." } }
            };

            var sentiments = new Dictionary<string, string>()
            {
                { "worried", "It's normal to feel worried. Cybersecurity can seem complex, but I'm here to simplify it for you." },
                { "curious", "Curiosity is the first step towards being cyber-aware. Let's explore together!" },
                { "frustrated", "Don't worry, we'll take it one step at a time. You're not alone in this." },
                { "scared", "No need to fear. Knowledge is your best defense." },
                { "confused", "Let's clear up that confusion together. Ask me anything." },
                { "overwhelmed", "Take a deep breath. We'll tackle each topic at your pace." },
                { "anxious", "Anxiety is understandable. I'm here to make things easier for you." },
                { "happy", "That's wonderful! Positive energy helps us learn better." },
                { "bored", "I'll do my best to keep our chat engaging and informative!" },
                { "relaxed", "Great! A relaxed mind is perfect for learning." }
            };

            while (true)
            {
                bot.PrintDivider();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    bot.SimulateTyping("Please enter a valid question or statement.");
                    continue;
                }

                if (input == "exit")
                {
                    bot.SimulateTyping($"Goodbye {userName}! Stay safe and cyber-smart.");
                    break;
                }

                if (input.Contains("how are you"))
                {
                    bot.SimulateTyping("I'm always ready and running smoothly, thanks for asking!");
                    continue;
                }

                if (input.Contains("what can i ask you") || input.Contains("what do you know"))
                {
                    bot.SimulateTyping("You can ask me about passwords, scams, privacy, phishing, malware, VPN, safe browsing, identity theft, encryption, firewalls, or general cybersecurity tips.");
                    continue;
                }

                bool keywordFound = false;
                bool sentimentFound = false;

                foreach (var sentiment in sentiments)
                {
                    if (input.Contains(sentiment.Key))
                    {
                        bot.SimulateTyping(sentiment.Value);
                        sentimentFound = true;
                        break;
                    }
                }

                foreach (var keyword in keywordResponses)
                {
                    if (input.Contains(keyword.Key))
                    {
                        keywordFound = true;
                        string response = keyword.Value[new Random().Next(keyword.Value.Count)];
                        if (sentimentFound)
                        {
                            bot.SimulateTyping(response);
                        }
                        else
                        {
                            bot.SimulateTyping(response);
                        }
                        break;
                    }
                }

                if (!keywordFound && !sentimentFound)
                {
                    bot.SimulateTyping("I'm not sure I understand that. Could you try rephrasing your question?");
                }

                if (new Random().Next(10) < 2)
                {
                    bot.SimulateTyping($"Earlier you mentioned {userInterest}. Would you like to know more about it? (yes/no)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nYou: ");
                    Console.ResetColor();
                    string interestReply = Console.ReadLine().ToLower();

                    if (interestReply == "yes")
                    {
                        bot.SimulateTyping("Here's a fact that you will find interesting:");
                        if (keywordResponses.ContainsKey(userInterest))
                        {
                            string fact = keywordResponses[userInterest][new Random().Next(keywordResponses[userInterest].Count)];
                            bot.SimulateTyping(fact);
                        }
                        else
                        {
                            bot.SimulateTyping("Sorry, I don't have more details on that specific topic yet.");
                        }
                    }
                    else if (interestReply == "no")
                    {
                        bot.SimulateTyping("No problem! Is there another area of cybersecurity you're curious about?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nYou: ");
                        Console.ResetColor();
                        userInterest = Console.ReadLine().ToLower();
                        bot.SimulateTyping($"Got it! I'll remember that you're now interested in {userInterest}.");
                    }
                }
            }
        }
    }
}