using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Job
{
   public  class JobMethods
    {
        public static void SaveJobList(List<jobSchedule> job,string path)
        {

            XmlSerializer xs = new XmlSerializer(job.GetType());
            TextWriter tw = new System.IO.StreamWriter(path); //programData içine kaydedilecek
            xs.Serialize(tw, job);
            tw.Close();
        }
        public static void LoadJobList(List<jobSchedule> job, string path,DataGridView dataGridView)
        {
            var serializer = new XmlSerializer(typeof(List<jobSchedule>));
            
            FileStream fs = new FileStream(path, FileMode.Open);


            var other = (List<jobSchedule>)(serializer.Deserialize(fs));

            job.AddRange(other);
            var source = new BindingSource();
            source.DataSource = other;
            dataGridView.DataSource = source;
            fs.Close();

        }
        public static void DeleteSelectedJob(List<jobSchedule> job,DataGridView dataGridView,string path)
        {
            jobSchedule jb = new jobSchedule();

            if (dataGridView.CurrentRow != null)
            {
                job.RemoveAt(dataGridView.CurrentRow.Index);
                dataGridView.DataSource = job.ToList();
                var source = new BindingSource();
                source.DataSource = job;
                dataGridView.DataSource = source;
                XmlSerializer xs = new XmlSerializer(job.GetType());
                TextWriter tw = new System.IO.StreamWriter(path);
                xs.Serialize(tw, job);
                tw.Close();
            }
        }
       
      
    }
}
