namespace GameOfFates.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using static GameOfFates.Core.Fates;

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

        private void TextBox_TextChanged(object sender, EventArgs e) => predictButton.Enabled = !string.IsNullOrWhiteSpace(userInputTextBox.Text);
        #region Buttons
        private async void PredictClick(object sender, EventArgs e)
        {
            List<string> fates = LoadAnswers();

            predictButton.Visible = false;
            askMeAnythingLabel.Visible = false;
            picAfterAsking.Visible = true;
            resetButton.Visible = true;
            fateOutputTextBox.Visible = true;

            labelAfterAsking.Text = userInputTextBox.Text;
            labelAfterAsking.AutoSize = true;
            ChangeLabelPosToCenter(labelAfterAsking);
            labelAfterAsking.Visible = true;

            string soundPath = @"..\..\Resources\Sounds\predictSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.PlayLooping();
            Random randomFate = new Random();
            int indexFates = randomFate.Next(fates.Count);
            fateOutputTextBox.Text = fates[indexFates];

            labelShareTo.Visible = true;
            buttonFacebook.Visible = true;
            buttonLinkedIn.Visible = true;
            buttonTwitter.Visible = true;
            buttonInstagram.Visible = true;
            buttonTikTok.Visible = true;
            buttonDiscord.Visible = true;
        }

        private async void ResetFateClick(object sender, EventArgs e)
        {
            predictButton.Visible = true;
            askMeAnythingLabel.Visible = true;
            picAfterAsking.Visible = false;
            resetButton.Visible = false;
            fateOutputTextBox.Text = string.Empty;
            fateOutputTextBox.Visible = false;
            labelAfterAsking.Text = string.Empty;
            labelAfterAsking.Visible = false;
            userInputTextBox.Text = string.Empty;
            labelShareTo.Visible = false;
            buttonFacebook.Visible = false;
            buttonLinkedIn.Visible = false;
            buttonTwitter.Visible = false;
            buttonInstagram.Visible = false;
            buttonTikTok.Visible = false;
            buttonDiscord.Visible = false;

            string soundPath = @"..\..\Resources\Sounds\resetSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.PlayLooping();
        }
        #endregion
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

        private void ChangeLabelPosToCenter(Label label)
        {
            Control gameScreen = label.Parent;
            if (gameScreen != null)
            {
                int x = (gameScreen.Width - label.Width) / 2;
                label.Location = new Point(x, 50);
            }
        }
        #endregion
        #region Labels
        private void AboutLinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://github.com/Krasipeace/Game-of-Fates");

        private void QuestionAfterBeingAskedLabel(object sender, EventArgs e)
        {
        }

        private void FateAnswer_TextChanged(object sender, EventArgs e)
        {
        }

        private void LabelAskMe(object sender, EventArgs e)
        {
        }

        private void labelShareTo_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
