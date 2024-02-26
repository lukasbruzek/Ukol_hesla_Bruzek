namespace Prihlasovanie
{
    partial class Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.txtBoxPasswordOne = new System.Windows.Forms.TextBox();
            this.txtBoxPasswordTwo = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(74, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(78, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(13, 63);
            this.txtBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(232, 22);
            this.txtBoxUsername.TabIndex = 3;
            // 
            // txtBoxPasswordOne
            // 
            this.txtBoxPasswordOne.Location = new System.Drawing.Point(13, 143);
            this.txtBoxPasswordOne.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPasswordOne.Name = "txtBoxPasswordOne";
            this.txtBoxPasswordOne.PasswordChar = '*';
            this.txtBoxPasswordOne.Size = new System.Drawing.Size(232, 22);
            this.txtBoxPasswordOne.TabIndex = 4;
            // 
            // txtBoxPasswordTwo
            // 
            this.txtBoxPasswordTwo.Location = new System.Drawing.Point(13, 228);
            this.txtBoxPasswordTwo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPasswordTwo.Name = "txtBoxPasswordTwo";
            this.txtBoxPasswordTwo.PasswordChar = '*';
            this.txtBoxPasswordTwo.Size = new System.Drawing.Size(232, 22);
            this.txtBoxPasswordTwo.TabIndex = 5;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Save.Location = new System.Drawing.Point(30, 273);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(200, 39);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(262, 330);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.txtBoxPasswordTwo);
            this.Controls.Add(this.txtBoxPasswordOne);
            this.Controls.Add(this.txtBoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.TextBox txtBoxPasswordOne;
        private System.Windows.Forms.TextBox txtBoxPasswordTwo;
        private System.Windows.Forms.Button Save;
    }
}