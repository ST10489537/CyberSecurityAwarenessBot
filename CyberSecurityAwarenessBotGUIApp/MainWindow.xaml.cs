using System.Media;
using System.Windows;

namespace CyberSecurityAwarenessBotGUIApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Plays the chatbot voice greeting when the GUI opens.
            SoundPlayer player = new SoundPlayer("Assets/Greeting.wav.wav");
            player.Play();
        }
    }
}