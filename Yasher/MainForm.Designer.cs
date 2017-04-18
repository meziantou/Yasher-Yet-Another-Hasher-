namespace Yasher
{
    partial class MainForm
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
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.computeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.MD5_checkbox = new System.Windows.Forms.CheckBox();
            this.SHA1_checkbox = new System.Windows.Forms.CheckBox();
            this.SHA256_checkbox = new System.Windows.Forms.CheckBox();
            this.SHA384_checkbox = new System.Windows.Forms.CheckBox();
            this.SHA512_checkbox = new System.Windows.Forms.CheckBox();
            this.RIPEMD160_checkbox = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.percentProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.Location = new System.Drawing.Point(15, 149);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(438, 173);
            this.resultTextBox.TabIndex = 14;
            this.resultTextBox.Text = "";
            // 
            // computeButton
            // 
            this.computeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.computeButton.Location = new System.Drawing.Point(378, 64);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(75, 23);
            this.computeButton.TabIndex = 13;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Message:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "File:";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(378, 11);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(66, 66);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(306, 20);
            this.messageTextBox.TabIndex = 7;
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTextBox.Location = new System.Drawing.Point(66, 14);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(306, 20);
            this.fileTextBox.TabIndex = 8;
            // 
            // MD5_checkbox
            // 
            this.MD5_checkbox.AutoSize = true;
            this.MD5_checkbox.Checked = true;
            this.MD5_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MD5_checkbox.Location = new System.Drawing.Point(18, 92);
            this.MD5_checkbox.Name = "MD5_checkbox";
            this.MD5_checkbox.Size = new System.Drawing.Size(49, 17);
            this.MD5_checkbox.TabIndex = 16;
            this.MD5_checkbox.Tag = "MD5";
            this.MD5_checkbox.Text = "MD5";
            this.MD5_checkbox.UseVisualStyleBackColor = true;
            // 
            // SHA1_checkbox
            // 
            this.SHA1_checkbox.AutoSize = true;
            this.SHA1_checkbox.Location = new System.Drawing.Point(73, 92);
            this.SHA1_checkbox.Name = "SHA1_checkbox";
            this.SHA1_checkbox.Size = new System.Drawing.Size(54, 17);
            this.SHA1_checkbox.TabIndex = 17;
            this.SHA1_checkbox.Tag = "SHA1";
            this.SHA1_checkbox.Text = "SHA1";
            this.SHA1_checkbox.UseVisualStyleBackColor = true;
            // 
            // SHA256_checkbox
            // 
            this.SHA256_checkbox.AutoSize = true;
            this.SHA256_checkbox.Location = new System.Drawing.Point(133, 92);
            this.SHA256_checkbox.Name = "SHA256_checkbox";
            this.SHA256_checkbox.Size = new System.Drawing.Size(66, 17);
            this.SHA256_checkbox.TabIndex = 18;
            this.SHA256_checkbox.Tag = "SHA256";
            this.SHA256_checkbox.Text = "SHA256";
            this.SHA256_checkbox.UseVisualStyleBackColor = true;
            // 
            // SHA384_checkbox
            // 
            this.SHA384_checkbox.AutoSize = true;
            this.SHA384_checkbox.Location = new System.Drawing.Point(205, 92);
            this.SHA384_checkbox.Name = "SHA384_checkbox";
            this.SHA384_checkbox.Size = new System.Drawing.Size(66, 17);
            this.SHA384_checkbox.TabIndex = 19;
            this.SHA384_checkbox.Tag = "SHA384";
            this.SHA384_checkbox.Text = "SHA384";
            this.SHA384_checkbox.UseVisualStyleBackColor = true;
            // 
            // SHA512_checkbox
            // 
            this.SHA512_checkbox.AutoSize = true;
            this.SHA512_checkbox.Location = new System.Drawing.Point(277, 92);
            this.SHA512_checkbox.Name = "SHA512_checkbox";
            this.SHA512_checkbox.Size = new System.Drawing.Size(66, 17);
            this.SHA512_checkbox.TabIndex = 20;
            this.SHA512_checkbox.Tag = "SHA512";
            this.SHA512_checkbox.Text = "SHA512";
            this.SHA512_checkbox.UseVisualStyleBackColor = true;
            // 
            // RIPEMD160_checkbox
            // 
            this.RIPEMD160_checkbox.AutoSize = true;
            this.RIPEMD160_checkbox.Location = new System.Drawing.Point(349, 92);
            this.RIPEMD160_checkbox.Name = "RIPEMD160_checkbox";
            this.RIPEMD160_checkbox.Size = new System.Drawing.Size(86, 17);
            this.RIPEMD160_checkbox.TabIndex = 21;
            this.RIPEMD160_checkbox.Tag = "RIPEMD160";
            this.RIPEMD160_checkbox.Text = "RIPEMD160";
            this.RIPEMD160_checkbox.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(73, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 23);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Tag = "progressBar1";
            this.progressBar1.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(378, 115);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // percentProgressLabel
            // 
            this.percentProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.percentProgressLabel.Location = new System.Drawing.Point(30, 115);
            this.percentProgressLabel.Name = "percentProgressLabel";
            this.percentProgressLabel.Size = new System.Drawing.Size(35, 23);
            this.percentProgressLabel.TabIndex = 24;
            this.percentProgressLabel.Text = "XX%";
            this.percentProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.percentProgressLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.computeButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 332);
            this.Controls.Add(this.percentProgressLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RIPEMD160_checkbox);
            this.Controls.Add(this.SHA512_checkbox);
            this.Controls.Add(this.SHA384_checkbox);
            this.Controls.Add(this.SHA256_checkbox);
            this.Controls.Add(this.SHA1_checkbox);
            this.Controls.Add(this.MD5_checkbox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.fileTextBox);
            this.Name = "MainForm";
            this.Text = "Yasher 1.3";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.CheckBox MD5_checkbox;
        private System.Windows.Forms.CheckBox SHA1_checkbox;
        private System.Windows.Forms.CheckBox SHA256_checkbox;
        private System.Windows.Forms.CheckBox SHA384_checkbox;
        private System.Windows.Forms.CheckBox SHA512_checkbox;
        private System.Windows.Forms.CheckBox RIPEMD160_checkbox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label percentProgressLabel;

    }
}

