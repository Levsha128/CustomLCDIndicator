using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace LCDIncator
{
    class LCD
    {
        private String connectionPort;
        private int bitRate;
        SerialPort serialPort;
        static String DEFAULT_CONNECTION_PORT = "COM3";
        static int DEFAULT_BITRATE = 9600;
        static String TAG = "LCD";

        public LCD()
        {

        }
        public void connect(String connectionPort, int bitRate)
        {
            this.connectionPort = connectionPort;
            this.bitRate = bitRate;

            disconnect();

            serialPort = new SerialPort(connectionPort, bitRate);

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
        private byte convertCharFromUTF8ToKS0066(char chr)
        {
            return 0x00;
        }
        private byte[] convertStringFromUTF8ToKS0066(String str)
        {
            byte[] buf = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
                buf[i] = convertCharFromUTF8ToKS0066(str[i]);
            return buf;
        }
        public void write(char chr)
        {
            if (isConnected())
                serialPort.Write(new byte[] { convertCharFromUTF8ToKS0066(chr) }, 0, 1);
        }
        public void write(String str)
        {
            if (isConnected())
                serialPort.Write(convertStringFromUTF8ToKS0066(str), 0, str.Length);
        }
    }
}
