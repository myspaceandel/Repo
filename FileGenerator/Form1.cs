using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void t_count_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t_count.Text, "[^0-9]"))
            {
                t_count.Text = t_count.Text.Remove(t_count.Text.Length - 1);
                t_count.SelectionStart = t_count.Text.Length;
            }
        }
        private void t_max_size_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t_max_size.Text, "[^0-9]"))
            {
                t_max_size.Text = t_max_size.Text.Remove(t_max_size.Text.Length - 1);
                t_max_size.SelectionStart = t_max_size.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\FileGenerator"))
                Directory.CreateDirectory(@"C:\FileGenerator");
            Random rnd = new Random();
            int progress_bar_step = 100 / Convert.ToInt32(t_count.Text);
            for (int i = 0; i < Convert.ToInt32(t_count.Text); i++)
            {
                int current_name = rnd.Next(10000, 1000000);
                try {
                    FileStream fs = new FileStream(@"C:\FileGenerator\" + current_name + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
                    fs.SetLength(rnd.Next(0, Convert.ToInt32(t_max_size.Text)));
                    progress.Value += progress_bar_step;
                }
                catch { MessageBox.Show("Error"); }
            }
            MessageBox.Show("Finish");
        }
    }
}
