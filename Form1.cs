using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Job
{
    public partial class Form1 : Form
    {
       
        public jobSchedule job;
        public List<jobSchedule> Jobs = new List<jobSchedule>();
        string path = @"c:\temp\jobs.txt";
        public Form1()
        {
            InitializeComponent();
            JobMethods.LoadJobList(Jobs,path,dataGridView1);
            dataGridView1.Update();
           // schedule_Timer(Jobs);


        }

        private void button3_Click(object sender, EventArgs e)//edit
        {
            jobSchedule Job = (jobSchedule)dataGridView1.CurrentRow.DataBoundItem;
            EditForm edit = new EditForm();
            edit.EditJob(Job);

            DialogResult dr = edit.ShowDialog();
            if (dr == DialogResult.OK)
            {
                
                dataGridView1.Refresh();
            }
            JobMethods.SaveJobList(Jobs,path);
          
            
          
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            job = new jobSchedule();
            EditForm edit = new EditForm();
            edit.EditJob(job);
            DialogResult dr = edit.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Jobs.Add(job);
                DataGridRefresh();

            }

            JobMethods.SaveJobList(Jobs,path);
        


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.RefreshEdit();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DataGridRefresh()
        {
            try
            {
                var source = new BindingSource();
                source.DataSource = Jobs;
                dataGridView1.DataSource = source;
            }
            catch
            {

            }
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            JobMethods.DeleteSelectedJob(Jobs, dataGridView1, path);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isChecked = (bool)dataGridView1["isActive", e.ColumnIndex].EditedFormattedValue;

            if (isChecked == true)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
               
            }

            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            

        }
      /*  public  void schedule_Timer(jobSchedule jb)
         {
           
             if (jb.isActive == true)
             {
                 DateTime nowTime = DateTime.Now;
                 System.Timers.Timer timer;
                // DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 11, 17, 0, 0);
                 DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, jb.StartHour, jb.StartMinute, 0, 0);
                 DateTime FinishedTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, jb.EndHour, jb.EndMinute, 0, 0);
                 if (nowTime > scheduledTime)
                 {
                     scheduledTime = scheduledTime.AddDays(1);
                 }

                 double tickTime = (double)(scheduledTime - DateTime.Now).TotalMilliseconds;
                 timer = new System.Timers.Timer(tickTime);
                 timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                 timer.Start();
                 if(nowTime > FinishedTime)
                {
                    
                }
                
             }

        
        }*/
        public void schedule_Timer(List<jobSchedule> Jobs)
        {

                
           
                foreach (jobSchedule jb in Jobs)
                {
                DateTime currentTime = DateTime.Now;
                DateTime startTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, jb.StartHour, jb.StartMinute, 0, 0);
                DateTime finishedTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, jb.EndHour, jb.EndMinute, 0, 0);
                if (jb.isActive == true)
                  {
                    Thread doJob = new Thread(DoJob);
                    if (startTime > currentTime && currentTime < finishedTime && !jb.running)
                    {
                        jb.running = true;
                       
                        doJob.Start();
                    }
                    else
                    {
                        if (jb.running)
                        {
                            doJob.Interrupt();
                            jb.running = false;
                            
                        }
                    }
                    
                   
                }
            }
                

       }
        public void DoJob()
        {
            job.running = true;
            textBox1.Invoke((MethodInvoker)delegate ()
            {
                textBox1.Text = "Copying...";
            });
            Thread.Sleep(10000);
       }

        public void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

          


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

       
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
               if (dataGridView1.Rows[i].Cells["isActive"].Value != null)
               {
                    if ((bool)dataGridView1.Rows[i].Cells["isActive"].Value == true)
                    {

                        renk.BackColor = Color.YellowGreen;
                        dataGridView1.Rows[i].DefaultCellStyle = renk;

                    }
                  
                    }
               }
         

        }

       
    }
 }

