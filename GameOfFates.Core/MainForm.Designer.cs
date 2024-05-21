namespace GameOfFates.Core
{
    partial class MainForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picBeforeAsking = new System.Windows.Forms.PictureBox();
            this.picAfterAsking = new System.Windows.Forms.PictureBox();
            this.userInputTextBox = new System.Windows.Forms.TextBox();
            this.predictButton = new System.Windows.Forms.Button();
            this.askMeAnythingLabel = new System.Windows.Forms.Label();
            this.fateOutputTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picBeforeAsking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterAsking)).BeginInit();
            this.SuspendLayout();
            // 
            // picBeforeAsking
            // 
            this.picBeforeAsking.Image = global::GameOfFates.Core.Properties.Resources.beforeAsking;
            this.picBeforeAsking.Location = new System.Drawing.Point(12, 12);
            this.picBeforeAsking.Name = "picBeforeAsking";
            this.picBeforeAsking.Size = new System.Drawing.Size(480, 480);
            this.picBeforeAsking.TabIndex = 1;
            this.picBeforeAsking.TabStop = false;
            this.picBeforeAsking.Click += new System.EventHandler(this.PictureBoxBeforeAsking);
            // 
            // picAfterAsking
            // 
            this.picAfterAsking.Image = global::GameOfFates.Core.Properties.Resources.afterAsking;
            this.picAfterAsking.Location = new System.Drawing.Point(12, 12);
            this.picAfterAsking.Name = "picAfterAsking";
            this.picAfterAsking.Size = new System.Drawing.Size(480, 480);
            this.picAfterAsking.TabIndex = 2;
            this.picAfterAsking.TabStop = false;
            this.picAfterAsking.Visible = false;
            this.picAfterAsking.Click += new System.EventHandler(this.PictureBoxAfterAsking);
            // 
            // userInputTextBox
            // 
            this.userInputTextBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.userInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userInputTextBox.ForeColor = System.Drawing.Color.MistyRose;
            this.userInputTextBox.Location = new System.Drawing.Point(12, 498);
            this.userInputTextBox.Name = "userInputTextBox";
            this.userInputTextBox.Size = new System.Drawing.Size(480, 38);
            this.userInputTextBox.TabIndex = 4;
            this.userInputTextBox.Tag = "";
            this.userInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userInputTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // predictButton
            // 
            this.predictButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.predictButton.ForeColor = System.Drawing.Color.Moccasin;
            this.predictButton.Location = new System.Drawing.Point(192, 550);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(119, 36);
            this.predictButton.TabIndex = 5;
            this.predictButton.Text = "Predict!";
            this.predictButton.UseVisualStyleBackColor = false;
            this.predictButton.Click += new System.EventHandler(this.PredictClick);
            // 
            // askMeAnythingLabel
            // 
            this.askMeAnythingLabel.AutoSize = true;
            this.askMeAnythingLabel.BackColor = System.Drawing.Color.Teal;
            this.askMeAnythingLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.askMeAnythingLabel.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.askMeAnythingLabel.Location = new System.Drawing.Point(160, 447);
            this.askMeAnythingLabel.Name = "askMeAnythingLabel";
            this.askMeAnythingLabel.Size = new System.Drawing.Size(185, 33);
            this.askMeAnythingLabel.TabIndex = 6;
            this.askMeAnythingLabel.Text = "Ask me Anything";
            // 
            // fateOutputTextBox
            // 
            this.fateOutputTextBox.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.fateOutputTextBox.Font = new System.Drawing.Font("Ink Free", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fateOutputTextBox.ForeColor = System.Drawing.Color.Aquamarine;
            this.fateOutputTextBox.Location = new System.Drawing.Point(12, 370);
            this.fateOutputTextBox.Name = "fateOutputTextBox";
            this.fateOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.fateOutputTextBox.Size = new System.Drawing.Size(480, 41);
            this.fateOutputTextBox.TabIndex = 7;
            this.fateOutputTextBox.Text = "test";
            this.fateOutputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fateOutputTextBox.Visible = false;
            this.fateOutputTextBox.TextChanged += new System.EventHandler(this.FateAnswer_TextChanged);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.SlateBlue;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.resetButton.Location = new System.Drawing.Point(188, 550);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(123, 36);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset Fate";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Visible = false;
            this.resetButton.Click += new System.EventHandler(this.ResetPrediction);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.linkLabel1.Location = new System.Drawing.Point(457, 578);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutLinkLabel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.fateOutputTextBox);
            this.Controls.Add(this.askMeAnythingLabel);
            this.Controls.Add(this.predictButton);
            this.Controls.Add(this.userInputTextBox);
            this.Controls.Add(this.picAfterAsking);
            this.Controls.Add(this.picBeforeAsking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Game of Fates";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBeforeAsking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterAsking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBeforeAsking;
        private System.Windows.Forms.PictureBox picAfterAsking;
        private System.Windows.Forms.TextBox userInputTextBox;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.Label askMeAnythingLabel;
        private System.Windows.Forms.TextBox fateOutputTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

