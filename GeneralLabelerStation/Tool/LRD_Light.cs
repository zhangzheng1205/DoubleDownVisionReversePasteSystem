using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralLabelerStation.Tool
{
    public class LRD_Light:Common.SingletionProvider<LRD_Light>
    {
        [JsonIgnore]
        public bool bRed = true;
        [JsonIgnore]
        public bool bGreen = true;
        [JsonIgnore]
        public bool bBlue = true;
        [JsonIgnore]
        public int RedValue = 80;
        [JsonIgnore]
        public int GreenValue = 80;
        [JsonIgnore]
        public int BlueValue = 80;

        [JsonIgnore]
        public Socket Socket = null;

        public string SensorIP
        {
            get;
            set;
        } = "192.168.1.100";

        public int SensorProt
        {
            get;
            set;
        } = 5000;

        public void Init()
        {
            IPAddress iPAddress = IPAddress.Parse(this.SensorIP);
            IPEndPoint iPEnd = new IPEndPoint(iPAddress, this.SensorProt);
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.Socket.ReceiveTimeout = 200;
            this.Socket.Connect(iPEnd);

            Task.Factory.StartNew(() => {
                while(this.Socket.Connected)
                {
                    Thread.Sleep(5);
                    try
                    {
                        byte[] recv = new byte[1024];
                        this.Socket.Receive(recv, recv.Length, 0);
                        Debug.WriteLine(recv);
                    }
                    catch { }
                }
            });
        }

        public void SetLight(bool red,bool blue, bool green, int redValue, int greenValue, int blueValue)
        {
            if(this.Socket != null && this.Socket.Connected)
            {
                this.bRed = red;
                this.RedValue = redValue;
                this.bGreen = green;
                this.GreenValue = greenValue;
                this.bBlue = blue;
                this.BlueValue = blueValue;

                byte[] sendByte = new byte[10];
                sendByte[0] = 0xFF;
                sendByte[1] = 0x05;
                sendByte[2] = 0x01;
                sendByte[3] = 0x00;
                sendByte[4] = (byte)redValue;

                sendByte[5] = (byte)(sendByte[0] ^ sendByte[1] ^ sendByte[2] ^ sendByte[3] ^ sendByte[4]);
                this.Socket.Send(sendByte);
                //byte[] sendByte = new byte[10];
                //sendByte[0] = 0xFE;
                //sendByte[1] = 0x05;
                //sendByte[2] = 0x01;
                //sendByte[3] = (byte)redValue;
                //sendByte[4] = 0x02;
                //sendByte[5] = (byte)greenValue;
                //sendByte[6] = 0x03;
                //sendByte[7] = (byte)blueValue;
                //sendByte[8] = 0xFF;
                //sendByte[9] = 0xFE;
                //for (int i = 1; i < sendByte.Length - 1; ++i)
                //{
                //    sendByte[9] ^= sendByte[i];
                //}
            }
        }

        public void SetIP(int ip1,int ip2)
        {
            if (this.Socket != null && this.Socket.Connected)
            {
                byte[] sendByte = new byte[10];
                sendByte[0] = 0xFF;
                sendByte[1] = 0x20;
                sendByte[2] = 0x01;
                sendByte[3] = (byte)ip1;
                sendByte[4] = (byte)ip2;

                sendByte[5] = (byte)(sendByte[0] ^ sendByte[1] ^ sendByte[2] ^ sendByte[3] ^ sendByte[4]);
                this.Socket.Send(sendByte);
            }
        }
    }
}
