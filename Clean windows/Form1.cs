using System.Diagnostics;
using System.Security.Principal;
using System.Text;

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
            this.Text = "Clean windows v0.01";
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
            }
            else
            {
                lblAdminStatus.Text = "未成功獲取系統管理員權限";
                lblAdminStatus.ForeColor = Color.Red;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RUN_Click(object sender, EventArgs e)
        {
            if (!IsRunAsAdmin())
            {
                MessageBox.Show("請注意當前未成功獲取系統管理員權限\n可能導致部分檔案無法清理\n如果想解決此問題請重新啟動程式以取得管理員權限。",
                    "Windows Clean 因系統權限問題發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            this.Text = "Clean windows v0.01 正在執行系統清理工作...";

            CMDlog1.Clear();
            RUNbutt.Enabled = false;
            CMDlog1.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            logLineCount = 0;

            string batContent = @"
              @echo off
              chcp 65001 >nul
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
              echo 執行 cleanmgr...
              cleanmgr /sagerun:99
              echo [Progress] cleanmgr done
              echo [Progress] finished
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
                this.Invoke(() =>
                {
                    progressBar1.Value = progressBar1.Maximum;
                    progressBar1.Visible = false;
                    RUNbutt.Enabled = true;
                    MessageBox.Show("恭喜你\n系統清理完成瞜~", "Windows Clean", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Text = "Clean windows v0.01 ";
                    AppendOutput("已經成功清理完成!");
                    // Clean_windows_temp.bat 移除剛剛產生的緩存
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
                        MessageBox.Show("無法成功將 Windows Clean 建立的緩存刪除! \n 如一直發生此問題請聯絡開發人員!\n系統報錯原因:\n" + ex.Message, "Windows Clean 發生嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AppendOutput("無法刪除暫存檔案原因：" + ex.Message);
                    }
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
                RUNbutt.Enabled = true;
                this.Text = "Clean windows v0.01 ";
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void UI_label2_Click(object sender, EventArgs e)
        {

        }
    }
}
