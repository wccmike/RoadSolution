using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RoadSolution.DBUtils;
namespace RoadSolution.DAL
{
    /// <summary>
    /// 数据访问类LeaderShip。
    /// </summary>
    public class LeaderShip
    {
        public LeaderShip()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "LeaderShip");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LeaderShip where UserID='" + UserID + "'");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.LeaderShip model)
        {
            model.UserID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LeaderShip(");
            strSql.Append("UserID,LeaderID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.UserID + "',");
            strSql.Append("'" + model.LeaderID + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.UserID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.LeaderShip model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LeaderShip set ");
            strSql.Append("LeaderID='" + model.LeaderID + "'");
            strSql.Append(" where UserID='" + model.UserID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LeaderShip ");
            strSql.Append(" where UserID='" + UserID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.LeaderShip GetModel(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LeaderShip ");
            strSql.Append(" where UserID='" + UserID + "'");
            RoadSolution.Model.LeaderShip model = new RoadSolution.Model.LeaderShip();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.LeaderID = ds.Tables[0].Rows[0]["LeaderID"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LeaderShip ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UserID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
