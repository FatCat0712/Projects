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
using System.Net.Http.Headers;
using myStruct;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Globalization;


namespace KTMM_Chat
{
    public partial class Server : Form
    {
        Socket server;
        IPEndPoint ipe;
        List<Socket> clientList = new List<Socket>();
        static UserList userList = new UserList();
        Thread clientHandler;
        string myIP = "";
        Socket client;
        string fileName = @"E:\C#\database.txt";
        RSACryptoServiceProvider xalg;


        public Server()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
           
        }


        public void getIP()
        {
            IPHostEntry hosts = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in hosts.AddressList)
            {
                if(ip.AddressFamily.ToString() == "InterNetwork")
                {
                    myIP = ip.ToString();
                }
            }
            ipe = new IPEndPoint(IPAddress.Parse(myIP), 2002);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }
        private void tcontent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Server_Load(object sender, EventArgs e)
        {
            getIP();
            clientHandler = new Thread(new ThreadStart(listen));
            clientHandler.IsBackground = true;
            clientHandler.Start();
        }

        public void listen()
        {
            server.Bind(ipe);

            // number of clients that server can accept at one time
            server.Listen(10);
            
            while (true)
            {

                client = server.Accept();

                //Add a client a client socket list
                clientList.Add(client);

                Thread clientProcess = new Thread(clientThread);
                clientProcess.IsBackground = true;
                clientProcess.Start(client);



                //get username from client
                cbClientList.Items.Add(readUserName());
                

                //save data
                saveToDatabase();

                // annouce a client is connected
                lcontent.Items.Add(client.RemoteEndPoint.ToString() + " is connected");



               

                // send userList back to client
                Thread sendUserList = new Thread(sendUserListData);
                sendUserList.IsBackground = true;
                sendUserList.Start();











            }
        }

        public void clientThread(object o)
        {
            Socket clientSocket = (Socket)o;
            while (true)
            {
                // receive data from client
                byte[] buff = new byte[1024*2];
                clientSocket.Receive(buff);


                //identify receiver endpoint
                string targetEndPoint = getTargetEndpoint(buff);


                //encrypt message from sender
                User sender = encryptBuff(buff);



                // send the data to other clients in list
                foreach (Socket socket in clientList)
                {
                    // broadcast message to other clients
                    if(targetEndPoint.Length != 0) 
                    {
                        if (!Equals(clientSocket, socket) && Equals(socket.RemoteEndPoint.ToString(), targetEndPoint))
                        {
                            //Convert the User object into a stream
                            using (MemoryStream stream = new MemoryStream())
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(stream, sender);

                                stream.Position = 0;
                                // send data in byte[] shape
                                byte[] buffer = stream.ToArray();

                                socket.Send(buffer,buffer.Length,SocketFlags.None);
                            }
                            break;

                        }
                    }
                    else
                    {
                        if (!Equals(clientSocket, socket))
                        {
                            socket.Send(buff, buff.Length, SocketFlags.None);
                        }
                    }
                  
                }

            }
        }


      

        private void bStart_Click(object sender, EventArgs e)
        {
           lcontent.Items.Add("Server is running ... ");
        }


        

       

        public string readUserName()
        {
            //Read username from client;
            byte[] buff = new byte[1024];
            client.Receive(buff);

            User user;

            //convert receive buff into a stream
            MemoryStream stream = new MemoryStream(buff);
            BinaryFormatter formatter = new BinaryFormatter();

            //convert receive stream into a User object
           
            stream.Seek(0, SeekOrigin.Begin);
            user = (User)formatter.Deserialize(stream);
            userList.addUser(user);

            return user.UserName;
        }


        

        public void sendUserListData()
        {

            //Convert the User object into a stream
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, userList);


                stream.Position = 0;
                // send data in byte[] shape
                byte[] buff = stream.ToArray();
                client.Send(buff);
            }

        }


        //write data to file
        public void saveToDatabase()
        {
            
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
          
            FileStream fs = new FileStream(fileName, FileMode.Create,FileAccess.Write,FileShare.Write);
            byte[] buffer = Encoding.UTF8.GetBytes(userData());
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            
        }

        public string userData()
        {
            string data = "";
            foreach(User u in userList.getUsers())
            {
               
                data += u.ToString() + "\n";
                 
            }
            return data;
        }

        public string getTargetEndpoint(byte[] buff)
        {
            User user;
            string receiveTarget = "";
            //convert receive buff into a stream
            using (MemoryStream stream = new MemoryStream(buff))
            {
                BinaryFormatter formatter = new BinaryFormatter();
              
                stream.Seek (0, SeekOrigin.Begin);
                
                //convert receive stream into a User object
                user = (User)formatter.Deserialize(stream);

                //if(!Equals(user.UserName, "Server"))
                //{
                    foreach (User u in userList.getUsers())
                    {
                        if (Equals(u.EndPoint, user.EndPoint) || Equals(u.UserName, user.TargetUser))
                        {
                            receiveTarget += u.EndPoint;
                            break;
                        }
                    }
                //}
            }
            return receiveTarget;
        }
        
        public User encryptBuff(byte[] buff)
        {
            User user;

            //convert receive buff into a stream
            using (MemoryStream stream = new MemoryStream(buff))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                stream.Seek(0, SeekOrigin.Begin);

                //convert receive stream into a User object
                user = (User)formatter.Deserialize(stream);

                //if (!Equals(user.UserName, "Server"))
                //{
                    foreach (User u in userList.getUsers())
                    {
                        if (Equals(u.EndPoint, user.EndPoint) || Equals(u.UserName, user.TargetUser))
                        {
                            //encrypt message before forwarding message
                            string encryptedMess = encryptMessage(user.TextChat, u.PublicKey);
                            user.TextChat = encryptedMess;
                            break;
                        }
                    }
                //}
               


            }
            
            return user;
        }
        public string encryptMessage(string plaintext,string publickey)
        {
            xalg = new RSACryptoServiceProvider();
            byte[] xplain = Encoding.UTF8.GetBytes(plaintext);
            xalg.FromXmlString(publickey);
            byte[] xcipher = xalg.Encrypt(xplain, true);
            string cipher = BitConverter.ToString(xcipher);
            xalg.Clear();

            return cipher;
        }

       

    }
}
