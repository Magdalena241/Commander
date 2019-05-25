namespace lab_2_B
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
            this.moveToRight = new System.Windows.Forms.Button();
            this.moveToLeft = new System.Windows.Forms.Button();
            this.copyToRight = new System.Windows.Forms.Button();
            this.copyToLeft = new System.Windows.Forms.Button();
            this.mInTCPanel2 = new lab_2_B.MInTCPanel();
            this.mInTCPanel1 = new lab_2_B.MInTCPanel();
            this.SuspendLayout();
            // 
            // moveToRight
            // 
            this.moveToRight.Location = new System.Drawing.Point(214, 105);
            this.moveToRight.Name = "moveToRight";
            this.moveToRight.Size = new System.Drawing.Size(75, 23);
            this.moveToRight.TabIndex = 2;
            this.moveToRight.Text = "Move ->";
            this.moveToRight.UseVisualStyleBackColor = true;
            this.moveToRight.Click += new System.EventHandler(this.moveToRight_Click);
            // 
            // moveToLeft
            // 
            this.moveToLeft.Location = new System.Drawing.Point(214, 134);
            this.moveToLeft.Name = "moveToLeft";
            this.moveToLeft.Size = new System.Drawing.Size(75, 23);
            this.moveToLeft.TabIndex = 3;
            this.moveToLeft.Text = "<- Move";
            this.moveToLeft.UseVisualStyleBackColor = true;
            this.moveToLeft.Click += new System.EventHandler(this.moveToLeft_Click);
            // 
            // copyToRight
            // 
            this.copyToRight.Location = new System.Drawing.Point(214, 163);
            this.copyToRight.Name = "copyToRight";
            this.copyToRight.Size = new System.Drawing.Size(75, 23);
            this.copyToRight.TabIndex = 4;
            this.copyToRight.Text = "Copy ->";
            this.copyToRight.UseVisualStyleBackColor = true;
            this.copyToRight.Click += new System.EventHandler(this.copyToRight_Click);
            // 
            // copyToLeft
            // 
            this.copyToLeft.Location = new System.Drawing.Point(214, 192);
            this.copyToLeft.Name = "copyToLeft";
            this.copyToLeft.Size = new System.Drawing.Size(75, 23);
            this.copyToLeft.TabIndex = 5;
            this.copyToLeft.Text = "<- Copy";
            this.copyToLeft.UseVisualStyleBackColor = true;
            this.copyToLeft.Click += new System.EventHandler(this.copyToLeft_Click);
            // 
            // mInTCPanel2
            // 
            this.mInTCPanel2.CurrentPath = "";
            this.mInTCPanel2.Location = new System.Drawing.Point(294, 10);
            this.mInTCPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.mInTCPanel2.Name = "mInTCPanel2";
            this.mInTCPanel2.Size = new System.Drawing.Size(200, 313);
            this.mInTCPanel2.TabIndex = 1;
            // 
            // mInTCPanel1
            // 
            this.mInTCPanel1.CurrentPath = "";
            this.mInTCPanel1.Location = new System.Drawing.Point(9, 10);
            this.mInTCPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.mInTCPanel1.Name = "mInTCPanel1";
            this.mInTCPanel1.Size = new System.Drawing.Size(200, 313);
            this.mInTCPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 328);
            this.Controls.Add(this.copyToLeft);
            this.Controls.Add(this.copyToRight);
            this.Controls.Add(this.moveToLeft);
            this.Controls.Add(this.moveToRight);
            this.Controls.Add(this.mInTCPanel2);
            this.Controls.Add(this.mInTCPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MInTCPanel mInTCPanel1;
        private MInTCPanel mInTCPanel2;
        private System.Windows.Forms.Button moveToRight;
        private System.Windows.Forms.Button moveToLeft;
        private System.Windows.Forms.Button copyToRight;
        private System.Windows.Forms.Button copyToLeft;
    }
}

