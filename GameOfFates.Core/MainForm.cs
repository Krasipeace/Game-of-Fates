namespace GameOfFates.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
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
                SoundLocation = System.IO.Path.Combine(Application.StartupPath, @"..\..\Resources\Sounds\background.wav")
            };
            backgroundSound.Load();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            backgroundSound.PlayLooping();
            PictureBoxBeforeAsking(sender, e);
            PictureBoxAfterAsking(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void PictureBoxBeforeAsking(object sender, EventArgs e)
        {
            string imagePath = System.IO.Path.Combine(Application.StartupPath, @"..\..\Resources\Images\beforeAsking.jpg");
            Image originalImage = Image.FromFile(imagePath);
            Image resizedImage = ResizeImage(originalImage, 480, 480);

            picBeforeAsking.Image = resizedImage;
        }

        private void PictureBoxAfterAsking(object sender, EventArgs e)
        {
            string imagePath = System.IO.Path.Combine(Application.StartupPath, @"..\..\Resources\Images\afterAsking.jpg");
            Image originalImage = Image.FromFile(imagePath);
            Image resizedImage = ResizeImage(originalImage, 480, 480);

            picAfterAsking.Image = resizedImage;
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

        private void LabelAskMe(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            predictButton.Enabled = !string.IsNullOrWhiteSpace(userInputTextBox.Text);
        }

        private void PredictClick(object sender, EventArgs e)
        {
            predictButton.Visible = false;
            askMeAnythingLabel.Visible = false;
            picAfterAsking.Visible = true;
            resetButton.Visible = true;
            fateOutputTextBox.Visible = true;
            System.Media.SoundPlayer predictSound = new System.Media.SoundPlayer
            {
                SoundLocation = System.IO.Path.Combine(Application.StartupPath, @"..\..\Resources\Sounds\predictSound.wav")
            };
            predictSound.Load();
            predictSound.Play();
        }

        private void ResetPrediction(object sender, EventArgs e)
        {
            predictButton.Visible = true;
            askMeAnythingLabel.Visible = true;
            picAfterAsking.Visible = false;
            resetButton.Visible = false;
            fateOutputTextBox.Text = string.Empty;
            fateOutputTextBox.Visible = false;
        }

        private void FateAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutLinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Krasipeace/Game-of-Fates");
        }
    }
}
