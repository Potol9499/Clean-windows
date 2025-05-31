using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean_windows
{
    public partial class app_settings : Form
    {
        private Form1 mainForm;
        public app_settings(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
            this.StartPosition = FormStartPosition.CenterParent;
            

            light_radioButton.CheckedChanged += ThemeRadio_CheckedChanged;
            dark_radioButton.CheckedChanged += ThemeRadio_CheckedChanged;
            auto_radioButton.CheckedChanged += ThemeRadio_CheckedChanged;
        }

        private void app_settings_Load(object sender, EventArgs e)
        {
            this.Text = "設定 Clean windows ";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string setting = Clean_windows.Settings.Default.UserThemePreference;
            if (Enum.TryParse(setting, out Form1.ThemePreference preference))
            {
                switch (preference)
                {
                    case Form1.ThemePreference.Light:
                        light_radioButton.Checked = true;
                        ApplyLightMode();
                        break;
                    case Form1.ThemePreference.Dark:
                        dark_radioButton.Checked = true;
                        ApplyDarkMode();
                        break;
                    case Form1.ThemePreference.Auto:
                        auto_radioButton.Checked = true;
                        if (mainForm.IsSystemLightMode())
                            ApplyLightMode();
                        else
                            ApplyDarkMode();
                        break;
                }

            }


        }
        // 當使用者在 app settings 選擇後 傳回主視窗 ST_SetTheme 
        // 進行變更主題動作
        private void ThemeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;

            if (light_radioButton.Checked)
            {
                ApplyLightMode();
                mainForm?.ST_SetTheme(Form1.ThemePreference.Light);
            }
            else if (dark_radioButton.Checked)
            {
                ApplyDarkMode();
                mainForm?.ST_SetTheme(Form1.ThemePreference.Dark);
            }
            else
            {
                // 自動跟隨系統
                if (mainForm.IsSystemLightMode())
                    ApplyLightMode();
                else
                    ApplyDarkMode();

                mainForm?.ST_SetTheme(Form1.ThemePreference.Auto);
            }
        }

        private void ApplyDarkMode()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            flowLayoutPanel1.BackColor = Color.FromArgb(30, 30, 30);

            ThemeT.ForeColor = Color.White;
            settings_label.ForeColor = Color.White;

            light_radioButton.ForeColor = Color.White;
            light_radioButton.BackColor = Color.FromArgb(30, 30, 30);

            dark_radioButton.ForeColor = Color.White;
            dark_radioButton.BackColor = Color.FromArgb(30, 30, 30);

            auto_radioButton.ForeColor = Color.White;
            auto_radioButton.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void ApplyLightMode()
        {
            this.BackColor = SystemColors.Control;
            flowLayoutPanel1.BackColor = SystemColors.Control;

            ThemeT.ForeColor = Color.Black;
            settings_label.ForeColor = Color.Black;

            light_radioButton.ForeColor = Color.Black;
            light_radioButton.BackColor = SystemColors.Control;

            dark_radioButton.ForeColor = Color.Black;
            dark_radioButton.BackColor = SystemColors.Control;

            auto_radioButton.ForeColor = Color.Black;
            auto_radioButton.BackColor = SystemColors.Control;
        }


    }
}
