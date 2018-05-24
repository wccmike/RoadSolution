using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace RoadSolution.BLL
{
    /// <summary>
    /// 业务逻辑类Usertype 的摘要说明。
    /// </summary>
    public class Usertype
    {
        private static readonly RoadSolution.DAL.Usertype dal = new RoadSolution.DAL.Usertype();
        public Usertype()
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
        public bool Exists(string TypeID)
        {
            return dal.Exists(TypeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.Usertype model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Usertype model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string TypeID)
        {
            dal.Delete(TypeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Usertype GetModel(string TypeID)
        {
            return dal.GetModel(TypeID);
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


