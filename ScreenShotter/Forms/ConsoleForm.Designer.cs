namespace ScreenShotter
{
    partial class ConsoleForm
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
            this.ConsoleText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConsoleText
            // 
            this.ConsoleText.BackColor = System.Drawing.SystemColors.Control;
            this.ConsoleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleText.Location = new System.Drawing.Point(-3, -2);
            this.ConsoleText.Multiline = true;
            this.ConsoleText.Name = "ConsoleText";
            this.ConsoleText.ReadOnly = true;
            this.ConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleText.Size = new System.Drawing.Size(525, 274);
            this.ConsoleText.TabIndex = 0;
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(520, 269);
            this.Controls.Add(this.ConsoleText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::ScreenShotter.Properties.Resources.ConsoleIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsoleForm";
            this.Text = "ScreenShotter Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleForm_FormClosing);
            this.Load += new System.EventHandler(this.ConsoleForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.ConsoleForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ConsoleText;


    }
}