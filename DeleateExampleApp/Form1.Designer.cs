using System.Windows.Forms;

namespace DeleateExampleApp
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
            this.btnTestGet = new System.Windows.Forms.Button();
            this.btnTestPost = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestGet
            // 
            this.btnTestGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestGet.Location = new System.Drawing.Point(153, 69);
            this.btnTestGet.Name = "btnTestGet";
            this.btnTestGet.Size = new System.Drawing.Size(472, 93);
            this.btnTestGet.TabIndex = 0;
            this.btnTestGet.Text = "Test GET Method";
            this.btnTestGet.UseVisualStyleBackColor = true;
            this.btnTestGet.Click += new System.EventHandler(this.btnTestGet_Click);
            // 
            // btnTestPost
            // 
            this.btnTestPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestPost.Location = new System.Drawing.Point(153, 186);
            this.btnTestPost.Name = "btnTestPost";
            this.btnTestPost.Size = new System.Drawing.Size(472, 107);
            this.btnTestPost.TabIndex = 1;
            this.btnTestPost.Text = "Test POST Method";
            this.btnTestPost.UseVisualStyleBackColor = true;
            this.btnTestPost.Click += new System.EventHandler(this.btnTestPost_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(472, 91);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTestPost);
            this.Controls.Add(this.btnTestGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestGet;
        private System.Windows.Forms.Button btnTestPost;
        private Button button1;
    }
}

