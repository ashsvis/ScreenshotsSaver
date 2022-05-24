namespace ScreenshotsSaver
{
    partial class BorderSelectorForm
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
            this.SuspendLayout();
            // 
            // BorderSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 446);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorderSelectorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BorderSelectorForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderSelectorForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BorderSelectorForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BorderSelectorForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BorderSelectorForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BorderSelectorForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}