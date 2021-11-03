using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.Domain.Base
{
    class BaseConstant
    {
        public static string EXE = Assembly.GetExecutingAssembly().GetName().Name;

    }
}
