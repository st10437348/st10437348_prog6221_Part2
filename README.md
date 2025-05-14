
CyberChatBot - User Guide
Overview
CyberChatBot is a console application that simulates a chatbot for cybersecurity guidance. It interacts with the user, provides helpful tips and answers questions based on keywords. The bot also remembers your interests and can recall them later in the conversation.

How to Use
1. Run the Program
Open the project in Visual Studio.

Make sure you have an audio file named welcome.wav placed inside the Audio folder.

Build and run the project.

2. Follow the Prompts
On start, the bot will:

Display a welcome ASCII art.

Play a voice greeting (Windows only).

It will ask for your name — type your name and press Enter.

It will ask how you are feeling — type your mood (e.g., "good", "curious").

It will ask what cybersecurity topic you’re interested in — type topics like "privacy", "malware", "VPN", etc.

3. Chat with SecureBot
You can now ask questions by typing keywords.

Example topics you can ask about:

password, scam, privacy, phishing, malware, vpn, safe browsing, identity theft, encryption, firewalls.

Type your question or just the keyword.

Example: "Tell me about passwords" or simply "password".

4. Keyword Detection
The bot looks for specific keywords in your input.

When a keyword is found, the bot gives a random helpful tip related to that topic.

Even partial matches will trigger responses.

Example: Typing "How do I create a strong password?" will trigger the password response.

5. Sentiment Detection
The bot also detects emotional keywords like:

worried, curious, frustrated, scared, confused, overwhelmed, anxious, happy, bored, relaxed.

Based on your input, it will respond with encouraging or helpful messages.

6. Recall Feature (Reminders)
Throughout the conversation, the bot remembers your chosen topic of interest.

Sometimes, it will ask if you’d like to know more about that topic.

Example: "Earlier you mentioned phishing. Would you like to know more about it?"

You can answer "yes" or "no".

If "yes", the bot will provide another fact.

If "no", you can specify a new topic of interest, and the bot will remember that instead.

7. Help & Guidance
If you’re unsure what to ask, you can type:

"what can I ask you" or "what do you know".

The bot will list the available topics.

8. Exit the Chat
To end the conversation, simply type "exit".

The bot will say goodbye and close the program.



References:

Troelsen, A. and Japikse, P., 2022. Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11th ed. Berkeley, CA: Apress.