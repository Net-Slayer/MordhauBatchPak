using Microsoft.WindowsAPICodePack.Dialogs;
using MordhauBatchPak.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace MordhauBatchPak
{
    public partial class MainWindow : Form
    {
        public static MainWindow MWRef;
        public bool isEditorSet = false;
        public bool isMapSet = false;
        public bool isPakSet = false;
        public bool isProjectSet = false;
        public bool isMountSet = false;
        public bool isServerSet = false;
        public string str_CMD_Cook = "";
        public string str_CMD_Copy1 = "";
        public string str_CMD_Copy2 = "";
        public string str_CMD_Pak = "";
        public string str_Dir = Directory.GetCurrentDirectory();
        public string str_path_Map = "";
        public string str_Path_UE4Pak = "";

        public enum LogFlag { Error, Msg, CMD, log };

        public MainWindow()
        {
            InitializeComponent();
            MWRef = this;

            CheckUE4();
            CheckProj();
            CheckMap();
            CheckPak();
            CheckMount();
            CheckServer();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowLocation != null)
                this.Location = Settings.Default.WindowLocation;
        }

        private bool CheckPathSet(string folderpath, bool returnError = true)
        {
            if (Directory.Exists(folderpath))
            {
                // This path is a directory
                return true;
            }
            else
            {

                if (folderpath == "")
                {
                    if (returnError)
                    {
                        PrintLog("Directory not set", LogFlag.Error);
                        PrintLine('_');
                    }
                    
                }
                else
                {
                    if (returnError)
                    {
                        PrintLog(folderpath + " is not a valid directory.", LogFlag.Error);
                        PrintLine('_');
                    }
                    
                }

                return false;
            }
        }

        private bool CheckPathSet(string filepath, string endswith)
        {
            PrintLine('*');
            if (filepath == "" || !File.Exists(filepath) || !filepath.EndsWith(endswith, StringComparison.CurrentCultureIgnoreCase))
            {
                PrintLog("Error: " + endswith + " Path Needed", LogFlag.Error);
                PrintLine('_');
                return false;
            }
            else
            {
                PrintLog(endswith + " located at:", LogFlag.Msg);
                PrintLog(filepath, LogFlag.CMD);
                PrintLine();
                return true;
            }
        }

        public static void PrintLine(char a = ' ')
        {
            string line = new string(a, 15);
            PrintLog(line);
        }

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

        private void CheckMap()
        {
            if (isProjectSet)
            {
                str_path_Map = Path.GetDirectoryName(Txt_Proj.Text) + @"\Content\Mordhau\Maps\" + Txt_MapName.Text;
                Console.WriteLine("Debug Path Map: " + str_path_Map);

                if (Txt_MapName.Text == "")
                    isMapSet = false;
                else
                {
                    PrintLog("Checking Map Directory");
                    isMapSet = CheckPathSet(str_path_Map, false);
                }
                if (isMapSet)
                {
                    PrintLine('*');
                    PrintLog("Pak name will be " + Txt_MapName.Text + ".pak based on map folder name", LogFlag.CMD);
                    PrintLine('*');
                    updatePakCMD();
                }
            }
            Gate_Pak();
        }

        private void CheckUE4()
        {
            string str_seeking = "UE4Editor.exe";
            string path_UE4 = Txt_UE4.Text;
            isEditorSet = CheckPathSet(path_UE4, str_seeking);
            if (isEditorSet)
            {
                PrintLog("(UnrealPak.exe is expected to be in the same folder)");
                PrintLine('_');
                updateCookCMD();
            }
            Gate_Cook();
            Gate_Pak();
        }

        private void CheckProj()
        {
            string str_seeking = "Mordhau.uproject";
            string path_Proj = Txt_Proj.Text;

            isProjectSet = CheckPathSet(path_Proj, str_seeking);
            if (isProjectSet)
            {
                PrintLog("(Mordhau project settings will be read for cooking, project path will be used for pakking)");
                PrintLine('_');
                updateCookCMD();
                Txt_MapName.Enabled = true;
            }
            else
                Txt_MapName.Enabled = false;
            Gate_Cook();
            Gate_Pak();
        }

        private void CheckPak()
        {
            string path_Pak = Txt_Pak.Text;
            PrintLog("Checking for Pak Folder");
            isPakSet = CheckPathSet(path_Pak);
            if (isPakSet)
            {
                PrintLine('*');
                PrintLog("Cooked files will be Pakked", LogFlag.CMD);
                PrintLine('*');
                updatePakCMD();
            }

            Gate_Pak();
        }

        private void CheckMount()
        {
            string path_Mount = Txt_Mount.Text;
            //check if valid
            PrintLog("Checking for Mount Folder");
            isMountSet = CheckPathSet(path_Mount);
            if (isMountSet)
            {
                PrintLine('=');
                PrintLog("Pak will be copied to mount folder: " + path_Mount, LogFlag.Msg);
                PrintLine('=');
            }
            Gate_Cook();
            Gate_Pak();
        }

        private void CheckServer()
        {
            string path_Server = Txt_Server.Text;
            //check if valid
            PrintLog("Checking for Server Folder");
            isServerSet = CheckPathSet(path_Server);
            if (isServerSet)
            {
                PrintLine('=');
                PrintLog("Pak will be copied to server folder: " + path_Server, LogFlag.Msg);
                PrintLine('=');
                Gate_Pak();
            }
            Gate_Cook();
            Gate_Pak();
        }

        private void Gate_Cook()
        {
            if (isEditorSet && isProjectSet)
            {
                //allow cook
                btn_Cook.Enabled = true;
                Chk_Compress_Cook.Enabled = true;

                //allow pak input
                grp_Pak.Enabled = true;
                Txt_MapName.Enabled = true;
                Txt_Pak.Enabled = true;
                btn_path_Pak.Enabled = true;
            }
            else
            {
                //disable cook
                btn_Cook.Enabled = false;
                Chk_Compress_Cook.Enabled = false;

                //disable pak input
                grp_Pak.Enabled = false;
                Txt_MapName.Enabled = false;
                Txt_Pak.Enabled = false;
                btn_path_Pak.Enabled = false;
                btn_Build.Enabled = false;
            }
        }

        private void Gate_Pak()
        {
            if (isMapSet && isPakSet && isEditorSet && isProjectSet)
            {
                //allow pak
                btn_Pak.Enabled = true;
                Chk_Compress_Pak.Enabled = true;

                //allow copy input
                grp_Copy.Enabled = true;
                Txt_Mount.Enabled = true;
                Txt_Server.Enabled = true;
                btn_path_Mount.Enabled = true;
                btn_path_Server.Enabled = true;
                if (isMountSet || isServerSet)
                {
                    btn_Copy.Enabled = true;
                    btn_Build.Enabled = true;
                }
                else
                {
                    btn_Copy.Enabled = false;
                    btn_Build.Enabled = false;
                }
            }
            else
            {
                btn_Pak.Enabled = false;
                Chk_Compress_Pak.Enabled = false;

                //disable copy input
                grp_Copy.Enabled = false;
                Txt_Mount.Enabled = false;
                Txt_Server.Enabled = false;
                btn_path_Mount.Enabled = false;
                btn_path_Server.Enabled = false;
                btn_Copy.Enabled = false;
                btn_Build.Enabled = false;
            }
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }

        private void Txt_MapName_TextChanged(object sender, EventArgs e)
        {
            CheckMap();
        }

        private void Txt_UE4_TextChanged(object sender, EventArgs e)
        {
            CheckUE4();
        }

        private void Txt_Proj_TextChanged(object sender, EventArgs e)
        {
            CheckProj();
        }

        private void Txt_Pak_TextChanged(object sender, EventArgs e)
        {
            CheckPak();
        }

        private void Txt_Mount_TextChanged(object sender, EventArgs e)
        {
            CheckMount();
        }

        private void Txt_Server_TextChanged(object sender, EventArgs e)
        {
            CheckServer();
        }

        private void btn_path_UE4_Click(object sender, EventArgs e)
        {
            string str_seeking = "UE4Editor.exe";
            ofd_UE4.FileName = str_seeking;

            if (ofd_UE4.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path_UE4 = ofd_UE4.FileName;
                Txt_UE4.Text = path_UE4;
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

        private void Chk_Compress_Cook_CheckedChanged(object sender, EventArgs e)
        {
            updateCookCMD();
        }

        private void Chk_Compress_Pak_CheckedChanged(object sender, EventArgs e)
        {
            updatePakCMD();
        }

        private void btn_Cook_Click(object sender, EventArgs e)
        {
            PrintLine();
            runCommand(Txt_UE4.Text, str_CMD_Cook, "Cook finished! (Details saved to logfile \"Cooking.log\")");
            PrintLine();
        }

        private void btn_Pak_Click(object sender, EventArgs e)
        {
            PrintLine();
            runCommand(str_Path_UE4Pak, str_CMD_Pak, "Pak finished! (Details saved to logfile \"Packing.log\")");
            PrintLine();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            PrintLine();

            string sourcePath = Txt_Pak.Text;
            string fileName = Txt_MapName.Text + ".pak";
            string MountPath = Txt_Mount.Text;
            string ServerPath = Txt_Server.Text;

            //Check if pak exists
            string sourceFile = Path.Combine(sourcePath, fileName);
            if (!File.Exists(sourceFile))
            {
                PrintLog("Error: " + sourceFile + " does not exist, copying stage aborted");
                return;
            }
            SystemSounds.Asterisk.Play();

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            //Check if path is valid
            if (isMountSet)
            {
                string destMount = Path.Combine(MountPath, fileName);
                System.IO.Directory.CreateDirectory(MountPath);
                System.IO.File.Copy(sourceFile, destMount, true);
                PrintLog(fileName + " copied to " + MountPath);
            }
            else
                PrintLog("Mount folder not set, skipped copying to mount folder", LogFlag.Error);

            if (isServerSet)
            {
                string destServer = Path.Combine(ServerPath, fileName);
                System.IO.Directory.CreateDirectory(ServerPath);
                System.IO.File.Copy(sourceFile, destServer, true);
                PrintLog(fileName + " copied to " + ServerPath);
            }
            else
                PrintLog("Server folder not set, skipped copying to Server folder", LogFlag.Error);

            SystemSounds.Exclamation.Play();
            watch.Stop();

            PrintLog($"Execution Time: {watch.ElapsedMilliseconds} ms", LogFlag.CMD);

            // Copy each if filled and valid
            PrintLog("Copying finished! Good luck!", LogFlag.Msg);

            PrintLine();
        }

        public void updateCookCMD()
        {
            if (isProjectSet && isEditorSet)
            {
                PrintLine(' ');
                PrintLine('=');
                PrintLog("Checking Cook variables");
                PrintLine('=');
                PrintLine(' ');

                if (Chk_Compress_Cook.Checked)
                    str_CMD_Cook = "\"" + Txt_Proj.Text + "\" -run=cook -targetplatform=WindowsNoEditor -silent -CookAll -compress >Cooking.log";
                else
                    str_CMD_Cook = "\"" + Txt_Proj.Text + "\" -run=cook -targetplatform=WindowsNoEditor -silent -CookAll >Cooking.log";

                //str_CMD_Cook = str_CMD_Cook + " >logs/Cooking.log";
                PrintLog("Cook command changed to:", LogFlag.Msg);
                PrintLog(str_CMD_Cook, LogFlag.CMD);
                PrintLine('_');
            }
        }

        public void updatePakCMD()
        {
            if (isPakSet && isEditorSet && isProjectSet && isMapSet)
            {
                PrintLine();
                PrintLine('=');
                PrintLog("Checking Pak variables");
                PrintLine('=');
                PrintLine();

                str_Path_UE4Pak = Path.GetDirectoryName(Txt_UE4.Text) + @"\UnrealPak.exe";
                Console.WriteLine("Debug Path UE4 Pak: " + str_Path_UE4Pak);

                if (File.Exists(str_Path_UE4Pak))
                {
                    string ResponseDir = MWRef.str_Dir;
                    ResponseDir = ResponseDir.Replace(@"\", "/");
                    Console.WriteLine("Debug ResponseDir: " + ResponseDir);
                    //  / Saved / Cooked / WindowsNoEditor / Mordhau / Content / Mordhau / Maps / ADRingfort/*.*"

                    string projectDir = Path.GetDirectoryName(Txt_Proj.Text);
                    string str_response1 = projectDir.Replace(@"\", "/") + "/Saved/Cooked/WindowsNoEditor/Mordhau/Content/Mordhau/Maps/" + Txt_MapName.Text + "/*.*";
                    Console.WriteLine("Debug Response part1: " + str_response1);

                    string str_response2 = "../../../Mordhau/Content/Mordhau/Maps/" + Txt_MapName.Text + "/*.*";
                    Console.WriteLine("Debug Response part2: " + str_response2);

                    //write responsefile
                    System.IO.File.WriteAllText(str_Dir + @"\ResponseFile.txt", "\"" + str_response1 + "\" \"" + str_response2 + "\"");

                    //"%unrealPakPath%" "%localPakFolder%\%MapName%.pak" -Create=%dir%ResponseFile.txt -silent -compress >Packaging.log
                    if (Chk_Compress_Pak.Checked)
                        str_CMD_Pak = "\"" + Txt_Pak.Text + "\\" + Txt_MapName.Text + ".pak\" -Create=\"" + ResponseDir + "/ResponseFile.txt\" -silent -compress >Packaging.log";
                    else
                        str_CMD_Pak = "\"" + Txt_Pak.Text + "\\" + Txt_MapName.Text + ".pak\" -Create=\"" + ResponseDir + "/ResponseFile.txt\" -silent >Packaging.log";

                    Console.WriteLine("Debug PakCMD: " + str_CMD_Pak);

                    PrintLog("Pak command changed to:", LogFlag.Msg);
                    PrintLog(str_CMD_Pak, LogFlag.CMD);
                    PrintLine('_');
                }
                else
                {
                    PrintLog("UnrealPak not found in same folder as UnrealEditor.exe", LogFlag.Error);
                }
            }
            else
            {
            }
        }

        // utility
        private static void runCommand(string Filename, string cmdtxt, string comment = "Command Finished!")
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            SystemSounds.Question.Play();

            //Print log
            PrintLine();
            PrintLine('=');
            PrintLine();
            PrintLog("Running CMD");
            PrintLine();
            PrintLog(cmdtxt);
            PrintLine();
            PrintLine('=');
            PrintLine();

            //get current directory and root

            string currentDrive = Path.GetPathRoot(MWRef.str_Dir).Substring(0, 1);
            currentDrive = currentDrive + ":";

            string command = "\"" + Filename + "\" " + cmdtxt;
            //create process
            Process process = new Process();
            ProcessStartInfo proInfo = new ProcessStartInfo();
            //Path
            proInfo.WorkingDirectory = MWRef.str_Dir;

            //Initial execution

            proInfo.FileName = "cmd.exe";
            proInfo.Arguments = "/K " + currentDrive + "&&cd \"" + MWRef.str_Dir + " \"&& " + command + " &exit";
            proInfo.Verb = "runas";
            //hide window
            proInfo.UseShellExecute = true;
            proInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proInfo.CreateNoWindow = true;

            //logging
            proInfo.RedirectStandardInput = false;

            Console.WriteLine(currentDrive);
            Console.WriteLine(MWRef.str_Dir);
            Console.WriteLine(command);
            Console.WriteLine(proInfo.Arguments);

            process.StartInfo = proInfo;
            process.Start();
            process.WaitForExit();
            SystemSounds.Exclamation.Play();
            PrintLog(comment, LogFlag.Msg);

            watch.Stop();

            PrintLog($"Execution Time: {watch.ElapsedMilliseconds} ms", LogFlag.CMD);
            PrintLine();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings
            Settings.Default.WindowLocation = this.Location;

            // Save settings
            Settings.Default.Save();
        }

        private void btn_Build_Click(object sender, EventArgs e)
        {
            btn_Cook_Click(this, EventArgs.Empty);
            btn_Pak_Click(this, EventArgs.Empty);
            btn_Copy_Click(this, EventArgs.Empty);
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