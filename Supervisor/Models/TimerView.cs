using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.Models
{
    public class TimerView
    {
        public string Email { get; set; }
        public bool IsClock { get; set; }
        public int Minute { get; set; }
        public TimeSpan Clock { get; set; }
        public bool IsOnce { get; set; }
    }
}
