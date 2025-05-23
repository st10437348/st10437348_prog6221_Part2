namespace CyberChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CyberChatBot";
            SecureBot bot = new SecureBot(); // Initialize the bot
            bot.DisplayAsciiArt();
            bot.PlayVoiceGreeting();

            bot.PrintDivider();
            // Initial greeting and get user's name
            bot.SimulateTyping("Hello! I'm SecureBot, your personal guide to navigating the world of cybersecurity with confidence and clarity. I am looking forward to chatting with you and assisting in any way I can.");
            bot.SimulateTyping("Before we begin, what is your name? I would love to address you in a more personal manner since you already know my name.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userName = Console.ReadLine();

            // Respond to user's name
            bot.SimulateTyping($"It's a pleasure to meet you, {userName}. Together, we'll explore how to stay safe and smart online and hopefully by the end of our conversation you would have learnt a thing or two.");

            // Ask and respond to user's mood
            bot.SimulateTyping("How are you feeling today?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userMood = Console.ReadLine().ToLower();

            // Arrays of positive and negative responses based on mood
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

            // Ask user to choose an area of interest
            List<string> validInterests = new List<string> {
                "passwords", "scams", "privacy", "phishing", "malware", "vpn",
                "safe browsing", "identity theft", "encryption", "firewalls"
            };

            string userInterest = "";

            while (true)
            {
                bot.SimulateTyping("What area of cybersecurity sparks your curiosity? (privacy, scams, passwords, phishing, malware, VPN, safe browsing, identity theft, encryption and firewalls)");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                Console.ResetColor();
                userInterest = Console.ReadLine()?.ToLower().Trim();

                if (!string.IsNullOrWhiteSpace(userInterest) &&
                    validInterests.Any(i => i == userInterest || userInterest.Contains(i)))
                {
                    userInterest = validInterests.First(i => userInterest.Contains(i));
                    break;
                }

                bot.SimulateTyping("Hmm... I didn't catch that as a valid topic. Please choose one from the list.");
            }

            bot.SimulateTyping($"I'll remember that you're interested in {userInterest}. That's a crucial topic! Maybe later on in our chat we can discuss {userInterest} further.");

            bot.SimulateTyping("Ask me anything about cybersecurity, or you can ask 'what can I ask you' or 'what do you know' for more options. Type 'exit' to leave anytime.");

            var keywordResponses = new Dictionary<string, List<string>>() // Dictionary of keyword-based facts
            {
                { "passwords", new List<string> {
                    $"Strong passwords should be at least 12 characters long, using a combination of uppercase and lowercase letters, numbers and symbols to enhance complexity. For example {userName}123@IieMsa.",
                    "Avoid using obvious choices like your name, birthdate, or common words, as these can be easily guessed or cracked by attackers.",
                    "Each account should have a unique password; reusing passwords increases the risk of a domino effect if one account is compromised.",
                    "A password manager helps generate, store, and autofill complex passwords securely, reducing the temptation to use weak or repeated passwords.",
                    "Change your passwords regularly, especially for sensitive accounts, and immediately after any suspected security breach."
                }},
                { "scams", new List<string> {
                    "Scammers often impersonate trusted organizations or people—always confirm identities through official contact channels before responding.",
                    "Watch out for urgent requests for money or personal data; creating panic is a common tactic used to override your better judgment.",
                    "Do not trust caller ID or email headers at face value—these can be spoofed to appear legitimate while being fraudulent.",
                    "Take a moment to research any suspicious offers or requests online. Many scams follow common patterns that others have reported.",
                    "Reporting scams to authorities and platforms can help prevent others from falling victim and contributes to broader cybersecurity efforts."
                }},
                { "privacy", new List<string> {
                    "Think carefully about what you share online; even casual posts can reveal information useful to identity thieves or scammers.",
                    "Adjust your privacy settings on social media and mobile apps to limit access to your personal data and location.",
                    "Uninstall apps you no longer use and routinely review permissions to ensure you’re not oversharing data with unnecessary services.",
                    "Consider using privacy-focused browsers and search engines, like Brave or DuckDuckGo, to minimize tracking and data collection.",
                    "Use alias emails and phone numbers for sign-ups and mailing lists to reduce exposure and better manage who can contact you."
                }},
                { "phishing", new List<string> {
                    "Phishing emails often create urgency before acting on a message asking for sensitive information or money.",
                    "Carefully examine email addresses and URLs; subtle differences or misspellings can signal a phishing attempt.",
                    "Avoid clicking on links or downloading files in unexpected messages, even if they appear to come from someone you know.",
                    "Legitimate companies will never ask you for your password or payment details via email—when in doubt, contact them directly.",
                    "Use spam filters and report phishing emails so they can be blocked in the future and help protect others."
                }},
                { "malware", new List<string> {
                    "Install antivirus software from a reputable provider and keep it updated to protect against known and emerging threats.",
                    "Be cautious with files downloaded from unfamiliar websites or shared via email—they could carry malicious payloads.",
                    "Keep your operating system, browsers and plugins up to date; many malware infections exploit outdated software.",
                    "Avoid pirated software or media, as they are common sources of bundled malware and other unwanted programs.",
                    "Back up your data regularly to secure locations, such as encrypted cloud storage or external drives, in case of a malware attack like ransomware."
                }},
                { "vpn", new List<string> {
                    "A VPN encrypts your internet traffic, which protects your data from hackers on unsecured public networks like coffee shop Wi-Fi.",
                    "Select a trustworthy VPN provider that doesn’t log your activity and offers strong encryption and fast, stable connections.",
                    "VPNs help prevent websites, advertisers, and even your ISP from tracking your browsing habits across the web.",
                    "Some countries restrict content based on location; a VPN allows you to access these resources securely while traveling.",
                    "Always turn on your VPN before accessing sensitive services or when connecting to networks you don’t control."
                }},
                { "safe browsing", new List<string> {
                    "Look for a padlock icon and 'https://' in the URL bar before entering sensitive information on a website.",
                    "Install browser extensions that enhance security and privacy, such as ad blockers or anti-tracking tools.",
                    "Avoid clicking suspicious links, even if they appear on familiar websites—malvertising can target trusted platforms.",
                    "Log out of accounts after use and clear cookies regularly to minimize exposure from session hijacking or tracking.",
                    "Only download software from verified, official sources to avoid inadvertently installing malicious code."
                }},
                { "identity theft", new List<string> {
                    "Monitor your credit reports and bank statements regularly for any signs of unauthorized activity or new account openings.",
                    "Don’t share personal information like your Social Security number, home address, or full birthdate unless absolutely necessary.",
                    "Use multifactor authentication wherever possible—this adds a critical layer of defense even if your password is compromised.",
                    "Avoid using public Wi-Fi for sensitive tasks like banking unless you’re connected through a secure VPN.",
                    "Shred physical documents containing personal details before disposal to prevent dumpster diving data theft."
                }},
                { "encryption", new List<string> {
                    "Encrypt important files, especially those stored on portable devices or cloud services, to prevent unauthorized access if lost or stolen.",
                    "Use communication platforms that support end-to-end encryption so your messages can’t be read by anyone except the intended recipient.",
                    "Encryption is only as secure as your passphrase—use long, complex phrases and avoid reusing them across services.",
                    "Enable device encryption on laptops, smartphones, and tablets so that even if your device is stolen, your data remains protected.",
                    "Be aware of where your encrypted data is stored and make sure the keys or passwords needed to unlock it are stored securely."
                }},
                { "firewalls", new List<string> {
                    "Firewalls monitor and control incoming and outgoing traffic to protect against unauthorized access and malicious activity.",
                    "Use both hardware (on your router) and software (on your device) firewalls to create multiple layers of defense.",
                    "Review and customize your firewall rules to limit what applications can communicate over the internet.",
                    "Keep your firewall software updated to ensure it's equipped to recognize and respond to the latest threats.",
                    "Avoid disabling your firewall for convenience—if necessary, only disable temporarily and re-enable immediately after the task is complete."
                }},
            };

            var sentiments = new Dictionary<string, string>() // Sentiment-based supportive responses
            {
                { "worried", $"It's normal to feel worried {userName}. Cybersecurity can seem complex, but I'm here to simplify it for you." },
                { "curious", $"Curiosity is the first step towards being cyber-aware. Let's explore together, {userName}!" },
                { "frustrated", $"Don't worry {userName}, we'll take it one step at a time. You're not alone in this." },
                { "scared", $"No need to fear {userName}. Knowledge is your best defense." },
                { "confused", $"Let's clear up that confusion together. Ask me anything thats on your mind, {userName}." },
                { "overwhelmed", $"Take a deep breath {userName}. We'll tackle each topic at your pace." },
                { "anxious", $"Anxiety is understandable. I'm here to make things easier for you." },
                { "happy", $"That's wonderful, {userName}! Positive energy helps us learn better." },
                { "bored", $"Im sorry {userName}. I'll do my best to keep our chat engaging and informative!" },
                { "relaxed", $"Great stuff, {userName}! A relaxed mind is perfect for learning." }
            };

            while (true) // Main interaction loop
            {
                bot.PrintDivider();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    bot.SimulateTyping($"I'm not sure I understand that. Could you maybe try rephrasing your response or question {userName}? I will do my best to interpret it.");
                    continue;
                }

                if (input == "exit")
                {
                    bot.SimulateTyping($"Goodbye {userName}! Stay safe and remember to come back if you have any more questions.");
                    break;
                }

                if (input.Contains("how are you"))
                {
                    bot.SimulateTyping($"I'm up and running as smoothly as ever, thanks for asking {userName}!");
                    continue;
                }

                if (input.Contains("what can i ask you") || input.Contains("what do you know"))
                {
                    bot.SimulateTyping("You can ask me about: \n-passwords \n-scams \n-privacy \n-phishing \n-malware \n-VPN \n-safe browsing \n-identity theft \n-encryption \n-firewalls");
                    continue;
                }

                bool keywordFound = false;
                bool sentimentFound = false;

                foreach (var sentiment in sentiments) // Sentiment matching
                {
                    if (input.Contains(sentiment.Key))
                    {
                        bot.SimulateTyping(sentiment.Value);
                        sentimentFound = true;
                        break;
                    }
                }

                foreach (var keyword in keywordResponses) // Keyword (topic) matching
                {
                    if (input.Contains(keyword.Key))
                    {
                        keywordFound = true;

                        if (sentimentFound)
                        {
                            bot.SimulateTyping($"Hopefully this fact will help you, {userName}:");
                        }
                        Random rand = new Random();
                        string response = keyword.Value[rand.Next(keyword.Value.Count)];
                        bot.SimulateTyping(response);

                        bot.AskIfNeedAnythingElse(keyword.Key);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nYou: ");
                        Console.ResetColor();
                        string yesNoResponse = Console.ReadLine().ToLower();

                        if (yesNoResponse == "yes")
                        {
                            bot.SimulateTyping($"Here's another fact you might find interesting, {userName}:");
                            string fact = keywordResponses[keyword.Key][rand.Next(keywordResponses[keyword.Key].Count)];
                            bot.SimulateTyping(fact);
                        }
                        else if (yesNoResponse == "no")
                        {
                            bot.SimulateTyping($"Awesome! I hope this means I have helped you understand {keyword.Key}.");
                        }
                        else
                        {
                            bot.SimulateTyping($"I didn't quite get that {userName}, but feel free to ask anything else!");
                        }

                        break;
                    }
                }

                if (!keywordFound && !sentimentFound) // Fallback for unrecognised input
                {
                    bot.SimulateTyping($"I'm not sure I understand that. Could you maybe try rephrasing your response {userName}? I will do my best to interpret your response");
                }

                if (new Random().Next(10) < 4) // Occasional prompt to revisit interest (recall feature)
                {
                    bot.SimulateTyping($"{userName}, earlier you mentioned {userInterest}. Would you like to know more about it? (yes/no)");
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
                    }
                    else if (interestReply == "no")
                    {
                        string newInterest = "";
                        bool validNewInterest = false;

                        while (!validNewInterest)
                        {
                            bot.SimulateTyping("Is there another area of cybersecurity you're curious about?");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nYou: ");
                            Console.ResetColor();
                            newInterest = Console.ReadLine().ToLower();

                            if (validInterests.Contains(newInterest))
                            {
                                validNewInterest = true;
                                userInterest = newInterest;
                                bot.SimulateTyping($"Got it, {userName}! I'll remember that you're now interested in {userInterest}.");
                            }
                            else
                            {
                                bot.SimulateTyping("Hmm, that doesn't match my list of cybersecurity topics. Please choose from the valid options.");
                            }
                        }
                    }
                }
            }
        }
    }
}

