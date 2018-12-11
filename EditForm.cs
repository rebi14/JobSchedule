using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Job
{
    public partial class EditForm : Form
    {
        private jobSchedule job ;
        public EditForm()
        {
            InitializeComponent();

        }
        public void EditJob(jobSchedule jb)
        {
            job = jb;
            checkBox1.Checked = jb.days[0];
            checkBox2.Checked = jb.days[1];
            checkBox3.Checked = jb.days[2];
            checkBox4.Checked = jb.days[3];
            checkBox5.Checked = jb.days[4];
            checkBox6.Checked = jb.days[5];
            checkBox7.Checked = jb.days[6];
            textBox1.Text = jb.source;
            textBox2.Text = jb.destination;
            string start = numericUpDown1.Value.ToString() + ":" +numericUpDown3.Value.ToString();
            string end = numericUpDown2.Value.ToString() + ":" + numericUpDown4.Value.ToString();

            numericUpDown1.Value =jb.StartHour;
            numericUpDown3.Value = jb.StartMinute;
            numericUpDown2.Value = jb.EndHour;
            numericUpDown4.Value = jb.EndMinute;
        }
        private void button1_Click(object sender, EventArgs e)//SAVE
        {
            job.days[0] = checkBox1.Checked;
            job.days[1] = checkBox2.Checked;
            job.days[2] = checkBox3.Checked;
            job.days[3] = checkBox4.Checked;
            job.days[4] = checkBox5.Checked;
            job.days[5] = checkBox6.Checked;
            job.days[6] = checkBox7.Checked;
            job.source = textBox1.Text;
            job.destination = textBox2.Text;
            job.StartMinute = (int)numericUpDown3.Value;
            job.StartHour = (int)numericUpDown1.Value;
            job.EndMinute = (int)numericUpDown2.Value;
            job.EndHour = (int)numericUpDown4.Value;
                
                
           //numericUpDown2.Value.ToString("00") + ":" + numericUpDown4.Value.ToString("00");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           // job.days[(int)((CheckBox)sender).Tag] = ((CheckBox)sender).Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBrowser = new FolderBrowserDialog();

            fBrowser.ShowDialog();

            string selectedPath = fBrowser.SelectedPath;

            textBox1.Text = selectedPath;

             
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBrowser = new FolderBrowserDialog();

            fBrowser.ShowDialog();

            string selectedPath = fBrowser.SelectedPath;

            textBox2.Text = selectedPath;

            
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        
    }
}
