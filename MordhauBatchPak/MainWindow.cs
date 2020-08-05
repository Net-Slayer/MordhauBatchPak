using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;
using System.IO;

namespace MordhauBatchPak
{

    public partial class MainWindow : Form
    {
        public string str_CMD_Cook = "";
        public string str_CMD_Pak = "";
        public string str_CMD_Copy1 = "";
        public string str_CMD_Copy2 = "";
        public enum LogFlag { Error, Msg, CMD, log };
        public bool isEditorSet = false;
        public bool isProjectSet = false;
        

        public static MainWindow MWRef;

        public MainWindow()
        {
            InitializeComponent();
            MWRef = this;

            Txt_UE4_TextChanged(this, EventArgs.Empty);
            Txt_Proj_TextChanged(this, EventArgs.Empty);

            
        }

        

        private bool CheckPathSet(string filepath, string endswith)
        {
            PrintLine('*');
            if (filepath == "" || !filepath.EndsWith(endswith, StringComparison.CurrentCultureIgnoreCase))
            {
                PrintLog("Error: " + endswith + " Path Needed", LogFlag.Error);
                return false;
            }
            else
            {
                
                PrintLog(endswith + " located at:");
                PrintLog(filepath, LogFlag.Msg);
                return true;
            }
        }

        private void Txt_UE4_TextChanged(object sender, EventArgs e)
        {
            string str_seeking = "UE4Editor.exe";
            string path_UE4 = Txt_UE4.Text;
            isEditorSet = CheckPathSet(path_UE4, str_seeking);
            if (isEditorSet)
            {
                PrintLog("(UnrealPak.exe is expected to be in the same folder)");
                updateCookCMD();
            }

        }

        private void Txt_Proj_TextChanged(object sender, EventArgs e)
        {
            string str_seeking = "Mordhau.uproject";
            string path_Proj = Txt_Proj.Text;

            isProjectSet = CheckPathSet(path_Proj, str_seeking);
            if (isProjectSet)
            {
                PrintLog("(Mordhau project settings will be read for cooking)");
                updateCookCMD();
            }
        }

        private void btn_path_UE4_Click(object sender, EventArgs e)
        {
            string str_seeking = "UE4Editor.exe";
            ofd_UE4.FileName = str_seeking;


            if (ofd_UE4.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path_UE4 = ofd_UE4.FileName;
                Txt_UE4.Text = path_UE4;
                isEditorSet = CheckPathSet(path_UE4, str_seeking);
                if (isEditorSet) { 
                    PrintLog("(UnrealPak.exe is expected to be in the same folder)");
                    updateCookCMD();
                } 
                
            }
        }

        private void btn_path_Proj_Click(object sender, EventArgs e)
        {
            string str_seeking = "Mordhau.uproject";
            ofd_Proj.FileName = str_seeking;
            if (ofd_Proj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string path_Proj = ofd_Proj.FileName;
                Txt_Proj.Text = path_Proj;
                isProjectSet = CheckPathSet(path_Proj, str_seeking);
                if (isProjectSet)
                {
                    PrintLog("(Mordhau project settings will be read for cooking)");
                    updateCookCMD();
                }

            }
        }

        private void btn_path_Pak_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd_Pak = new CommonOpenFileDialog();
            ofd_Pak.IsFolderPicker = true;
            if (ofd_Pak.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path_Pak = ofd_Pak.FileName;
                Txt_Pak.Text = path_Pak;
            }
        }

