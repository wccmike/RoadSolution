using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadSolution.Model
{
    /// <summary>
    /// 实体类Usertype 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Usertype
    {
        public Usertype()
        { }
        #region Model
        private string _typeid;
        private string _typename;
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
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        #endregion Model
    }
}

