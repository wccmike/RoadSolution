using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RoadSolution.DBUtils;
namespace RoadSolution.BLL
{
    /// <summary>
    /// 业务逻辑类User 的摘要说明。
    /// </summary>
    public class User
    {
        private static readonly RoadSolution.DAL.User dal = new RoadSolution.DAL.User();
        public User()
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
        public string Add(RoadSolution.Model.User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.User model)
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
        public RoadSolution.Model.User GetModel(string UserID)
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
        /// <summary>
        /// 用username,pwd,typeid登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="typeid"></param>
        /// <returns>USER对象</returns>
        public RoadSolution.Model.User Login(string name, string pwd, string typeid)
        {
            RoadSolution.Model.User u = dal.GetByNamePwdTypeid(name, pwd, typeid);
            if (u == null)
                return null;
            return u;
        }
        /// <summary>
        /// 根据搜关键词列岀USER的结果，转化为JSON
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="TypeID"></param>
        /// <param name="Road"></param>
        /// <returns></returns>
        public string ListJsonByKeyword(string Name, string TypeID, string Road)
        {
            
            DataSet ds = dal.ListByKeyword(Name, TypeID, Road);
            if (ds == null)
                return null;
            string result = DatasetJsonUtil.DatasetToJson(ds);
            if (result == null || "".Equals(result))
                return null;
            return result;
        }
        public bool UploadUserPassword(string UserId, string OldPassword, string Password)
        {
            string oldpwd = dal.GetPasswordByUserId(UserId);
            if (!oldpwd.Equals(OldPassword))
            {
                return false;
            }
            dal.UpdatePasswordByUserId(UserId, Password);
            return true;
        }
        #endregion  成员方法
    }
}


