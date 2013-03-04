using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using CustomLCDIndicator;

namespace LCDIncator
{
    class LCD
    {
        private String connectionPort;
        private int baudRate;
        SerialPort serialPort;
        static String DEFAULT_CONNECTION_PORT = "COM3";
        static int DEFAULT_BITRATE = 9600;
        static String TAG = "LCD";
        KS0066Converter converter;
        public LCD()
        {
            converter = new KS0066Converter();
        }
        public void connect(String connectionPort, int baudRate)
        {
            this.connectionPort = connectionPort;
            this.baudRate = baudRate;

            disconnect();

            serialPort = new SerialPort(connectionPort, baudRate);
            serialPort.Open();

        }
        private bool isConnected()
        {
            return (serialPort != null) && (serialPort.IsOpen);
        }
        public void disconnect()
        {
            if (isConnected())
                serialPort.Close();
        }

        public void write(char chr)
        {
            if (isConnected())
                serialPort.Write(new byte[] { converter.convertCharFromUnicodeToKS0066(chr) }, 0, 1);
            Thread.Sleep(1);
        }
        public void write(String str)
        {
            if (isConnected())
                serialPort.Write(converter.convertStringFromUnicodeToKS0066(str), 0, str.Length);
        }
    }
}
