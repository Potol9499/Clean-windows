using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Clean_windows.Form1;

namespace Clean_windows
{
    public partial class about : Form
    {
        private ThemePreference currentTheme; // 儲存主視窗傳過來的主題設定
        public about(ThemePreference theme)
        {
            InitializeComponent();
            currentTheme = theme;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void about_Load(object sender, EventArgs e)
        {
            this.Text = "關於 Clean windows v0.02";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
          

            // 根據主視窗的主題套用樣式
            switch (currentTheme)
            {
                case ThemePreference.Dark:
                    ApplyDarkMode();
                    break;
                case ThemePreference.Light:
                    ApplyLightMode();
                    break;
                case ThemePreference.Auto:
                default:
                    if (IsSystemLightMode())
                        ApplyLightMode();
                    else
                        ApplyDarkMode();
                    break;
            }
        }

        private void ApplyDarkMode()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

            ApplyDarkModeToControls(this.Controls);
        }

        private void ApplyLightMode()
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = Color.Black;

            ApplyLightModeToControls(this.Controls);
        }

        private void ApplyDarkModeToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Label || ctrl is LinkLabel)
                {
                    ctrl.ForeColor = Color.White;
                    ctrl.BackColor = Color.Transparent;
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(45, 45, 45);
                    ctrl.ForeColor = Color.White;
                }

                if (ctrl.HasChildren)
                    ApplyDarkModeToControls(ctrl.Controls);
                if (ctrl == Potol) // 禁止更換 Potol 顏色
                    ctrl.ForeColor = Color.Red;
            }
        }

        private void ApplyLightModeToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Label || ctrl is LinkLabel)
                {
                    ctrl.ForeColor = Color.Black;
                    ctrl.BackColor = Color.Transparent;
                }
                else
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                }

                if (ctrl.HasChildren)
                    ApplyLightModeToControls(ctrl.Controls);
                if (ctrl == Potol) // 禁止更換 Potol 顏色
                    ctrl.ForeColor = Color.Red;
            }
        }


        private bool IsSystemLightMode()
        {
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("AppsUseLightTheme");
                        if (value != null && value is int intValue)
                        {
                            return intValue == 1;
                        }
                    }
                }
            }
            catch { }

            return true; // 預設為亮色
        }


        private void Github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Github_link.LinkVisited = true;
            Process.Start(new ProcessStartInfo { FileName = @"https://github.com/Potol9499/Clean-windows", UseShellExecute = true });
        }


    }
}
