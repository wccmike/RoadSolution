using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类Userinfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Userinfo
    {
        public Userinfo()
        { }
        #region Model
        private string _userid;
        private User _user;
        private string _department;
        private string _road;
        private string _name;
        private string _gender;
        private string _photo;
        private int _age;
        private string _workid;
        public User User
        {
            set { _user = value; }
            get { return _user; }
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
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Road
        {
            set { _road = value; }
            get { return _road; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkID
        {
            set { _workid = value; }
            get { return _workid; }
        }
        #endregion Model
    }
}