        private void btn_path_Mount_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd_Mount = new CommonOpenFileDialog();
            ofd_Mount.IsFolderPicker = true;
            if (ofd_Mount.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path_Mount = ofd_Mount.FileName;
                Txt_Mount.Text = path_Mount;
            }
        }

        private void btn_path_Server_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd_Server = new CommonOpenFileDialog();
            ofd_Server.IsFolderPicker = true;
            if (ofd_Server.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path_Server = ofd_Server.FileName;
                Txt_Server.Text = path_Server;

            }
        }

        // utility
        public static void PrintLog(string logtxt, LogFlag lt = LogFlag.log)
        {
            Color color = Color.Black;
            switch (lt)
            {
                default:
                    {
                        color = Color.Black;
                        break;
                    }
                case LogFlag.Error:
                    {
                        color = Color.Red;
                        break;
                    }
                case LogFlag.CMD:
                    {
                        color = Color.DarkGreen;
                        break;
                    }
                case LogFlag.Msg:
                    {
                        color = Color.DarkBlue;
                        break;
                    }
                case LogFlag.log:
                    {
                        color = Color.Black;
                        break;
                    }
            }

            MWRef.LogBox.AppendText(logtxt, color);
            MWRef.LogBox.AppendText("\n");

        }

        public static void PrintLine(char a)
        {
            string line = new string(a, 15);
            PrintLog(line);

        }
        //Update cook cmd: "%unrealEditorPath%" "%mordhauProjectPath%" -run=cook -silent -targetplatform=WindowsNoEditor -CookAll -compress >Cooking.log
        public void updateCookCMD()
        {
            string compressFlag = "";
            PrintLine('=');
            if (isProjectSet && isEditorSet)
            {
                Chk_Compress_Cook.Enabled = true;
                btn_Cook.Enabled = true;

                

                if (Chk_Compress_Cook.Checked)
                    compressFlag = " -compress";

                str_CMD_Cook = "\"" + Txt_Proj.Text + "\" -run=cook -targetplatform=WindowsNoEditor -CookAll" + compressFlag + " >Cooking.log";
                //str_CMD_Cook = str_CMD_Cook + " >logs/Cooking.log";
                PrintLog("Cook command changed to:", LogFlag.Msg);

                PrintLog(str_CMD_Cook, LogFlag.CMD);

            }
            else
            {

                Chk_Compress_Cook.Enabled = false;
                btn_Cook.Enabled = false;
            }



        }

        static void runCommand(string Filename, string cmdtxt)
        {
            //Print log
            PrintLine(' ');
            PrintLine('=');
            PrintLine(' ');
            PrintLog("Running CMD");
            PrintLine(' ');
            PrintLog(cmdtxt);
            PrintLine(' ');
            PrintLine('=');
            PrintLine(' ');

            //get current directory and root
            string path = Directory.GetCurrentDirectory();
            string currentDrive = Path.GetPathRoot(path).Substring(0, 1);
            currentDrive = currentDrive + ":";
            Console.WriteLine(currentDrive);

            
            string command = "\"" + Filename + "\" " + cmdtxt;
            //create process
            Process process = new Process();
            ProcessStartInfo proInfo = new ProcessStartInfo();
            //Path
            proInfo.WorkingDirectory = path;
            //Console.WriteLine(path);
            //Initial execution

            proInfo.FileName = "cmd.exe";
            proInfo.Arguments = "/K " + currentDrive + "&&cd \""+path+" \"&" +command+"&pause";      

            //hide window
            proInfo.UseShellExecute = false;
            //proInfo.CreateNoWindow = true;

            //logging
            proInfo.RedirectStandardOutput = false;
            proInfo.RedirectStandardError = false;
            proInfo.RedirectStandardInput = false;

            process.StartInfo = proInfo;
            process.Start();
            process.WaitForExit();
            PrintLog("Cook finished! (Details saved to logfile \"Cooking.log\")", LogFlag.Msg);
        }

        private void Chk_Compress_Cook_CheckedChanged(object sender, EventArgs e)
        {
            updateCookCMD();
        }

        private void btn_Cook_Click(object sender, EventArgs e)
        {
            runCommand(Txt_UE4.Text, str_CMD_Cook);
        }

        public void Delay(int time)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                //some other processing to do possible
                if (stopwatch.ElapsedMilliseconds >= time)
                {
                    break;
                }
            }
        }

        
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
