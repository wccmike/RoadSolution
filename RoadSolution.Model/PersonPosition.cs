using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类PersonPosition 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class PersonPosition
    {
        public PersonPosition()
        { }
        #region Model
        private string _positionid;
        private User _user;
        private string _userid;
        private string _positiondate;
        private DateTime _positiontime;
        private decimal _lat;
        private decimal _lng;
        public User User
        {
            set { _user = value; }
            get { return _user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PositionID
        {
            set { _positionid = value; }
            get { return _positionid; }
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
        public string PositionDate
        {
            set { _positiondate = value; }
            get { return _positiondate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PositionTime
        {
            set { _positiontime = value; }
            get { return _positiontime; }
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

