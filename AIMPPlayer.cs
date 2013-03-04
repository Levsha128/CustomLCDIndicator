using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CustomLCDIndicator
{
    class AIMPPlayer
    {
        Process process;
        public AIMPPlayer()
        {
            Process[] processes = Process.GetProcessesByName("AIMP3");
            if(processes.Length>=0)
                process = processes[0];
        }

        public String getCurrentSong()
        {
            String buf = "";
            if (process != null)
                buf =  process.MainWindowTitle;
            if (buf.Split('-').Length >= 1)
                buf = buf.Split('-')[1];
            return buf;
        }
        public String getCurrentAuthor()
        {
            String buf = "";
            if (process != null)
                buf = process.MainWindowTitle;
            if(buf.Split('-').Length>=1)
                buf = buf.Split('-')[0];
            return buf;
        }
    }
}
