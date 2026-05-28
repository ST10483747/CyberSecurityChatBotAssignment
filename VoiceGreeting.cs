using System.Media;

namespace CyberSecurityChatBotAssignment  // Changed to match
{
    public class VoiceGreeting
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("sound.wav");
                player.PlaySync();
            }
            catch
            {
                // Ignore audio errors
            }
        }
    }
}