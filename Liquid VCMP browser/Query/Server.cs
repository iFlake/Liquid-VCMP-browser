using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid_VCMP_browser
{
    public class Server
    {
        public List<string> players;

        public string name;
        public string gamemode;
        public string version;

        public long ping;

        public short playercount;
        public short maxplayers;

        public bool passworded;

        public IPEndPoint host;

        protected int timeout;
        
        public Server(IPEndPoint host)
        {
            this.host = host;
        }

        public async void Refresh()
        {
            await Task.Run(new Action(QueryInformation));
        }

        protected void QueryInformation()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            client.ReceiveTimeout = timeout;
            client.SendTimeout = timeout;

            client.Connect(host);

            byte[] ipbytes = host.Address.GetAddressBytes();

            byte[] packet =
            {
                0x4D,
                0x50,
                0x30,
                0x34,

                ipbytes[0],
                ipbytes[1],
                ipbytes[2],
                ipbytes[3],

                (byte)(host.Port & 0xFF),
                (byte)(host.Port >> 8 & 0xFF),

                0x69
            };

            client.SendTo(packet, host);

            byte[] rpacket = new byte[2048];
            client.Receive(rpacket);

            Stream rstream = new MemoryStream();
            rstream.Write(rpacket, 0, rpacket.Length);
            rstream.Seek(0, SeekOrigin.Begin);

            byte[] magic =
            {
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte()
            };

            if (magic != new byte[]
            {
                0x4D,
                0x50,
                0x30,
                0x34
            }) throw new Exception("Mismatched magic in return header: " + magic.ToString());

            byte[] ip =
            {
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte()
            };

            if (ip != new byte[]
            {
                ipbytes[0],
                ipbytes[1],
                ipbytes[2],
                ipbytes[3]
            }) throw new Exception("Mismatched IP in return header: " + ipbytes.ToString());

            byte[] port =
            {
                (byte)rstream.ReadByte(),
                (byte)rstream.ReadByte()
            };

            if (port != new byte[]
            {
                (byte)(host.Port & 0xFF),
                (byte)(host.Port >> 8 & 0xFF)
            }) throw new Exception("Mismatched port in return header: " + port.ToString());

            byte[] requesttype =
            {
                (byte)rstream.ReadByte()
            };

            if (requesttype != new byte[]
            {
                (byte)0x69
            }) throw new Exception("Mismatched request in return header: " + requesttype);

            byte[] bversion = new byte[12];
            rstream.Read(bversion, 0, bversion.Length);

            version = Encoding.UTF8.GetString(bversion);

            passworded = rstream.ReadByte() == 1;

            playercount = 0;
            playercount += (short)(rstream.ReadByte());
            playercount += (short)(rstream.ReadByte() << 8);

            maxplayers = 0;
            maxplayers += (short)(rstream.ReadByte());
            maxplayers += (short)(rstream.ReadByte() << 8);
            
        }
    }
}
