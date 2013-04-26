using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("This is button 1");
        }

        private void button2_Click(object sender, EventArgs e) {
            MessageBox.Show("This is button 2");
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

    }
}
