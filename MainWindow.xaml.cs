using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LCDIncator;
using System.Threading;

namespace CustomLCDIndicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LCD a = new LCD();          

            a.connect("COM3", 9600);
            CPUUsage c = new CPUUsage();
            while (true)
            {
                Thread.Sleep(1000);
                
                a.write(c.getCurrentValue());                
            }
            

            a.disconnect();
        }
    }
}
