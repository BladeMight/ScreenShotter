namespace ScreenShotter
{
    partial class Configs
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
            this.consCheckbox = new System.Windows.Forms.CheckBox();
            this.TTCheckbox = new System.Windows.Forms.CheckBox();
            this.TooltipCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.XCheckbox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sfLabel = new System.Windows.Forms.Label();
            this.dfltButton = new System.Windows.Forms.Button();
            this.jpgLabel = new System.Windows.Forms.Label();
            this.jpgQualityBox = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.langLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // consCheckbox
            // 
            this.consCheckbox.AutoSize = true;
            this.consCheckbox.Location = new System.Drawing.Point(13, 13);
            this.consCheckbox.Name = "consCheckbox";
            this.consCheckbox.Size = new System.Drawing.Size(214, 17);
            this.consCheckbox.TabIndex = 0;
            this.consCheckbox.Text = "Display Console Button in Main Window";
            this.consCheckbox.UseVisualStyleBackColor = true;
            this.consCheckbox.CheckedChanged += new System.EventHandler(this.consCheckbox_CheckedChanged);
            this.consCheckbox.MouseHover += new System.EventHandler(this.consCheckbox_MouseHover);
            // 
            // TTCheckbox
            // 
            this.TTCheckbox.AutoSize = true;
            this.TTCheckbox.Location = new System.Drawing.Point(13, 37);
            this.TTCheckbox.Name = "TTCheckbox";
            this.TTCheckbox.Size = new System.Drawing.Size(278, 17);
            this.TTCheckbox.TabIndex = 1;
            this.TTCheckbox.Text = "Display Tray Icon Show/Hide Button in Main Window";
            this.TTCheckbox.UseVisualStyleBackColor = true;
            this.TTCheckbox.CheckedChanged += new System.EventHandler(this.TTCheckbox_CheckedChanged);
            this.TTCheckbox.MouseHover += new System.EventHandler(this.TTCheckbox_MouseHover);
            // 
            // TooltipCheckbox
            // 
            this.TooltipCheckbox.AutoSize = true;
            this.TooltipCheckbox.Location = new System.Drawing.Point(13, 60);
            this.TooltipCheckbox.Name = "TooltipCheckbox";
            this.TooltipCheckbox.Size = new System.Drawing.Size(283, 17);
            this.TooltipCheckbox.TabIndex = 2;
            this.TooltipCheckbox.Text = "Display Tooltips when hover elements in Main Window";
            this.TooltipCheckbox.UseVisualStyleBackColor = true;
            this.TooltipCheckbox.CheckedChanged += new System.EventHandler(this.TooltipCheckbox_CheckedChanged);
            this.TooltipCheckbox.MouseHover += new System.EventHandler(this.TooltipCheckbox_MouseHover);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(13, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(205, 134);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // XCheckbox
            // 
            this.XCheckbox.AutoSize = true;
            this.XCheckbox.Location = new System.Drawing.Point(13, 83);
            this.XCheckbox.Name = "XCheckbox";
            this.XCheckbox.Size = new System.Drawing.Size(145, 17);
            this.XCheckbox.TabIndex = 6;
            this.XCheckbox.Text = "Closing will end program?";
            this.XCheckbox.UseVisualStyleBackColor = true;
            this.XCheckbox.CheckedChanged += new System.EventHandler(this.XCheckbox_CheckedChanged);
            this.XCheckbox.MouseHover += new System.EventHandler(this.XCheckbox_MouseHover);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "BMP",
            "GIF"});
            this.comboBox1.Location = new System.Drawing.Point(124, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(47, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sfLabel
            // 
            this.sfLabel.AutoSize = true;
            this.sfLabel.Location = new System.Drawing.Point(10, 107);
            this.sfLabel.Name = "sfLabel";
            this.sfLabel.Size = new System.Drawing.Size(75, 13);
            this.sfLabel.TabIndex = 8;
            this.sfLabel.Text = "Saving format:";
            this.sfLabel.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // dfltButton
            // 
            this.dfltButton.FlatAppearance.BorderSize = 0;
            this.dfltButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dfltButton.Location = new System.Drawing.Point(110, 134);
            this.dfltButton.Name = "dfltButton";
            this.dfltButton.Size = new System.Drawing.Size(75, 23);
            this.dfltButton.TabIndex = 9;
            this.dfltButton.Text = "Default";
            this.dfltButton.UseVisualStyleBackColor = true;
            this.dfltButton.Click += new System.EventHandler(this.dfltButton_Click);
            // 
            // jpgLabel
            // 
            this.jpgLabel.AutoSize = true;
            this.jpgLabel.Location = new System.Drawing.Point(172, 107);
            this.jpgLabel.Name = "jpgLabel";
            this.jpgLabel.Size = new System.Drawing.Size(65, 13);
            this.jpgLabel.TabIndex = 10;
            this.jpgLabel.Text = "JPG Quality:";
            // 
            // jpgQualityBox
            // 
            this.jpgQualityBox.Location = new System.Drawing.Point(261, 104);
            this.jpgQualityBox.Name = "jpgQualityBox";
            this.jpgQualityBox.Size = new System.Drawing.Size(30, 20);
            this.jpgQualityBox.TabIndex = 11;
            this.jpgQualityBox.TextChanged += new System.EventHandler(this.jpgQualityBox_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.comboBox2.Location = new System.Drawing.Point(225, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(66, 21);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.MouseHover += new System.EventHandler(this.comboBox2_MouseHover);
            // 
            // langLabel
            // 
            this.langLabel.Location = new System.Drawing.Point(168, 85);
            this.langLabel.Name = "langLabel";
            this.langLabel.Size = new System.Drawing.Size(55, 15);
            this.langLabel.TabIndex = 13;
            this.langLabel.Text = "Language";
            this.langLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Configs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 165);
            this.Controls.Add(this.langLabel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.jpgQualityBox);
            this.Controls.Add(this.jpgLabel);
            this.Controls.Add(this.dfltButton);
            this.Controls.Add(this.sfLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.XCheckbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TooltipCheckbox);
            this.Controls.Add(this.TTCheckbox);
            this.Controls.Add(this.consCheckbox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::ScreenShotter.Properties.Resources.Configs;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configs";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configs_FormClosing);
            this.Load += new System.EventHandler(this.Configs_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox consCheckbox;
        private System.Windows.Forms.CheckBox TTCheckbox;
        private System.Windows.Forms.CheckBox TooltipCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox XCheckbox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label sfLabel;
        private System.Windows.Forms.Button dfltButton;
        private System.Windows.Forms.Label jpgLabel;
        private System.Windows.Forms.TextBox jpgQualityBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label langLabel;
    }
}