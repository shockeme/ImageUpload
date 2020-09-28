﻿namespace ImageUpload
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.pictureContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateImageLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.SaveDirectory = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.HTMLFiles = new System.Windows.Forms.TextBox();
            this.Drive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Remove = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Images";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 471);
            this.panel1.TabIndex = 5;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // pictureContextMenu
            // 
            this.pictureContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureContextMenuToolStripMenuItem,
            this.rotateImageLeftToolStripMenuItem});
            this.pictureContextMenu.Name = "pictureContextMenu";
            this.pictureContextMenu.Size = new System.Drawing.Size(176, 48);
            // 
            // pictureContextMenuToolStripMenuItem
            // 
            this.pictureContextMenuToolStripMenuItem.Name = "pictureContextMenuToolStripMenuItem";
            this.pictureContextMenuToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.pictureContextMenuToolStripMenuItem.Text = "Rotate Image Right";
            // 
            // rotateImageLeftToolStripMenuItem
            // 
            this.rotateImageLeftToolStripMenuItem.Name = "rotateImageLeftToolStripMenuItem";
            this.rotateImageLeftToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.rotateImageLeftToolStripMenuItem.Text = "Rotate Image Left";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveDirectory
            // 
            this.SaveDirectory.Location = new System.Drawing.Point(56, 516);
            this.SaveDirectory.Name = "SaveDirectory";
            this.SaveDirectory.Size = new System.Drawing.Size(287, 20);
            this.SaveDirectory.TabIndex = 8;
            this.SaveDirectory.Text = "/httpdocs/SMKKJ/images/";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Clear Images";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // HTMLFiles
            // 
            this.HTMLFiles.Location = new System.Drawing.Point(56, 542);
            this.HTMLFiles.Name = "HTMLFiles";
            this.HTMLFiles.Size = new System.Drawing.Size(287, 20);
            this.HTMLFiles.TabIndex = 10;
            this.HTMLFiles.Text = "/httpdocs/SMKKJ/Days/";
            // 
            // Drive
            // 
            this.Drive.Location = new System.Drawing.Point(56, 489);
            this.Drive.Name = "Drive";
            this.Drive.Size = new System.Drawing.Size(24, 20);
            this.Drive.TabIndex = 11;
            this.Drive.Text = "w:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Drive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Images";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 545);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "HTML";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(293, 502);
            this.textBox1.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(222, 407);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Change Month";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(222, 384);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(121, 17);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Upload Images Only";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "No Images Loaded";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(356, 539);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 18);
            this.progressBar1.TabIndex = 20;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(56, 567);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(287, 20);
            this.Remove.TabIndex = 21;
            this.Remove.Text = "/httpdocs/SMKKJ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 567);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Remove";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(222, 431);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(101, 17);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "Backup Months";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 589);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Drive);
            this.Controls.Add(this.HTMLFiles);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SaveDirectory);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Image Uploader";
            this.pictureContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ContextMenuStrip pictureContextMenu;
        private System.Windows.Forms.ToolStripMenuItem pictureContextMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateImageLeftToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SaveDirectory;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox HTMLFiles;
        private System.Windows.Forms.TextBox Drive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox Remove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}
