using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CustomLCDIndicator
{
    class MemoryUsage
    {
        PerformanceCounter counter;
        public MemoryUsage()
        {
            counter = new PerformanceCounter("Memory", "Available MBytes");          
        }
        public String getCurrentValue()
        {
            return Convert.ToString(Convert.ToInt32(counter.NextValue()));
        }
    }
}
