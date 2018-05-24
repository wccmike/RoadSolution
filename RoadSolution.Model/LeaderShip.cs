using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类LeaderShip 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class LeaderShip
    {
        public LeaderShip()
        { }
        #region Model
        private string _userid;

        private string _leaderid;
        private User _user;
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
        public string LeaderID
        {
            set { _leaderid = value; }
            get { return _leaderid; }
        }
        #endregion Model
    }
}

