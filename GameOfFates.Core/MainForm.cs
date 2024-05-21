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
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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
            backgroundSound.PlayLooping();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            predictButton.Enabled = !string.IsNullOrWhiteSpace(userInputTextBox.Text);
        }

        private async void PredictClick(object sender, EventArgs e)
        {
            predictButton.Visible = false;
            askMeAnythingLabel.Visible = false;
            picAfterAsking.Visible = true;
            resetButton.Visible = true;
            fateOutputTextBox.Visible = true;

            string soundPath = @"..\..\Resources\Sounds\predictSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.Load();
            backgroundSound.PlayLooping();
        }

        private async void ResetPrediction(object sender, EventArgs e)
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
            backgroundSound.Load();
            backgroundSound.PlayLooping();
        }

        private void FateAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutLinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Krasipeace/Game-of-Fates");
        }

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

        #region ExtensionMethods
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
        #endregion
    }
}
