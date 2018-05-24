using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类User 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class User
    {
        public User()
        { }
        #region Model
        private string _userid;
        private Usertype _usertype;
        private string _typeid;
        private string _username;
        private string _password;
        public Usertype Usertype
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model
    }
}


