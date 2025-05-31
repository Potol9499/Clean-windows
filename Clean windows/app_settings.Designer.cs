namespace Clean_windows
{
    partial class app_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(app_settings));
            flowLayoutPanel1 = new FlowLayoutPanel();
            ThemeT = new Label();
            light_radioButton = new RadioButton();
            dark_radioButton = new RadioButton();
            auto_radioButton = new RadioButton();
            settings_ico = new PictureBox();
            settings_label = new Label();
            d_L_ico = new PictureBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settings_ico).BeginInit();
            ((System.ComponentModel.ISupportInitialize)d_L_ico).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(ThemeT);
            flowLayoutPanel1.Controls.Add(dark_radioButton);
            flowLayoutPanel1.Controls.Add(light_radioButton);
            flowLayoutPanel1.Controls.Add(auto_radioButton);
            flowLayoutPanel1.Location = new Point(58, 96);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(138, 109);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // ThemeT
            // 
            ThemeT.AutoSize = true;
            ThemeT.Font = new Font("MiSans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ThemeT.Location = new Point(3, 0);
            ThemeT.Name = "ThemeT";
            ThemeT.Size = new Size(117, 22);
            ThemeT.TabIndex = 3;
            ThemeT.Text = "選擇顏色模式 :";
            // 
            // light_radioButton
            // 
            light_radioButton.AutoSize = true;
            light_radioButton.Font = new Font("MiSans Demibold", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            light_radioButton.Location = new Point(3, 53);
            light_radioButton.Name = "light_radioButton";
            light_radioButton.Size = new Size(104, 22);
            light_radioButton.TabIndex = 4;
            light_radioButton.TabStop = true;
            light_radioButton.Text = "啟用淺色模式";
            light_radioButton.UseVisualStyleBackColor = true;
            // 
            // dark_radioButton
            // 
            dark_radioButton.AutoSize = true;
            dark_radioButton.Font = new Font("MiSans Demibold", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dark_radioButton.Location = new Point(3, 25);
            dark_radioButton.Name = "dark_radioButton";
            dark_radioButton.Size = new Size(104, 22);
            dark_radioButton.TabIndex = 5;
            dark_radioButton.TabStop = true;
            dark_radioButton.Text = "啟用深色模式";
            dark_radioButton.UseVisualStyleBackColor = true;
            // 
            // auto_radioButton
            // 
            auto_radioButton.AutoSize = true;
            auto_radioButton.Font = new Font("MiSans Demibold", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            auto_radioButton.Location = new Point(3, 81);
            auto_radioButton.Name = "auto_radioButton";
            auto_radioButton.Size = new Size(104, 22);
            auto_radioButton.TabIndex = 6;
            auto_radioButton.TabStop = true;
            auto_radioButton.Text = "跟隨系統設置";
            auto_radioButton.UseVisualStyleBackColor = true;
            // 
            // settings_ico
            // 
            settings_ico.Image = (Image)resources.GetObject("settings_ico.Image");
            settings_ico.Location = new Point(26, 12);
            settings_ico.Name = "settings_ico";
            settings_ico.Size = new Size(69, 64);
            settings_ico.SizeMode = PictureBoxSizeMode.Zoom;
            settings_ico.TabIndex = 1;
            settings_ico.TabStop = false;
            // 
            // settings_label
            // 
            settings_label.AutoSize = true;
            settings_label.Font = new Font("MiSans", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            settings_label.Location = new Point(114, 27);
            settings_label.Name = "settings_label";
            settings_label.Size = new Size(123, 36);
            settings_label.TabIndex = 2;
            settings_label.Text = "更多設定";
            // 
            // d_L_ico
            // 
            d_L_ico.Image = (Image)resources.GetObject("d_L_ico.Image");
            d_L_ico.Location = new Point(22, 96);
            d_L_ico.Name = "d_L_ico";
            d_L_ico.Size = new Size(30, 30);
            d_L_ico.SizeMode = PictureBoxSizeMode.Zoom;
            d_L_ico.TabIndex = 3;
            d_L_ico.TabStop = false;
            // 
            // app_settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 415);
            Controls.Add(d_L_ico);
            Controls.Add(settings_label);
            Controls.Add(settings_ico);
            Controls.Add(flowLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "app_settings";
            Text = "app_settings";
            Load += app_settings_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settings_ico).EndInit();
            ((System.ComponentModel.ISupportInitialize)d_L_ico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label ThemeT;
        private RadioButton light_radioButton;
        private RadioButton dark_radioButton;
        private RadioButton auto_radioButton;
        private PictureBox settings_ico;
        private Label settings_label;
        private PictureBox d_L_ico;
    }
}