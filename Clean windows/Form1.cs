using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;
using System.Drawing;
using static Clean_windows.Form1;


namespace Clean_windows
{
    public partial class Form1 : Form
    {
        private Process cmdProcess;
        private int logLineCount = 0;
        private int estimatedTotalLines = 20;



        public Form1()
        {
            InitializeComponent();
            UpdateAdminStatusLabel();
       
            this.Text = "Clean windows";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 程式啟動時先檢查是否有管理員權限
            if (!IsRunAsAdmin())
            {
                try
                {
                    var exeName = Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName)
                    {
                        UseShellExecute = true,
                        Verb = "runas" // 這行代表「以管理員權限執行」
                    };
                    Process.Start(startInfo);

                    // 用 Environment.Exit(0) 立即關閉當前程序（舊的未授權視窗）
                    Environment.Exit(0);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    if (ex.NativeErrorCode == 1223) // 使用者拒絕 UAC
                    {
                        MessageBox.Show("請求系統權限時被拒絕\n如不需要系統管理員身份則無須理會\n否則建議你重新啟動程式!",
                            "Windows Clean 因系統權限問題發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("無法以系統管理員身份重新啟動\n請嘗試重新開啟\n如無效請聯絡開發人員!\n錯誤訊息：\n" + ex.Message,
                            "Windows Clean 因系統權限問題發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        // 判斷是否為管理員
        private bool IsRunAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void UpdateAdminStatusLabel()
        {
            if (IsRunAsAdmin())
            {
                lblAdminStatus.Text = "已啟用系統管理員權限";
                lblAdminStatus.ForeColor = Color.Green;
                //因為資產問題使用另一種方式達成ico切換!
                Admin_picture_yes.Visible = true;
                Admin_picture_no.Visible = false;
            }
            else
            {
                lblAdminStatus.Text = "未成功獲取系統管理員權限";
                lblAdminStatus.ForeColor = Color.Red;
                //因為資產問題使用另一種方式達成ico切換!
                Admin_picture_yes.Visible = false;
                Admin_picture_no.Visible = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private Process cleanmgrProcess; //為了加入強制停止
        private bool isManuallyStopped = false; // 防止強制停止後再出現完成訊息


        private void RUN_Click(object sender, EventArgs e)
        {
            if (!IsRunAsAdmin())
            {
                MessageBox.Show("請注意當前未成功獲取系統管理員權限\n可能導致部分檔案無法清理\n如果想解決此問題請重新啟動程式以取得管理員權限。",
                    "Windows Clean 因系統權限問題發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            this.Text = "Clean windows 正在執行系統清理工作...";

            CMDlog1.Clear();
            RUN.Enabled = false;
            Stop.Enabled = true;
            CMDlog1.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            logLineCount = 0;

            string batContent = @"
              @echo off
              chcp 65001
              echo [Progress] Start cleanup

              echo 清理 .tmp 檔案...
              del /f /s /q %systemdrive%\*.tmp
              echo [Progress] tmp done

              echo 清理 ._mp 檔案...
              del /f /s /q %systemdrive%\*._mp
              echo [Progress] _mp done

              echo 清理 .log 檔案...
              del /f /s /q %systemdrive%\*.log
              echo [Progress] log done

              echo 清理 .gid 檔案...
              del /f /s /q %systemdrive%\*.gid
              echo [Progress] gid done

              echo 清理 .chk 檔案...
              del /f /s /q %systemdrive%\*.chk
              echo [Progress] chk done

              echo 清理 .old 檔案...
              del /f /s /q %systemdrive%\*.old
              echo [Progress] old done

              echo 清理系統資料夾...
              del /f /s /q %systemdrive%\recycled\*.*
              del /f /s /q %windir%\*.bak
              del /f /s /q %windir%\prefetch\*.*
              del /f /q %userprofile%\cookies\*.*
              del /f /q %userprofile%\recent\*.*
              del /f /s /q ""%userprofile%\Local Settings\Temporary Internet Files\*.*""
              del /f /s /q ""%userprofile%\Local Settings\Temp\*.*""
              del /f /s /q ""%userprofile%\recent\*.*""
              DEL /S /F /Q ""%systemroot%\Temp\*.*""
              DEL /S /F /Q ""%AllUsersProfile%\「開始」功能表\程式集\Windows Messenger.lnk""
              RD /S /Q %windir%\temp & md %windir%\temp
              RD /S /Q ""%userprofile%\Local Settings\Temp""
              MD ""%userprofile%\Local Settings\Temp""
              RD /S /Q ""%systemdrive%\Program Files\Temp""
              MD ""%systemdrive%\Program Files\Temp""
              RD /S /Q ""%systemdrive%\d""
              echo [Progress] folders done
              ";



            // 自動計算 echo 次數作為進度條最大值
            estimatedTotalLines = batContent.Split('\n').Count(line => line.Contains("[Progress]"));
            progressBar1.Maximum = estimatedTotalLines; ;

            string batFilePath = Path.Combine(Path.GetTempPath(), "Clean_windows_temp.bat");
            File.WriteAllText(batFilePath, batContent, Encoding.UTF8); // 使用 UTF8 避免亂碼

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c \"" + batFilePath + "\"",
                StandardOutputEncoding = Encoding.UTF8,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            cmdProcess = new Process
            {
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            cmdProcess.OutputDataReceived += (s, ev) =>
            {
                if (ev.Data != null)
                {
                    AppendOutput(ev.Data);

                    if (ev.Data.Contains("[Progress]"))
                    {
                        UpdateProgress();
                    }
                }
            };

            cmdProcess.ErrorDataReceived += (s, ev) =>
            {
                if (ev.Data != null)
                {
                    AppendOutput("[錯誤] " + ev.Data);
                }
            };

            cmdProcess.Exited += (s, ev) =>
            {
                // 先回UI執行緒，做檔案刪除和顯示訊息
                this.Invoke(() =>
                {
                    this.Text = "Clean windows 使用系統內建清理工具清理中";
                    AppendOutput("正在啟動系統內建清理工具...");

                    try
                    {
                        if (File.Exists(batFilePath))
                        {
                            AppendOutput("已經自動刪除 Windows Clean 在電腦中建立的緩存!");
                            File.Delete(batFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("無法成功將 Windows Clean 建立的緩存刪除! \n 如一直發生此問題請聯絡開發人員!\n系統報錯原因:\n" + ex.Message, "Windows Clean 發生嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AppendOutput("無法刪除暫存檔案原因：" + ex.Message);
                    }
                });



                try
                {
                    ProcessStartInfo cleanmgr = new ProcessStartInfo
                    {
                        FileName = "cleanmgr.exe",
                        Arguments = "/sagerun:99",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    AppendOutput("系統內建清理工具已啟動正在開始清理...");

                    cleanmgrProcess = Process.Start(cleanmgr);
                    cleanmgrProcess.WaitForExit();
                    cleanmgrProcess = null;
                }

                catch (Exception ex)
                {
                    this.Invoke(() =>
                    {
                        AppendOutput("[錯誤] cleanmgr 啟動失敗：" + ex.Message);
                    });
                }

                // cleanmgr 完成，回復UI更新狀態和提示
                this.Invoke(() =>
                {
                    if (isManuallyStopped)
                    {
                        AppendOutput("已終止所有系統清理工作!!");
                    }
                    else
                    {
                        AppendOutput("系統內建清理工具已完成!");
                        MessageBox.Show("恭喜你\n系統清理完成瞜~", "Windows Clean", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    progressBar1.Value = progressBar1.Maximum;
                    progressBar1.Visible = false;
                    RUN.Enabled = true;
                    Stop.Enabled = false;
                    this.Text = "Clean windows ";
                    isManuallyStopped = false; // 恢復停止狀態
                });
            };
            try
            {
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                AppendOutput("執行錯誤：" + ex.Message);
                progressBar1.Visible = false;
                RUN.Enabled = true;
                this.Text = "Clean windows ";
            }
        }



        private void AppendOutput(string text)
        {
            if (CMDlog1.InvokeRequired)
            {
                CMDlog1.Invoke(new Action<string>(AppendOutput), text);
            }
            else
            {
                CMDlog1.AppendText(text + Environment.NewLine);
                CMDlog1.SelectionStart = CMDlog1.Text.Length;
                CMDlog1.ScrollToCaret();
            }
        }

        private void UpdateProgress()
        {
            this.Invoke(() =>
            {
                logLineCount++;
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value = Math.Min(logLineCount, progressBar1.Maximum);
                }

            });
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        public bool IsSystemLightMode()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null)
                    {
                        object registryValueObject = key.GetValue("AppsUseLightTheme");
                        if (registryValueObject != null)
                        {
                            int registryValue = (int)registryValueObject;
                            return registryValue > 0;
                        }
                    }
                }
            }
            catch
            {
                return true;
            }

            return true;
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_SETTINGCHANGE = 0x001A;
            const int WM_THEMECHANGED = 0x031A;

            if (m.Msg == WM_SETTINGCHANGE || m.Msg == WM_THEMECHANGED)
            {
                //  只有使用者設定為 Auto 才跟隨系統
                string userPref = Clean_windows.Settings.Default.UserThemePreference;
                if (Enum.TryParse(userPref, out ThemePreference preference) && preference == ThemePreference.Auto)
                {
                    if (IsSystemLightMode())
                        ApplyLightMode();
                    else
                        ApplyDarkMode();
                }
            }

            base.WndProc(ref m);
        }

        public enum ThemePreference
        {
            Auto,
            Light,
            Dark
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyUserPreferredTheme(); // 自動根據設定套用主題與勾選

        }

        public void ST_SetTheme(ThemePreference preference) //app settings回傳後在此設定
        {
            Clean_windows.Settings.Default.UserThemePreference = preference.ToString();
            Clean_windows.Settings.Default.Save();
            ApplyUserPreferredTheme();
        }

        private void ApplyUserPreferredTheme()
        {
            ThemePreference preference = GetCurrentThemePreference();

            switch (preference)
            {
                case ThemePreference.Light:
                    ApplyLightMode();
                    break;
                case ThemePreference.Dark:
                    ApplyDarkMode();
                    break;
                case ThemePreference.Auto:
                default:
                    if (IsSystemLightMode())
                        ApplyLightMode();
                    else
                        ApplyDarkMode();
                    break;
            }

            UpdateMenuChecks(); // 更新選單勾選狀態
        }

        private ThemePreference GetCurrentThemePreference()
        {
            string setting = Clean_windows.Settings.Default.UserThemePreference;

            if (!string.IsNullOrEmpty(setting) &&
                Enum.TryParse(setting, out ThemePreference parsed))
            {
                return parsed;
            }

            return ThemePreference.Auto;
        }

        private void SetTheme(ThemePreference preference)
        {
            // 儲存到設定
            Clean_windows.Settings.Default.UserThemePreference = preference.ToString();
            Clean_windows.Settings.Default.Save();

            // 套用主題並更新勾選
            ApplyUserPreferredTheme();
        }



        private void ApplyDarkMode() // 黑暗模式 呼叫選項
        {
            // 設定 Form1 本身
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

            ApplyDarkModeToControls(this.Controls);
        }

        private void ApplyLightMode()// 亮色模式 呼叫選項
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = Color.Black;

            ApplyLightModeToControls(this.Controls);
        }

        // 設置 Form1 黑暗模式
        private void ApplyDarkModeToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl == lblAdminStatus) // 顯示是否啟用管理員字體停止變更
                    continue;

                if (ctrl is Button)
                {
                    ctrl.BackColor = Color.FromArgb(50, 50, 50);
                    ctrl.ForeColor = Color.White;
                    ((Button)ctrl).FlatStyle = FlatStyle.Flat;
                    ((Button)ctrl).FlatAppearance.BorderColor = Color.Gray;
                }
                else if (ctrl is TextBox || ctrl is RichTextBox)
                {
                    ctrl.BackColor = Color.FromArgb(40, 40, 40);
                    ctrl.ForeColor = Color.White;
                }
                else if (ctrl is Label)
                {
                    ctrl.ForeColor = Color.White;
                    ctrl.BackColor = Color.Transparent;
                }
                else if (ctrl is MenuStrip)
                {
                    ctrl.BackColor = Color.FromArgb(45, 45, 45);
                    ctrl.ForeColor = Color.White;
                    ((MenuStrip)ctrl).Renderer = new DarkMenuRenderer();
                }
                else if (ctrl is StatusStrip)
                {
                    ctrl.BackColor = Color.FromArgb(45, 45, 45);
                    ctrl.ForeColor = Color.White;
                }
                else
                {
                    // 通用設定
                    ctrl.BackColor = Color.FromArgb(45, 45, 45);
                    ctrl.ForeColor = Color.White;
                }
                if (ctrl == Stop) // 禁止更換 Stop 按鈕顏色
                    ctrl.ForeColor = Color.FromArgb(255, 117, 117);

                // 遞迴處理內部子控制項
                if (ctrl.HasChildren)
                {
                    ApplyDarkModeToControls(ctrl.Controls);
                }
            }
        }

        // 設置 Form1 亮色模式
        private void ApplyLightModeToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl == lblAdminStatus) // 顯示是否啟用管理員字體停止變更
                    continue;

                if (ctrl is Button)
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                    ((Button)ctrl).FlatStyle = FlatStyle.Standard;
                }
                else if (ctrl is TextBox || ctrl is RichTextBox)
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                }
                else if (ctrl is Label)
                {
                    ctrl.ForeColor = Color.Black;
                    ctrl.BackColor = Color.Transparent;
                }
                else if (ctrl is MenuStrip || ctrl is StatusStrip)
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                    menuStrip1.Renderer = new ToolStripProfessionalRenderer();
                }
                else
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                }
                if (ctrl == Stop) // 禁止更換 Stop 按鈕顏色
                    ctrl.ForeColor = Color.FromArgb(255, 117, 117);

                if (ctrl.HasChildren)
                {
                    ApplyLightModeToControls(ctrl.Controls);
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void UI_label2_Click(object sender, EventArgs e)
        {

        }

        private void CMDlog1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 關於ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 從設定中取得主題設定（字串）
            string setting = Clean_windows.Settings.Default.UserThemePreference;

            // 預設為 Auto
            ThemePreference preference = ThemePreference.Auto;

            // 嘗試將字串轉換為 enum
            if (!string.IsNullOrEmpty(setting) && Enum.TryParse(setting, out ThemePreference parsed))
            {
                preference = parsed;
            }

            // 傳入到 about 視窗
            about aboutForm = new about(preference);
            aboutForm.ShowDialog();
        }

        private void 更多設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            app_settings settingsForm = new app_settings(this);
            settingsForm.ShowDialog();
        }


        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UI_label1_Click(object sender, EventArgs e)
        {

        }


        private void Stop_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    isManuallyStopped = true; // 改成 true 防止強制停止後還繼續執行!

                    if (cmdProcess != null && !cmdProcess.HasExited)
                    {
                        cmdProcess.Kill();
                        AppendOutput("已強制停止系統清理");
                        MessageBox.Show("已強制停止系統清理!", "Clean windows 提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (cleanmgrProcess != null && !cleanmgrProcess.HasExited)
                    {
                        cleanmgrProcess.Kill();
                        AppendOutput("已強制停止系統內建清理工具 (cleanmgr.exe)");
                        MessageBox.Show("已強制停止系統內建清理工具 (cleanmgr.exe)", "Clean windows 提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    RUN.Enabled = true;
                    progressBar1.Visible = false;
                    Stop.Enabled = false;
                    this.Text = "Clean windows ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法停止清理作業：" + ex.Message, "Clean windows 錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 深色模式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetTheme(ThemePreference.Dark);
        }

        private void 淺色模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTheme(ThemePreference.Light);
        }

        private void 跟隨系統ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTheme(ThemePreference.Auto);
        }

        private void UpdateMenuChecks()
        {
            ThemePreference preference = GetCurrentThemePreference();

            淺色模式ToolStripMenuItem.Checked = (preference == ThemePreference.Light);
            深色模式ToolStripMenuItem.Checked = (preference == ThemePreference.Dark);
            跟隨系統ToolStripMenuItem.Checked = (preference == ThemePreference.Auto);
        }




        // 黑暗模式中強制 menuStrip1 兼容黑暗模式!
        public class DarkMenuRenderer : ToolStripProfessionalRenderer
        {
            public DarkMenuRenderer() : base(new DarkColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White;
                base.OnRenderItemText(e);
            }
        }

        public class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(64, 64, 64);
            public override Color MenuItemBorder => Color.Black;

            public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);
            public override Color MenuBorder => Color.Black;

            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(64, 64, 64);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(64, 64, 64);

            public override Color MenuItemPressedGradientBegin => Color.FromArgb(28, 28, 28);
            public override Color MenuItemPressedGradientMiddle => Color.FromArgb(28, 28, 28);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(28, 28, 28);

            public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
            public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);
        }

       
    }
}


