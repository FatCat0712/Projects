using myStruct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Client
{
    public partial class Login : Form
    {
 
        public Login()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }


        IPEndPoint ipe;
        Socket client;
        RSACryptoServiceProvider xalg = new RSACryptoServiceProvider();
       

        
        private void bOK_Click(object sender, EventArgs e)
        {



            connectServer();

            string username = tname.Text;
            string password = bamChuoi(tpass.Text);
            
           
           

            
            User user = new User();
            string pubkey = xalg.ToXmlString(false);
            user.UserName = username;
            user.PassWord = password;
            user.PublicKey = pubkey;
            user.EndPoint = client.LocalEndPoint.ToString();

            string privateKey = xalg.ToXmlString(true);

            sendData(user);



            MainChat chatForm = new MainChat(tname.Text, client, privateKey);
            chatForm.Show();
            Hide();
          




        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void connectServer()
        {
            ipe = new IPEndPoint(IPAddress.Parse(tip.Text), 2002);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(ipe);

        }

        //hash the password
        private string bamChuoi(string chuoi)
        {
            byte[] xmess = Encoding.ASCII.GetBytes(chuoi);
            HashAlgorithm hamHash = HashAlgorithm.Create("SHA512");
            byte[] hashCode = hamHash.ComputeHash(xmess);
            String result = BitConverter.ToString(hashCode).Replace("-", "");
            return result;
        }
        public void sendData(object str)
        {

            //Convert the User object into a stream
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, str);

                stream.Position = 0;

                // send data in byte[] shape
                byte[] buff = stream.ToArray();

                client.Send(buff);
            }
        }
       



    }
}
