namespace WindowsFormsApplication1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1_OK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2_OK = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1_OK
            // 
            this.button1_OK.AccessibleName = "button";
            this.button1_OK.Location = new System.Drawing.Point(63, 36);
            this.button1_OK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1_OK.Name = "button1_OK";
            this.button1_OK.Size = new System.Drawing.Size(94, 20);
            this.button1_OK.TabIndex = 0;
            this.button1_OK.Text = "button1";
            this.button1_OK.UseVisualStyleBackColor = true;
            this.button1_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "";
            this.textBox1.Location = new System.Drawing.Point(46, 111);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // textBox2
            // 
            this.textBox2.AccessibleName = "";
            this.textBox2.Location = new System.Drawing.Point(46, 165);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button2_OK
            // 
            this.button2_OK.AccessibleName = "";
            this.button2_OK.Location = new System.Drawing.Point(173, 36);
            this.button2_OK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2_OK.Name = "button2_OK";
            this.button2_OK.Size = new System.Drawing.Size(78, 20);
            this.button2_OK.TabIndex = 4;
            this.button2_OK.Text = "button2";
            this.button2_OK.UseVisualStyleBackColor = true;
            this.button2_OK.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(164, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 223);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2_OK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1_OK);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_OK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2_OK;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}