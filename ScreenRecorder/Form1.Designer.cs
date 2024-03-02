namespace ScreenRecorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.file_toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.recordScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecordScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleMicRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.micRecording_label1 = new System.Windows.Forms.Label();
            this.Capturing_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(278, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // file_toolStripDropDownButton1
            // 
            this.file_toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.file_toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordScreenToolStripMenuItem,
            this.stopRecordScreenToolStripMenuItem,
            this.toggleMicRecordToolStripMenuItem,
            this.testToolStripMenuItem});
            this.file_toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("file_toolStripDropDownButton1.Image")));
            this.file_toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.file_toolStripDropDownButton1.Name = "file_toolStripDropDownButton1";
            this.file_toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.file_toolStripDropDownButton1.Text = "File";
            // 
            // recordScreenToolStripMenuItem
            // 
            this.recordScreenToolStripMenuItem.Name = "recordScreenToolStripMenuItem";
            this.recordScreenToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.recordScreenToolStripMenuItem.Text = "Start Capture";
            this.recordScreenToolStripMenuItem.Click += new System.EventHandler(this.recordScreenToolStripMenuItem_Click_1);
            // 
            // stopRecordScreenToolStripMenuItem
            // 
            this.stopRecordScreenToolStripMenuItem.Name = "stopRecordScreenToolStripMenuItem";
            this.stopRecordScreenToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.stopRecordScreenToolStripMenuItem.Text = "Stop Capture";
            this.stopRecordScreenToolStripMenuItem.Click += new System.EventHandler(this.stopRecordScreenToolStripMenuItem_Click);
            // 
            // toggleMicRecordToolStripMenuItem
            // 
            this.toggleMicRecordToolStripMenuItem.Name = "toggleMicRecordToolStripMenuItem";
            this.toggleMicRecordToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.toggleMicRecordToolStripMenuItem.Text = "Toggle Mic Capture";
            this.toggleMicRecordToolStripMenuItem.Click += new System.EventHandler(this.toggleMicRecordToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.testToolStripMenuItem.Text = "Itch";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // micRecording_label1
            // 
            this.micRecording_label1.AutoSize = true;
            this.micRecording_label1.Location = new System.Drawing.Point(12, 54);
            this.micRecording_label1.Name = "micRecording_label1";
            this.micRecording_label1.Size = new System.Drawing.Size(93, 13);
            this.micRecording_label1.TabIndex = 1;
            this.micRecording_label1.Text = "Mic Recording On";
            // 
            // Capturing_label
            // 
            this.Capturing_label.AutoSize = true;
            this.Capturing_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Capturing_label.Location = new System.Drawing.Point(12, 30);
            this.Capturing_label.Name = "Capturing_label";
            this.Capturing_label.Size = new System.Drawing.Size(61, 13);
            this.Capturing_label.TabIndex = 2;
            this.Capturing_label.Text = "Capturing";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "v0.2.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Records one audio source and screen at same time.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 108);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Capturing_label);
            this.Controls.Add(this.micRecording_label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Recorder";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton file_toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem recordScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRecordScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleMicRecordToolStripMenuItem;
        private System.Windows.Forms.Label micRecording_label1;
        private System.Windows.Forms.Label Capturing_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}

