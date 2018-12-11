using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Job
{
    [Serializable]
   
    public class jobSchedule

    {
        [XmlElement("jobSchedule")]
        [XmlIgnore]
        // public int ID { get; set; }
        public Boolean running { get; set;}
        public string source { get; set; }

        public string destination { get; set; }
        
        public string startTime
        {
            get
            {
                return StartHour.ToString("00") + ":" + StartMinute.ToString("00");
            }
        }
       
        public string endTime {

            get
            {
                return EndHour.ToString("00") + ":" + EndMinute.ToString("00");
            }

        }
        public int StartMinute { get ; set; }
        public int StartHour { get; set; }
        
        public int EndMinute { get; set; }
        public int EndHour { get; set; }


        public bool[] days { get; set; }
        public Boolean isActive { get; set; }

        public enum DaysOfWeeks
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday

        }

         public jobSchedule()
        {
            days = new bool[7];
            StartMinute = 0;
            StartHour = 0;
            EndHour = 0;
            EndMinute = 0;
            running = false;
        }
    }
}
