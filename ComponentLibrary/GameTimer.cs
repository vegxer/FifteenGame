using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class GameTimer: UserControl
    {
        int seconds, minutes, hours;

        public GameTimer()
        {
            InitializeComponent();
            seconds = minutes = hours = 0;
        }

        public void Start()
        {
            seconds = minutes = hours = 0;
            display.Text = "00:00:00";
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (++seconds == 60)
            {
                seconds = 0;
                ++minutes;
            }
            if (minutes == 60)
            {
                minutes = 0;
                ++hours;
            }
            display.Text = TimeFormat();
        }

        private string TimeFormat()
        {
            string time = "";

            if (hours / 10 == 0)
                time += "0";
            time += hours.ToString() + ":";

            if (minutes / 10 == 0)
                time += "0";
            time += minutes.ToString() + ":";
            
            if (seconds / 10 == 0)
                time += "0";
            time += seconds.ToString();

            return time;
        }

        public override string Text
        {
            get
            {
                return display.Text;
            }
            set
            {
                string time = value;
                if (CheckFormat(time))
                    display.Text = time;
                else
                    throw new FormatException();
            }
        }

        private bool CheckFormat(string time)
        {
            return time.Length == 8 && uint.TryParse(time.Substring(0, 2), out uint res1) && time[2] == ':' && 
                uint.TryParse(time.Substring(3, 2), out uint res2) && time[3] == ':' 
                && uint.TryParse(time.Substring(6, 2), out uint res3);
        }
    }
}
