namespace GameOfFates.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;
    using System.Security.Policy;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

    public partial class MainForm : Form
    {
        private readonly System.Media.SoundPlayer backgroundSound;

        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            backgroundSound = new System.Media.SoundPlayer
            {
                SoundLocation = Path.Combine(Application.StartupPath, @"..\..\Resources\Sounds\background.wav")
            };
            backgroundSound.Load();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            backgroundSound.PlayLooping();
            PictureBoxBeforeAsking(sender, e);
            PictureBoxAfterAsking(sender, e);
            predictButton.Enabled = false;
        }

        private void PictureBoxBeforeAsking(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, @"..\..\Resources\Images\beforeAsking.jpg");
            Image originalImage = Image.FromFile(imagePath);

            Image resizedImage = ResizeImage(originalImage, 480, 480);

            picBeforeAsking.Image = resizedImage;
        }

        private void PictureBoxAfterAsking(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, @"..\..\Resources\Images\afterAsking.jpg");
            Image originalImage = Image.FromFile(imagePath);

            Image resizedImage = ResizeImage(originalImage, 480, 480);

            picAfterAsking.Image = resizedImage;
        }

        private void LabelAskMe(object sender, EventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, EventArgs e) => predictButton.Enabled = !string.IsNullOrWhiteSpace(userInputTextBox.Text);

        private async void PredictClick(object sender, EventArgs e)
        {
            List<string> answers = LoadAnswers();

            predictButton.Visible = false;
            askMeAnythingLabel.Visible = false;
            picAfterAsking.Visible = true;
            resetButton.Visible = true;
            fateOutputTextBox.Visible = true;

            string soundPath = @"..\..\Resources\Sounds\predictSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.PlayLooping();
            Random random = new Random();
            int index = random.Next(answers.Count);
            fateOutputTextBox.Text = answers[index];
        }

        private async void ResetFateClick(object sender, EventArgs e)
        {
            predictButton.Visible = true;
            askMeAnythingLabel.Visible = true;
            picAfterAsking.Visible = false;
            resetButton.Visible = false;
            fateOutputTextBox.Text = string.Empty;
            fateOutputTextBox.Visible = false;
            userInputTextBox.Text = string.Empty;

            string soundPath = @"..\..\Resources\Sounds\resetSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.PlayLooping();
        }

        private void FateAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutLinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://github.com/Krasipeace/Game-of-Fates");

        #region Extension Methods
        private void ShareFateToSocialNetwork()
        {
            Bitmap screenshot = new Bitmap(picAfterAsking.Width, picAfterAsking.Height);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(
                    picAfterAsking.PointToScreen(Point.Empty),
                    Point.Empty,
                    picAfterAsking.Size
                );
            }

            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string tempFilePath = Path.Combine(downloadsFolder, "screenshot.png");
            screenshot.Save(tempFilePath, ImageFormat.Png);

            ShareToSocialNetwork(tempFilePath);

            File.Delete(tempFilePath);
        }

        private void ShareToSocialNetwork(string filePath)
        {

        }

        private async Task PlaySoundEffectAsync(string soundPath)
        {
            using (var soundPlayer = new System.Media.SoundPlayer(soundPath))
            {
                await Task.Run(() => soundPlayer.PlaySync());
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        private static List<string> LoadAnswers()
        {
            return new List<string>
            {
                "Yes, definitely.",
                "No, certainly not.",
                "Maybe, time will tell.",
                "Ask again later.",
                "The signs point to yes.",
                "The outlook is not so good.",
                "It is certain.",
                "My sources say no.",
                "Very doubtful.",
                "Without a doubt.",
                "Better not tell you now.",
                "Yes, but be prepared.",
                "Unlikely, but possible.",
                "Concentrate and ask again.",
                "Yes, and it will be a blessing.",
                "No, and it might be for the best.",
                "Cannot predict now.",
                "Absolutely, without a doubt.",
                "The answer is unclear, try again.",
                "The stars say no.",
                "Yes, and with great success.",
                "No, and it’s a good thing.",
                "Perhaps in another life.",
                "The universe says yes.",
                "The odds are in your favor.",
                "Do not count on it.",
                "Signs point to no.",
                "Yes, if you believe.",
                "No, but don’t lose hope.",
                "It is highly likely.",
                "It is not in the cards.",
                "All indications say yes.",
                "Not in the foreseeable future.",
                "Yes, but not as expected.",
                "No, and you should be cautious.",
                "It's a mystery.",
                "Yes, the omens are good.",
                "No, the omens are bad.",
                "Yes, with conditions.",
                "No, under any circumstances.",
                "Yes, luck is on your side.",
                "No, fate has other plans.",
                "Maybe, but be patient.",
                "Definitely, but with a twist.",
                "No, and it’s a sign.",
                "The fates are undecided.",
                "Yes, fortune smiles upon you.",
                "No, misfortune lurks.",
                "Yes, the outcome is favorable.",
                "No, the outcome is unfavorable.",
                "Yes, it’s written in the stars.",
                "No, it’s written in the stars.",
                "Yes, beyond a shadow of a doubt.",
                "No, beyond a shadow of a doubt.",
                "Yes, and it will bring joy.",
                "No, and it will bring sorrow.",
                "Yes, but only if you act now.",
                "No, unless circumstances change.",
                "The spirits say yes.",
                "The spirits say no.",
                "Yes, with a stroke of luck.",
                "No, unless you’re lucky.",
                "Yes, but don’t take it for granted.",
                "No, but there’s hope.",
                "Yes, as sure as the sun will rise.",
                "No, as sure as the sun will set.",
                "Yes, but it won’t be easy.",
                "No, but there’s a silver lining.",
                "Yes, the path is clear.",
                "No, the path is blocked.",
                "Yes, the future looks bright.",
                "No, the future looks dim.",
                "Yes, and it will surprise you.",
                "No, and it will surprise you.",
                "Yes, it’s almost certain.",
                "No, it’s highly unlikely.",
                "Yes, with a bit of effort.",
                "No, despite your efforts.",
                "Yes, fate is on your side.",
                "No, fate is against you.",
                "Yes, the signs are auspicious.",
                "No, the signs are ominous.",
                "Yes, but only if you believe.",
                "No, unless you believe.",
                "Yes, the stars align.",
                "No, the stars misalign.",
                "Yes, it’s a strong possibility.",
                "No, it’s a weak possibility.",
                "Yes, and it will be worthwhile.",
                "No, and it will be challenging.",
                "Yes, with flying colors.",
                "No, but don’t despair.",
                "Yes, it’s highly probable.",
                "No, it’s highly improbable.",
                "Yes, the answer is affirmative.",
                "No, the answer is negative.",
                "Yes, and it’s a sure thing.",
                "No, and it’s a long shot.",
                "Yes, with all your heart.",
                "No, but keep the faith.",
            };
        }
        #endregion
    }
}
