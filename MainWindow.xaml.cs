using System;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatBotAssignment
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Add welcome message when window loads
            ChatDisplay.AppendText("Bot: Welcome to the Cybersecurity Awareness Bot! 🌐\n");
            ChatDisplay.AppendText("Bot: How can I help you with cybersecurity today?\n");
            ChatDisplay.AppendText("Bot: You can ask about:\n");
            ChatDisplay.AppendText("  • Password security\n");
            ChatDisplay.AppendText("  • Phishing attacks\n");
            ChatDisplay.AppendText("  • Safe browsing\n");
            ChatDisplay.AppendText("  • Two-factor authentication\n\n");
            UserInput.Focus();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendUserMessage();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendUserMessage();
            }
        }

        private void SendUserMessage()
        {
            string userMessage = UserInput.Text.Trim();

            if (!string.IsNullOrEmpty(userMessage))
            {
                // Display user message
                ChatDisplay.AppendText($"You: {userMessage}\n");

                // Generate bot response
                string botResponse = GetBotResponse(userMessage);
                ChatDisplay.AppendText($"Bot: {botResponse}\n\n");

                // Clear input and scroll to bottom
                UserInput.Clear();
                ChatDisplay.ScrollToEnd();
                UserInput.Focus();
            }
        }

        private string GetBotResponse(string userInput)
        {
            string input = userInput.ToLower();

            if (input.Contains("password"))
            {
                return "Use strong passwords with 12+ characters, including uppercase, lowercase, numbers, and symbols. Never reuse passwords across sites! Consider using a password manager.";
            }
            else if (input.Contains("phish"))
            {
                return "Don't click suspicious links or download unknown attachments. Check sender email addresses carefully. When in doubt, contact the company directly through official channels.";
            }
            else if (input.Contains("brows") || input.Contains("safe"))
            {
                return "Always look for 'https://' and padlock icon in address bar. Avoid public Wi-Fi for sensitive transactions. Keep your browser updated!";
            }
            else if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("mfa"))
            {
                return "Two-Factor Authentication adds an extra security layer. Use authenticator apps instead of SMS when possible. Always enable it when available!";
            }
            else if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                return "Hello! I'm here to help you stay safe online. What cybersecurity topic would you like to learn about?";
            }
            else
            {
                return "That's a great question! For specific cybersecurity advice, try asking about passwords, phishing, safe browsing, or two-factor authentication. Stay secure! 🔒";
            }
        }
    }
}
