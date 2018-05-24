using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace RoadSolution.BLL
{
    /// <summary>
    /// 业务逻辑类Attendance 的摘要说明。
    /// </summary>
    public class Attendance
    {
        private static readonly RoadSolution.DAL.Attendance dal = new RoadSolution.DAL.Attendance();
        public Attendance()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AID)
        {
            return dal.Exists(AID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.Attendance model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Attendance model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string AID)
        {
            dal.Delete(AID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Attendance GetModel(string AID)
        {
            return dal.GetModel(AID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public string ListAllAttrNUserinfoBySearch(string Name, string Department, string DateBegin, string DateEnd)
        {
            DataSet ds =dal.ListAllAttrNUserinfoBySearch(Name, Department, DateBegin, DateEnd);
            string[] args = {"AID","UserID","Date","Time","Photo","Lat","Lng","Department","Name" };
            DataSet dsafter =RoadSolution.DBUtils.DatasetJsonUtil.DealDateProblem(ds, args);
            string json=RoadSolution.DBUtils.DatasetJsonUtil.DatasetToJson(dsafter);
            return json;
        }

        #endregion  成员方法
    }
}


