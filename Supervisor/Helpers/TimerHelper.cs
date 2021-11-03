using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor.Helpers
{
    public class TimerHelper
    {
        static Timer t = new Timer { Interval = 100 };
        static Timer t1 = new Timer { Interval = 100 };
        public static string timeOutput;
        public static void Run(int min, EventHandler @callback)
        {
            if(t1.Interval == 100)
            {
                t.Tick += new EventHandler(@callback);
            }

            t.Enabled = true;
            t.Interval = 1000 * 60 * min;
            t.Start();
        }

        public static void Close()
        {
            t.Stop();
        }

        public static void CountDown(Action action)
        { 
            if(t1.Interval == 100)
            {
                t1.Interval = 1000; // 1 second
                t1.Enabled = true;

                t1.Tick += new EventHandler((s, e) =>
                {
                    action.Invoke();
                });
            }    
            t1.Start();
        }

        public static void CloseCountdown()
        {
            t1.Stop();
        }
    }
}
