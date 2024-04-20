using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myStruct
{
    [Serializable]
    public class User : ISerializable
    {
        private string _textChat;
        private string _userName;
        private string _passWord;
        private string _endPoint;
        private string _targetUser;
        private string _publicKey;


        public string TextChat { get => _textChat; set => _textChat = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string PassWord { get => _passWord; set => _passWord = value; }
        public string EndPoint { get => _endPoint; set => _endPoint = value; }
        public string TargetUser { get => _targetUser; set => _targetUser = value; }
        public string PublicKey { get => _publicKey; set => _publicKey = value; }

        public User()
        {
           
           

        }
        public User(string userName,string passWord)
        {
            UserName = userName;
            PassWord = passWord;
        }
        public User(string userName,string password,string textChat)
        {
            TextChat = textChat;
            UserName = userName;
            PassWord = password;   

        }
       
        public User(User str)
        {
            TextChat = str.TextChat;
            UserName = str.UserName;
            PassWord = str.PassWord;
            EndPoint = str.EndPoint;
            
           
        }

        //Serialize
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("text", TextChat);
            info.AddValue("username", UserName);
            info.AddValue("password", PassWord);
            info.AddValue("endpoint", EndPoint);
            info.AddValue("targetuser", TargetUser);

            //get key to transfer
            info.AddValue("publickey", PublicKey);



        }

        //Deserialize
        public User(SerializationInfo info, StreamingContext context)
        {
            TextChat = (string)info.GetValue("text", typeof(string));
            UserName = (string)info.GetValue("username",typeof(string));
            PassWord = (string)info.GetValue("password",typeof(string));
            EndPoint = (string)info.GetValue("endpoint",typeof(string));
            TargetUser = (string)info.GetValue("targetuser", typeof(string));


            //read key from stream
            PublicKey = (string)info.GetValue("publickey", typeof(string));





        }

        public override string ToString()
        {
            return UserName + "-" + PassWord + "-" + PublicKey;
        }
    }
}
