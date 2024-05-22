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
            userInputTextBox.KeyDown += UserInputTextBox_KeyDown;
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Predict_Click(sender, e);
            }
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
        private async void Predict_Click(object sender, EventArgs e)
        {
            List<string> fates = LoadAnswers();
            string soundPath = @"..\..\Resources\Sounds\predictSound.wav";
            Random randomFate = new Random();
            int indexFates = randomFate.Next(fates.Count);

            fateOutputTextBox.Visible = true;
            predictButton.Visible = false;
            askMeAnythingLabel.Visible = false;
            picAfterAsking.Visible = true;
            resetButton.Visible = true;

            labelAfterAsking.Text = userInputTextBox.Text;
            labelAfterAsking.AutoSize = true;
            ChangeLabelPosToCenter(labelAfterAsking);
            labelAfterAsking.Visible = true;

            await PlaySoundEffectAsync(soundPath);
            fateOutputTextBox.Text = fates[indexFates];
            buttonSaveCard.Visible = true;

            backgroundSound.PlayLooping();
        }

        private async void ResetFate_Click(object sender, EventArgs e)
        {
            predictButton.Visible = true;
            askMeAnythingLabel.Visible = true;
            picAfterAsking.Visible = false;
            resetButton.Visible = false;
            fateOutputTextBox.Text = "Listening to the whispers of fate...";
            fateOutputTextBox.Visible = false;
            labelAfterAsking.Text = string.Empty;
            labelAfterAsking.Visible = false;
            userInputTextBox.Text = string.Empty;
            buttonSaveCard.Visible = false;

            string soundPath = @"..\..\Resources\Sounds\resetSound.wav";
            await PlaySoundEffectAsync(soundPath);
            backgroundSound.PlayLooping();
        }

        private void ButtonSaveFateCard(object sender, EventArgs e)
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

            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string tempFilePath = Path.Combine(userFolder, "fateScreenshot.png");
            screenshot.Save(tempFilePath, ImageFormat.Png);

            System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{tempFilePath}\"");
        }
        #endregion
        #region Extension Methods

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
        #endregion
    }
}
