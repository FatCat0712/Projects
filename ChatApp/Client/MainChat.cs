using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using myStruct;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Security.Claims;

namespace Client
{
    public partial class MainChat : Form
    {
        Socket client;
        string username;

        Thread connect;
        UserList userList;
        RSACryptoServiceProvider xalg;

        string privatekey;

        public MainChat(string name,Socket client,string privatekey)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            username = name;
            this.client = client;
            this.privatekey = privatekey;
            
     

            lchat.Items.Add("!!! Welcome to the server " + username + " !!! ");

            //announce a other client a new client connected
            User newUser = new User("Server","", username + " joined the chat");
            sendData(newUser);


            //listen to server on starting
            connect = new Thread(new ThreadStart(connectServer));
            connect.IsBackground = true;
            connect.Start();


            

            ////receive online users from server
            byte[] buff = new byte[1024*5];
            client.Receive(buff);


            ////convert receive buff into a stream
            using (MemoryStream stream = new MemoryStream(buff))
            {
                stream.Position = 0;
                IFormatter formatter = new BinaryFormatter();
                //convert receive stream into a UserList object
                try
                {                   
                    userList = (UserList)formatter.Deserialize(stream);


                    cbContacts.Items.Clear();

                    cbContacts.Items.Add("Everyone");
                    cbContacts.SelectedIndex = 0;


                    foreach (User u in userList.getUsers())
                    {
                        if (!Equals(u.UserName, username) && !Equals(u.UserName,"Server"))
                        {
                            cbContacts.Items.Add(u.UserName);
                        }


                    }

                }
                catch (SerializationException)
                {
                    
                    stream.Close();
                }
            }









        }


        private void bSend_Click(object sender, EventArgs e)
        {
            User str = new User();

            if(tchat.Text.Length != 0)
            {
                if (!Equals(cbContacts.SelectedItem.ToString(), "Everyone"))
                {

                    //enter later but want to talk to someone who joined earlier
                    str.EndPoint = getTartgetEndPoint();

                    //the one ealier want to send to some who joined later
                    str.TargetUser = cbContacts.SelectedItem.ToString();
                }

                str.TextChat = tchat.Text;
                str.UserName = username;
                sendData(str);

                lchat.Items.Add("Me: " + tchat.Text);
                tchat.Text = "";
            }
           

        }

        private void bConnect_Click(object sender, EventArgs e)
        {
           
            string target = cbContacts.GetItemText(cbContacts.SelectedItem);
            lchat.Items.Add("Server: start a conversation with " + target);

            //send notification to target user
            User secretUser = new User("Server","",username+ " starts a secret talk with you. ");
            
            secretUser.TargetUser = cbContacts.SelectedItem.ToString();
            secretUser.EndPoint = getTartgetEndPoint();

            sendData(secretUser);


           

        }

        public void connectServer()
        { 
            // create a separate thread that always listens from server
            Thread listen = new Thread(listenFromServer);
            listen.IsBackground = true;
            listen.Start(client);
        }

        public void listenFromServer(object o)
        {
            Socket sk = (Socket)o;
            while (true)
            {
                byte[] buff = new byte[1024];
                sk.Receive(buff);
                deserialize(buff);
            }
        }

        public void deserialize(byte[] buff)
        {
            User user;

            //convert receive buff into a stream
            using (MemoryStream stream = new MemoryStream(buff))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();


                    
                    //convert receive stream into a User object
                    user = (User)formatter.Deserialize(stream);


                    //check if message was encypted
                    string message = "";
                    if (Regex.IsMatch(user.TextChat, @"^[0-9A-Z][0-9A-Z]+"))
                    {
                        message = decryptMessage(user.TextChat);
                        string name = message.Substring(0, message.IndexOf(' '));
                        cbContacts.SelectedItem = user.UserName;
                    }
                    else
                    {
                        message = user.TextChat;
                        if (Equals(user.UserName, "Server"))
                        {
                            string name = message.Substring(0, message.IndexOf(' '));
                            cbContacts.Items.Add(name);
                        }       
                    }
                    lchat.Items.Add(user.UserName + " : " + message);

                }
                catch (SerializationException)
                {
                    stream.Close();
                   
                }
            }
            

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

       
        public string decryptMessage(string ciphertext) { 
            xalg = new RSACryptoServiceProvider();
            byte[] xcipher = ciphertext.Split('-').Select(item => Convert.ToByte(item,16)).ToArray();

            xalg.FromXmlString(privatekey);
            byte[] xplain = xalg.Decrypt(xcipher, true);
            string plain = Encoding.UTF8.GetString(xplain);
            xalg.Clear();

            return plain;

        }
        
        public string getTartgetEndPoint()
        {
            string target = "";
            foreach(User u in userList.getUsers())
            {
                if(Equals(u.UserName, cbContacts.SelectedItem.ToString()))
                {
                    target += u.EndPoint;
                    break;
                }
            }
            return target;
        }

        

      

      


      


        


       

        
       

        
    }
}
