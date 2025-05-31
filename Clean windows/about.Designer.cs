namespace Clean_windows
{
    partial class about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            title = new Label();
            A_Logo = new PictureBox();
            Version = new Label();
            Github = new Label();
            Github_link = new LinkLabel();
            Potol = new Label();
            ((System.ComponentModel.ISupportInitialize)A_Logo).BeginInit();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("MiSans Heavy", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.Location = new Point(149, 28);
            title.Name = "title";
            title.Size = new Size(303, 47);
            title.TabIndex = 1;
            title.Text = "Clean windows";
            // 
            // A_Logo
            // 
            A_Logo.Image = (Image)resources.GetObject("A_Logo.Image");
            A_Logo.Location = new Point(59, 12);
            A_Logo.Name = "A_Logo";
            A_Logo.Size = new Size(69, 69);
            A_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            A_Logo.TabIndex = 2;
            A_Logo.TabStop = false;
            // 
            // Version
            // 
            Version.AutoSize = true;
            Version.Font = new Font("MiSans Demibold", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Version.Location = new Point(91, 136);
            Version.Name = "Version";
            Version.Size = new Size(141, 28);
            Version.TabIndex = 3;
            Version.Text = "版本 : v.0.02";
            // 
            // Github
            // 
            Github.AutoSize = true;
            Github.Font = new Font("MiSans Demibold", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Github.Location = new Point(282, 136);
            Github.Name = "Github";
            Github.Size = new Size(104, 28);
            Github.TabIndex = 4;
            Github.Text = "Github : ";
            // 
            // Github_link
            // 
            Github_link.AutoSize = true;
            Github_link.Font = new Font("MiSans Demibold", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Github_link.LinkArea = new LinkArea(0, 10);
            Github_link.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            Github_link.Location = new Point(376, 136);
            Github_link.Name = "Github_link";
            Github_link.Size = new Size(94, 34);
            Github_link.TabIndex = 5;
            Github_link.TabStop = true;
            Github_link.Text = "點我前往";
            Github_link.UseCompatibleTextRendering = true;
            Github_link.LinkClicked += Github_link_LinkClicked;
            // 
            // Potol
            // 
            Potol.AutoSize = true;
            Potol.Font = new Font("MiSans", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Potol.ForeColor = Color.Red;
            Potol.Location = new Point(184, 268);
            Potol.Name = "Potol";
            Potol.Size = new Size(151, 32);
            Potol.TabIndex = 6;
            Potol.Text = "作者 : Potol";
            // 
            // about
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 309);
            Controls.Add(Potol);
            Controls.Add(Github_link);
            Controls.Add(Github);
            Controls.Add(Version);
            Controls.Add(A_Logo);
            Controls.Add(title);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "about";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "about";
            Load += about_Load;
            ((System.ComponentModel.ISupportInitialize)A_Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label title;
        private PictureBox A_Logo;
        private Label Version;
        private Label Github;
        private LinkLabel Github_link;
        private Label Potol;
    }
}