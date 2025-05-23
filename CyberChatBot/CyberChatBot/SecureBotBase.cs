namespace CyberChatBot
{
    // Abstract base class that defines the structure for SecureBot
    public abstract class SecureBotBase
    {
        public abstract void DisplayAsciiArt(); // Display the ASCII art logo
        public abstract void PlayVoiceGreeting(); // Play the welcome audio greeting
        public abstract void PrintDivider(); // Print a visual divider
        public abstract void SimulateTyping(string message); // Simulate typing effect
    }
}
