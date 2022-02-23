﻿
namespace Gameboy_Visual_Gui
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxBefore = new System.Windows.Forms.PictureBox();
            this.pictureBoxAfter = new System.Windows.Forms.PictureBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxNoise = new System.Windows.Forms.CheckBox();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.helpToolStripMenuItem.Text = "?";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem2.Text = "Github Page";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBoxBefore
            // 
            this.pictureBoxBefore.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBefore.Location = new System.Drawing.Point(53, 58);
            this.pictureBoxBefore.Name = "pictureBoxBefore";
            this.pictureBoxBefore.Size = new System.Drawing.Size(400, 360);
            this.pictureBoxBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBefore.TabIndex = 1;
            this.pictureBoxBefore.TabStop = false;
            // 
            // pictureBoxAfter
            // 
            this.pictureBoxAfter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAfter.Location = new System.Drawing.Point(507, 58);
            this.pictureBoxAfter.Name = "pictureBoxAfter";
            this.pictureBoxAfter.Size = new System.Drawing.Size(400, 360);
            this.pictureBoxAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAfter.TabIndex = 2;
            this.pictureBoxAfter.TabStop = false;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(194, 447);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(94, 29);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(660, 447);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxNoise
            // 
            this.checkBoxNoise.AutoSize = true;
            this.checkBoxNoise.Location = new System.Drawing.Point(507, 450);
            this.checkBoxNoise.Name = "checkBoxNoise";
            this.checkBoxNoise.Size = new System.Drawing.Size(98, 24);
            this.checkBoxNoise.TabIndex = 5;
            this.checkBoxNoise.Text = "with noise";
            this.checkBoxNoise.UseVisualStyleBackColor = true;
            this.checkBoxNoise.CheckedChanged += new System.EventHandler(this.checkBoxNoise_CheckedChanged);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 505);
            this.Controls.Add(this.checkBoxNoise);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.pictureBoxAfter);
            this.Controls.Add(this.pictureBoxBefore);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Gameboy_Visual";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxBefore;
        private System.Windows.Forms.PictureBox pictureBoxAfter;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxNoise;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}
