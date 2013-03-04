using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CustomLCDIndicator
{
    
    class CPUUsage
    {
        PerformanceCounter counter;
        public CPUUsage()
        {
            counter = new PerformanceCounter();
            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";
        }
        public String getCurrentValue()
        {
            return Convert.ToString(Convert.ToInt32(counter.NextValue()));
        }
    }
}
