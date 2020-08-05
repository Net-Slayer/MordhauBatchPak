namespace MordhauBatchPak
{
    partial class MainWindow
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
            this.Txt_MapName = new System.Windows.Forms.TextBox();
            this.Chk_Compress_Cook = new System.Windows.Forms.CheckBox();
            this.Chk_Compress_Pak = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_path_Proj = new System.Windows.Forms.Button();
            this.btn_path_Pak = new System.Windows.Forms.Button();
            this.Txt_Proj = new System.Windows.Forms.TextBox();
            this.btn_path_Mount = new System.Windows.Forms.Button();
            this.btn_path_UE4 = new System.Windows.Forms.Button();
            this.Txt_Server = new System.Windows.Forms.TextBox();
            this.Txt_UE4 = new System.Windows.Forms.TextBox();
            this.btn_path_Server = new System.Windows.Forms.Button();
            this.Txt_Mount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Pak = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Cook = new System.Windows.Forms.Button();
            this.btn_Pak = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Build = new System.Windows.Forms.Button();
            this.ofd_UE4 = new System.Windows.Forms.OpenFileDialog();
            this.ofd_Proj = new System.Windows.Forms.OpenFileDialog();
            this.LogGrp = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.LogGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_MapName
            // 
            this.Txt_MapName.Location = new System.Drawing.Point(141, 12);
            this.Txt_MapName.Name = "Txt_MapName";
            this.Txt_MapName.Size = new System.Drawing.Size(166, 20);
            this.Txt_MapName.TabIndex = 17;
            // 
            // Chk_Compress_Cook
            // 
            this.Chk_Compress_Cook.AutoSize = true;
            this.Chk_Compress_Cook.Enabled = false;
            this.Chk_Compress_Cook.Location = new System.Drawing.Point(9, 46);
            this.Chk_Compress_Cook.Name = "Chk_Compress_Cook";
            this.Chk_Compress_Cook.Size = new System.Drawing.Size(145, 17);
            this.Chk_Compress_Cook.TabIndex = 22;
            this.Chk_Compress_Cook.Text = "Compress Cooking Stage";
            this.Chk_Compress_Cook.UseVisualStyleBackColor = true;
            this.Chk_Compress_Cook.CheckedChanged += new System.EventHandler(this.Chk_Compress_Cook_CheckedChanged);
            // 
            // Chk_Compress_Pak
            // 
            this.Chk_Compress_Pak.AutoSize = true;
            this.Chk_Compress_Pak.Enabled = false;
            this.Chk_Compress_Pak.Location = new System.Drawing.Point(9, 70);
            this.Chk_Compress_Pak.Name = "Chk_Compress_Pak";
            this.Chk_Compress_Pak.Size = new System.Drawing.Size(145, 17);
            this.Chk_Compress_Pak.TabIndex = 23;
            this.Chk_Compress_Pak.Text = "Compress Pakking Stage";
            this.Chk_Compress_Pak.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Map Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Chk_Compress_Pak);
            this.groupBox2.Controls.Add(this.Chk_Compress_Cook);
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 104);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compression Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Note: Compression increases cook time";
            // 
            // btn_path_Proj
            // 
            this.btn_path_Proj.Location = new System.Drawing.Point(301, 49);
            this.btn_path_Proj.Name = "btn_path_Proj";
            this.btn_path_Proj.Size = new System.Drawing.Size(28, 23);
            this.btn_path_Proj.TabIndex = 14;
            this.btn_path_Proj.Text = "...";
            this.btn_path_Proj.UseVisualStyleBackColor = true;
            this.btn_path_Proj.Click += new System.EventHandler(this.btn_path_Proj_Click);
            // 
            // btn_path_Pak
            // 
            this.btn_path_Pak.Location = new System.Drawing.Point(301, 78);
            this.btn_path_Pak.Name = "btn_path_Pak";
            this.btn_path_Pak.Size = new System.Drawing.Size(28, 23);
            this.btn_path_Pak.TabIndex = 16;
            this.btn_path_Pak.Text = "...";
            this.btn_path_Pak.UseVisualStyleBackColor = true;
            this.btn_path_Pak.Click += new System.EventHandler(this.btn_path_Pak_Click);
            // 
            // Txt_Proj
            // 
            this.Txt_Proj.Location = new System.Drawing.Point(129, 52);
            this.Txt_Proj.Name = "Txt_Proj";
            this.Txt_Proj.Size = new System.Drawing.Size(166, 20);
            this.Txt_Proj.TabIndex = 13;
            this.Txt_Proj.Text = "F:\\documents\\Unreal Projects\\Mordhau\\Mordhau\\mordhau.uproject";
            this.Txt_Proj.TextChanged += new System.EventHandler(this.Txt_Proj_TextChanged);
            // 
            // btn_path_Mount
            // 
            this.btn_path_Mount.Location = new System.Drawing.Point(301, 33);
            this.btn_path_Mount.Name = "btn_path_Mount";
            this.btn_path_Mount.Size = new System.Drawing.Size(28, 23);
            this.btn_path_Mount.TabIndex = 19;
            this.btn_path_Mount.Text = "...";
            this.btn_path_Mount.UseVisualStyleBackColor = true;
            this.btn_path_Mount.Click += new System.EventHandler(this.btn_path_Mount_Click);
            // 
            // btn_path_UE4
            // 
            this.btn_path_UE4.Location = new System.Drawing.Point(301, 21);
            this.btn_path_UE4.Name = "btn_path_UE4";
            this.btn_path_UE4.Size = new System.Drawing.Size(28, 23);
            this.btn_path_UE4.TabIndex = 12;
            this.btn_path_UE4.Text = "...";
            this.btn_path_UE4.UseVisualStyleBackColor = true;
            this.btn_path_UE4.Click += new System.EventHandler(this.btn_path_UE4_Click);
            // 
            // Txt_Server
            // 
            this.Txt_Server.Location = new System.Drawing.Point(129, 65);
            this.Txt_Server.Name = "Txt_Server";
            this.Txt_Server.Size = new System.Drawing.Size(166, 20);
            this.Txt_Server.TabIndex = 20;
            // 
            // Txt_UE4
            // 
            this.Txt_UE4.Location = new System.Drawing.Point(129, 23);
            this.Txt_UE4.Name = "Txt_UE4";
            this.Txt_UE4.Size = new System.Drawing.Size(166, 20);
            this.Txt_UE4.TabIndex = 11;
            this.Txt_UE4.Text = "E:\\Epic\\UE_4.20\\Engine\\Binaries\\Win64\\UE4Editor.exe";
            this.Txt_UE4.TextChanged += new System.EventHandler(this.Txt_UE4_TextChanged);
            // 
            // btn_path_Server
            // 
            this.btn_path_Server.Location = new System.Drawing.Point(301, 62);
            this.btn_path_Server.Name = "btn_path_Server";
            this.btn_path_Server.Size = new System.Drawing.Size(28, 23);
            this.btn_path_Server.TabIndex = 21;
            this.btn_path_Server.Text = "...";
            this.btn_path_Server.UseVisualStyleBackColor = true;
            this.btn_path_Server.Click += new System.EventHandler(this.btn_path_Server_Click);
            // 
            // Txt_Mount
            // 
            this.Txt_Mount.Location = new System.Drawing.Point(129, 36);
            this.Txt_Mount.Name = "Txt_Mount";
            this.Txt_Mount.Size = new System.Drawing.Size(166, 20);
            this.Txt_Mount.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "UE4Editor.exe Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "uProject Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Temporary Pak Folder";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txt_UE4);
            this.groupBox1.Controls.Add(this.btn_path_UE4);
            this.groupBox1.Controls.Add(this.Txt_Proj);
            this.groupBox1.Controls.Add(this.btn_path_Pak);
            this.groupBox1.Controls.Add(this.btn_path_Proj);
            this.groupBox1.Controls.Add(this.Txt_Pak);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 115);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paths";
            // 
            // Txt_Pak
            // 
            this.Txt_Pak.Location = new System.Drawing.Point(129, 81);
            this.Txt_Pak.Name = "Txt_Pak";
            this.Txt_Pak.Size = new System.Drawing.Size(166, 20);
            this.Txt_Pak.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Mounting Folder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Server Folder";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btn_path_Mount);
            this.groupBox3.Controls.Add(this.Txt_Server);
            this.groupBox3.Controls.Add(this.btn_path_Server);
            this.groupBox3.Controls.Add(this.Txt_Mount);
            this.groupBox3.Location = new System.Drawing.Point(12, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 100);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Copy to Folders (optional) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(331, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Note: This should be the name of the map folder that your .umap is in";
            // 
            // btn_Cook
            // 
            this.btn_Cook.Location = new System.Drawing.Point(12, 415);
            this.btn_Cook.Name = "btn_Cook";
            this.btn_Cook.Size = new System.Drawing.Size(89, 37);
            this.btn_Cook.TabIndex = 22;
            this.btn_Cook.Text = "Cook Only";
            this.btn_Cook.UseVisualStyleBackColor = true;
            this.btn_Cook.Click += new System.EventHandler(this.btn_Cook_Click);
            // 
            // btn_Pak
            // 
            this.btn_Pak.Enabled = false;
            this.btn_Pak.Location = new System.Drawing.Point(141, 415);
            this.btn_Pak.Name = "btn_Pak";
            this.btn_Pak.Size = new System.Drawing.Size(89, 37);
            this.btn_Pak.TabIndex = 22;
            this.btn_Pak.Text = "Pak Only";
            this.btn_Pak.UseVisualStyleBackColor = true;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Enabled = false;
            this.btn_Copy.Location = new System.Drawing.Point(263, 415);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(89, 37);
            this.btn_Copy.TabIndex = 22;
            this.btn_Copy.Text = "Copy Only";
            this.btn_Copy.UseVisualStyleBackColor = true;
            // 
            // btn_Build
            // 
            this.btn_Build.Enabled = false;
            this.btn_Build.Location = new System.Drawing.Point(12, 473);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(340, 37);
            this.btn_Build.TabIndex = 22;
            this.btn_Build.Text = "Cook, Pak and Copy!";
            this.btn_Build.UseVisualStyleBackColor = true;
            // 
            // ofd_UE4
            // 
            this.ofd_UE4.DefaultExt = "exe";
            this.ofd_UE4.FileName = "UE4Editor.exe";
            this.ofd_UE4.Filter = "Exe Files|*.exe";
            this.ofd_UE4.Title = "Find UE4Editor.exe";
            // 
            // ofd_Proj
            // 
            this.ofd_Proj.DefaultExt = "exe";
            this.ofd_Proj.FileName = "Mordhau.uproject";
            this.ofd_Proj.Filter = "Unreal Project Files|*.uproject";
            this.ofd_Proj.Title = "Find UE4Editor.exe";
            // 
            // LogGrp
            // 
            this.LogGrp.Controls.Add(this.LogBox);
            this.LogGrp.Location = new System.Drawing.Point(358, 12);
            this.LogGrp.Margin = new System.Windows.Forms.Padding(10);
            this.LogGrp.Name = "LogGrp";
            this.LogGrp.Size = new System.Drawing.Size(318, 498);
            this.LogGrp.TabIndex = 24;
            this.LogGrp.TabStop = false;
            this.LogGrp.Text = "Log";
            // 
            // LogBox
            // 
            this.LogBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.Location = new System.Drawing.Point(6, 19);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(306, 473);
            this.LogBox.TabIndex = 24;
            this.LogBox.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(688, 521);
            this.Controls.Add(this.LogGrp);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.btn_Pak);
            this.Controls.Add(this.btn_Build);
            this.Controls.Add(this.btn_Cook);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Txt_MapName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(704, 560);
            this.MinimumSize = new System.Drawing.Size(704, 560);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NetSlayer\'s Mordhau build tool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.LogGrp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txt_MapName;
        private System.Windows.Forms.CheckBox Chk_Compress_Pak;
        private System.Windows.Forms.CheckBox Chk_Compress_Cook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_path_Proj;
        private System.Windows.Forms.Button btn_path_Pak;
        private System.Windows.Forms.TextBox Txt_Proj;
        private System.Windows.Forms.Button btn_path_Mount;
        private System.Windows.Forms.Button btn_path_UE4;
        private System.Windows.Forms.TextBox Txt_Server;
        private System.Windows.Forms.TextBox Txt_UE4;
        private System.Windows.Forms.Button btn_path_Server;
        private System.Windows.Forms.TextBox Txt_Mount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Pak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Cook;
        private System.Windows.Forms.Button btn_Pak;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.OpenFileDialog ofd_UE4;
        private System.Windows.Forms.OpenFileDialog ofd_Proj;
        private System.Windows.Forms.GroupBox LogGrp;
        private System.Windows.Forms.RichTextBox LogBox;
    }
}

