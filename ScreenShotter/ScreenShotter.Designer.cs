namespace ScreenShotter
{
    partial class ScreenShotter
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenShotter));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SasLabel = new System.Windows.Forms.Label();
            this.spButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.ttButton = new System.Windows.Forms.Button();
            this.consButton = new System.Windows.Forms.Button();
            this.confButton = new System.Windows.Forms.Button();
            this.lstButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(24, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SasLabel
            // 
            this.SasLabel.AutoEllipsis = true;
            this.SasLabel.Location = new System.Drawing.Point(3, 216);
            this.SasLabel.MaximumSize = new System.Drawing.Size(290, 30);
            this.SasLabel.Name = "SasLabel";
            this.SasLabel.Size = new System.Drawing.Size(290, 26);
            this.SasLabel.TabIndex = 1;
            this.SasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spButton
            // 
            this.spButton.BackColor = System.Drawing.Color.Transparent;
            this.spButton.FlatAppearance.BorderSize = 0;
            this.spButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.spButton.Location = new System.Drawing.Point(158, 42);
            this.spButton.Name = "spButton";
            this.spButton.Size = new System.Drawing.Size(106, 23);
            this.spButton.TabIndex = 3;
            this.spButton.Text = "Select folder";
            this.spButton.UseVisualStyleBackColor = false;
            this.spButton.Click += new System.EventHandler(this.spButton_Click);
            this.spButton.MouseHover += new System.EventHandler(this.spButton_MouseHover);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoEllipsis = true;
            this.pathLabel.Location = new System.Drawing.Point(3, -1);
            this.pathLabel.MaximumSize = new System.Drawing.Size(290, 40);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(290, 40);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "path";
            this.pathLabel.MouseHover += new System.EventHandler(this.pathLabel_MouseHover);
            // 
            // ttButton
            // 
            this.ttButton.BackColor = System.Drawing.Color.Transparent;
            this.ttButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ttButton.FlatAppearance.BorderSize = 0;
            this.ttButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ttButton.Location = new System.Drawing.Point(25, 42);
            this.ttButton.Name = "ttButton";
            this.ttButton.Size = new System.Drawing.Size(128, 23);
            this.ttButton.TabIndex = 5;
            this.ttButton.Text = "Tray Icon";
            this.ttButton.UseVisualStyleBackColor = false;
            this.ttButton.Click += new System.EventHandler(this.ttButton_Click);
            this.ttButton.MouseHover += new System.EventHandler(this.ttButton_MouseHover);
            // 
            // consButton
            // 
            this.consButton.BackColor = System.Drawing.Color.Transparent;
            this.consButton.FlatAppearance.BorderSize = 0;
            this.consButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.consButton.Location = new System.Drawing.Point(267, 182);
            this.consButton.Name = "consButton";
            this.consButton.Size = new System.Drawing.Size(23, 24);
            this.consButton.TabIndex = 6;
            this.consButton.Text = ">";
            this.consButton.UseVisualStyleBackColor = false;
            this.consButton.Click += new System.EventHandler(this.consButton_Click);
            this.consButton.MouseHover += new System.EventHandler(this.consButton_MouseHover);
            // 
            // confButton
            // 
            this.confButton.BackColor = System.Drawing.Color.Transparent;
            this.confButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.confButton.FlatAppearance.BorderSize = 0;
            this.confButton.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.confButton.Location = new System.Drawing.Point(267, 243);
            this.confButton.Name = "confButton";
            this.confButton.Size = new System.Drawing.Size(23, 24);
            this.confButton.TabIndex = 7;
            this.confButton.Text = "@";
            this.confButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.confButton.UseVisualStyleBackColor = false;
            this.confButton.Click += new System.EventHandler(this.confButton_Click);
            this.confButton.MouseHover += new System.EventHandler(this.confButton_MouseHover);
            // 
            // lstButton
            // 
            this.lstButton.BackColor = System.Drawing.Color.Transparent;
            this.lstButton.FlatAppearance.BorderSize = 0;
            this.lstButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lstButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstButton.Location = new System.Drawing.Point(104, 244);
            this.lstButton.Name = "lstButton";
            this.lstButton.Size = new System.Drawing.Size(160, 23);
            this.lstButton.TabIndex = 8;
            this.lstButton.Text = "Open last Screenshot";
            this.lstButton.UseVisualStyleBackColor = false;
            this.lstButton.Click += new System.EventHandler(this.lstButton_Click);
            this.lstButton.MouseHover += new System.EventHandler(this.lstButton_MouseHover);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.White;
            this.toolTip.ForeColor = System.Drawing.Color.Black;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Info.Location = new System.Drawing.Point(271, -3);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(19, 17);
            this.Info.TabIndex = 9;
            this.Info.Text = "s";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            this.Info.MouseHover += new System.EventHandler(this.Info_MouseHover);
            // 
            // ScreenShotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.lstButton);
            this.Controls.Add(this.confButton);
            this.Controls.Add(this.consButton);
            this.Controls.Add(this.ttButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.spButton);
            this.Controls.Add(this.SasLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenShotter";
            this.Text = "ScreenShotter";
            this.Activated += new System.EventHandler(this.ScreenShotter_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenShotterMain_FormClosing);
            this.Load += new System.EventHandler(this.ScreenShotterMain_Load);
            this.Move += new System.EventHandler(this.ScreenShotter_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SasLabel;
        private System.Windows.Forms.Button spButton;
        private System.Windows.Forms.Label pathLabel;
        public System.Windows.Forms.Button ttButton;
        private System.Windows.Forms.Button consButton;
        private System.Windows.Forms.Button confButton;
        private System.Windows.Forms.Button lstButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label Info;
    }
}

