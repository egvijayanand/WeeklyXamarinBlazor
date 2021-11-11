
namespace BlazorApp.WinForms
{
    partial class WebForm
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
            this.img = new System.Windows.Forms.PictureBox();
            this.container = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.Image = global::BlazorApp.WinForms.Properties.Resources.Splash;
            this.img.Location = new System.Drawing.Point(337, 127);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(128, 128);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // container
            // 
            this.container.Controls.Add(this.img);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(800, 450);
            this.container.TabIndex = 1;
            // 
            // WebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "WebForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebForm_FormClosing);
            this.Load += new System.EventHandler(this.WebForm_Load);
            this.Resize += new System.EventHandler(this.WebForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Panel container;
    }
}