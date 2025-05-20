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
            RUNbutt = new Button();
            CMDlog1 = new TextBox();
            progressBar1 = new ProgressBar();
            lblAdminStatus = new Label();
            UI_label1 = new Label();
            UI_label2 = new Label();
            SuspendLayout();
            // 
            // RUNbutt
            // 
            RUNbutt.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            RUNbutt.Location = new Point(597, 335);
            RUNbutt.Name = "RUNbutt";
            RUNbutt.Size = new Size(160, 59);
            RUNbutt.TabIndex = 0;
            RUNbutt.Text = "點我開始清理垃圾";
            RUNbutt.UseVisualStyleBackColor = true;
            RUNbutt.Click += RUN_Click;
            // 
            // CMDlog1
            // 
            CMDlog1.Enabled = false;
            CMDlog1.Location = new Point(1, 53);
            CMDlog1.Multiline = true;
            CMDlog1.Name = "CMDlog1";
            CMDlog1.ReadOnly = true;
            CMDlog1.ScrollBars = ScrollBars.Vertical;
            CMDlog1.Size = new Size(522, 298);
            CMDlog1.TabIndex = 1;
            CMDlog1.WordWrap = false;
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
            lblAdminStatus.Location = new Point(1, 415);
            lblAdminStatus.Name = "lblAdminStatus";
            lblAdminStatus.Size = new Size(151, 15);
            lblAdminStatus.TabIndex = 3;
            lblAdminStatus.Text = "未成功獲取系統管理員權限";
            lblAdminStatus.Click += label1_Click_1;
            // 
            // UI_label1
            // 
            UI_label1.AutoSize = true;
            UI_label1.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            UI_label1.Location = new Point(569, 47);
            UI_label1.Name = "UI_label1";
            UI_label1.Size = new Size(216, 26);
            UI_label1.TabIndex = 4;
            UI_label1.Text = "Clean windows v0.01";
            // 
            // UI_label2
            // 
            UI_label2.AutoSize = true;
            UI_label2.Font = new Font("Microsoft JhengHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            UI_label2.ForeColor = Color.Crimson;
            UI_label2.Location = new Point(722, 437);
            UI_label2.Name = "UI_label2";
            UI_label2.Size = new Size(78, 14);
            UI_label2.TabIndex = 5;
            UI_label2.Text = "Author: Potol";
            UI_label2.TextAlign = ContentAlignment.TopCenter;
            UI_label2.Click += UI_label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UI_label2);
            Controls.Add(UI_label1);
            Controls.Add(lblAdminStatus);
            Controls.Add(progressBar1);
            Controls.Add(CMDlog1);
            Controls.Add(RUNbutt);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();



        }





        #endregion

        private Button RUNbutt;
        private TextBox CMDlog1;
        private ProgressBar progressBar1;
        private Label lblAdminStatus;
        private Label UI_label1;
        private Label UI_label2;
    }
}
