using System.Diagnostics;
namespace Clean_windows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            RUN = new Button();
            CMDlog1 = new TextBox();
            progressBar1 = new ProgressBar();
            lblAdminStatus = new Label();
            UI_label1 = new Label();
            menuStrip1 = new MenuStrip();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            關於ToolStripMenuItem = new ToolStripMenuItem();
            設定ToolStripMenuItem1 = new ToolStripMenuItem();
            色彩樣式ToolStripMenuItem = new ToolStripMenuItem();
            深色模式ToolStripMenuItem = new ToolStripMenuItem();
            淺色模式ToolStripMenuItem = new ToolStripMenuItem();
            跟隨系統ToolStripMenuItem = new ToolStripMenuItem();
            更多設定ToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            Stop = new Button();
            Admin_picture_no = new PictureBox();
            Admin_picture_yes = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Admin_picture_no).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Admin_picture_yes).BeginInit();
            SuspendLayout();
            // 
            // RUN
            // 
            RUN.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            RUN.Location = new Point(590, 188);
            RUN.Name = "RUN";
            RUN.Size = new Size(149, 50);
            RUN.TabIndex = 0;
            RUN.Text = "點我開始清理垃圾";
            RUN.UseVisualStyleBackColor = true;
            RUN.Click += RUN_Click;
            // 
            // CMDlog1
            // 
            CMDlog1.Enabled = false;
            CMDlog1.Location = new Point(1, 53);
            CMDlog1.Multiline = true;
            CMDlog1.Name = "CMDlog1";
            CMDlog1.ReadOnly = true;
            CMDlog1.ScrollBars = ScrollBars.Both;
            CMDlog1.Size = new Size(522, 298);
            CMDlog1.TabIndex = 1;
            CMDlog1.WordWrap = false;
            CMDlog1.TextChanged += CMDlog1_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1, 357);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(522, 37);
            progressBar1.TabIndex = 2;
            progressBar1.Visible = false;
            progressBar1.Click += progressBar1_Click;
            // 
            // lblAdminStatus
            // 
            lblAdminStatus.AutoSize = true;
            lblAdminStatus.Font = new Font("MiSans Medium", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminStatus.Location = new Point(51, 412);
            lblAdminStatus.Name = "lblAdminStatus";
            lblAdminStatus.Size = new Size(176, 18);
            lblAdminStatus.TabIndex = 3;
            lblAdminStatus.Text = "未成功獲取系統管理員權限";
            lblAdminStatus.Click += label1_Click_1;
            // 
            // UI_label1
            // 
            UI_label1.AutoSize = true;
            UI_label1.Font = new Font("MiSans Heavy", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UI_label1.Location = new Point(604, 53);
            UI_label1.Name = "UI_label1";
            UI_label1.Size = new Size(184, 28);
            UI_label1.TabIndex = 4;
            UI_label1.Text = "Clean windows";
            UI_label1.Click += UI_label1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 設定ToolStripMenuItem, 設定ToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            設定ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 關於ToolStripMenuItem });
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size = new Size(43, 20);
            設定ToolStripMenuItem.Text = "選項";
            設定ToolStripMenuItem.Click += 設定ToolStripMenuItem_Click;
            // 
            // 關於ToolStripMenuItem
            // 
            關於ToolStripMenuItem.Image = (Image)resources.GetObject("關於ToolStripMenuItem.Image");
            關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            關於ToolStripMenuItem.Size = new Size(98, 22);
            關於ToolStripMenuItem.Text = "關於";
            關於ToolStripMenuItem.Click += 關於ToolStripMenuItem_Click;
            // 
            // 設定ToolStripMenuItem1
            // 
            設定ToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { 色彩樣式ToolStripMenuItem, 更多設定ToolStripMenuItem });
            設定ToolStripMenuItem1.Name = "設定ToolStripMenuItem1";
            設定ToolStripMenuItem1.Size = new Size(43, 20);
            設定ToolStripMenuItem1.Text = "設定";
            // 
            // 色彩樣式ToolStripMenuItem
            // 
            色彩樣式ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 深色模式ToolStripMenuItem, 淺色模式ToolStripMenuItem, 跟隨系統ToolStripMenuItem });
            色彩樣式ToolStripMenuItem.Name = "色彩樣式ToolStripMenuItem";
            色彩樣式ToolStripMenuItem.Size = new Size(180, 22);
            色彩樣式ToolStripMenuItem.Text = "色彩樣式";
            // 
            // 深色模式ToolStripMenuItem
            // 
            深色模式ToolStripMenuItem.Name = "深色模式ToolStripMenuItem";
            深色模式ToolStripMenuItem.Size = new Size(180, 22);
            深色模式ToolStripMenuItem.Text = "深色模式";
            深色模式ToolStripMenuItem.Click += 深色模式ToolStripMenuItem1_Click;
            // 
            // 淺色模式ToolStripMenuItem
            // 
            淺色模式ToolStripMenuItem.Name = "淺色模式ToolStripMenuItem";
            淺色模式ToolStripMenuItem.Size = new Size(180, 22);
            淺色模式ToolStripMenuItem.Text = "淺色模式";
            淺色模式ToolStripMenuItem.Click += 淺色模式ToolStripMenuItem_Click;
            // 
            // 跟隨系統ToolStripMenuItem
            // 
            跟隨系統ToolStripMenuItem.Name = "跟隨系統ToolStripMenuItem";
            跟隨系統ToolStripMenuItem.Size = new Size(180, 22);
            跟隨系統ToolStripMenuItem.Text = "跟隨系統";
            跟隨系統ToolStripMenuItem.Click += 跟隨系統ToolStripMenuItem_Click;
            // 
            // 更多設定ToolStripMenuItem
            // 
            更多設定ToolStripMenuItem.Image = (Image)resources.GetObject("更多設定ToolStripMenuItem.Image");
            更多設定ToolStripMenuItem.Name = "更多設定ToolStripMenuItem";
            更多設定ToolStripMenuItem.Size = new Size(180, 22);
            更多設定ToolStripMenuItem.Text = "更多設定";
            更多設定ToolStripMenuItem.Click += 更多設定ToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Logo_img";
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(552, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Stop
            // 
            Stop.AccessibleDescription = "";
            Stop.Enabled = false;
            Stop.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Stop.ForeColor = Color.LightCoral;
            Stop.Location = new Point(590, 263);
            Stop.Name = "Stop";
            Stop.Size = new Size(149, 50);
            Stop.TabIndex = 8;
            Stop.Text = "強制停止";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click_1;
            // 
            // Admin_picture_no
            // 
            Admin_picture_no.Image = (Image)resources.GetObject("Admin_picture_no.Image");
            Admin_picture_no.Location = new Point(12, 400);
            Admin_picture_no.Name = "Admin_picture_no";
            Admin_picture_no.Size = new Size(33, 38);
            Admin_picture_no.SizeMode = PictureBoxSizeMode.Zoom;
            Admin_picture_no.TabIndex = 9;
            Admin_picture_no.TabStop = false;
            // 
            // Admin_picture_yes
            // 
            Admin_picture_yes.Image = (Image)resources.GetObject("Admin_picture_yes.Image");
            Admin_picture_yes.Location = new Point(12, 400);
            Admin_picture_yes.Name = "Admin_picture_yes";
            Admin_picture_yes.Size = new Size(33, 38);
            Admin_picture_yes.SizeMode = PictureBoxSizeMode.Zoom;
            Admin_picture_yes.TabIndex = 10;
            Admin_picture_yes.TabStop = false;
            Admin_picture_yes.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(Admin_picture_yes);
            Controls.Add(Admin_picture_no);
            Controls.Add(Stop);
            Controls.Add(pictureBox1);
            Controls.Add(UI_label1);
            Controls.Add(lblAdminStatus);
            Controls.Add(progressBar1);
            Controls.Add(CMDlog1);
            Controls.Add(RUN);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Admin_picture_no).EndInit();
            ((System.ComponentModel.ISupportInitialize)Admin_picture_yes).EndInit();
            ResumeLayout(false);
            PerformLayout();



        }





        #endregion

        private Button RUN;
        private TextBox CMDlog1;
        private ProgressBar progressBar1;
        private Label lblAdminStatus;
        private Label UI_label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem 關於ToolStripMenuItem;
        private ToolStripMenuItem 設定ToolStripMenuItem1;
        private PictureBox pictureBox1;
        private Button Stop;
        private ToolStripMenuItem 色彩樣式ToolStripMenuItem;
        private ToolStripMenuItem 深色模式ToolStripMenuItem;
        private ToolStripMenuItem 淺色模式ToolStripMenuItem;
        private ToolStripMenuItem 更多設定ToolStripMenuItem;
        private PictureBox Admin_picture_no;
        private PictureBox Admin_picture_yes;
        private ToolStripMenuItem 跟隨系統ToolStripMenuItem;
    }
}
