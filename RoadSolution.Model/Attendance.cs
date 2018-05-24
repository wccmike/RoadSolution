using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类Attendance 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Attendance
    {
        public Attendance()
        { }
        #region Model
        private string _aid;
        private string _userid;
        private string _date;
        private DateTime _time;
        private string _photo;
        private decimal _lat;
        private decimal _lng;
        private User _user;
        public User User
        {
            set { _user = value; }
            get { return _user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AID
        {
            set { _aid = value; }
            get { return _aid; }
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
        public string Date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
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
        public decimal Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        #endregion Model
    }
}

