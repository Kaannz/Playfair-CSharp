using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hill
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public char[] arrForm3 { get; set; }
        public string stringEncrypt3 { get; set; }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = stringEncrypt3;
        }
    }
}
