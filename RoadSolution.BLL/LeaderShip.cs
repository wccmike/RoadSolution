using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace RoadSolution.BLL
{
    /// <summary>
    /// 业务逻辑类LeaderShip 的摘要说明。
    /// </summary>
    public class LeaderShip
    {
        private static readonly RoadSolution.DAL.LeaderShip dal = new RoadSolution.DAL.LeaderShip();
        public LeaderShip()
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
        public bool Exists(string UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.LeaderShip model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.LeaderShip model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string UserID)
        {
            dal.Delete(UserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.LeaderShip GetModel(string UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  成员方法
    }
}


