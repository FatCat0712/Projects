using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myStruct
{
    [Serializable]
    public class UserList : ISerializable
    {
        private List<User> users;

        public List<User> Users { get => users; set => users = value; }

        public UserList()
        {
            Users = new List<User>();
        }

        public void addUser(User user)
        {
            if (!checkExist(user))
            {
                Users.Add(user);
            }
            
        }
        public bool checkExist(User user)
        {
            return Users.Contains(user);
        }

        public List<User> getUsers() { return users;}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("userlist", Users);
        }

        public UserList(SerializationInfo info, StreamingContext context)
        {
            Users = (List<User>)info.GetValue("userlist", typeof(List<User>));
        }
    }
}
