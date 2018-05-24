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
    /// 数据访问类Usertype。
    /// </summary>
    public class Usertype
    {
        public Usertype()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("TypeID", "Usertype");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Usertype where TypeID='" + TypeID + "'");
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
        public string Add(RoadSolution.Model.Usertype model)
        {
            model.TypeID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Usertype(");
            strSql.Append("TypeID,TypeName");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.TypeID + "',");
            strSql.Append("'" + model.TypeName + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.TypeID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Usertype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Usertype set ");
            strSql.Append("TypeName='" + model.TypeName + "'");
            strSql.Append(" where TypeID='" + model.TypeID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Usertype ");
            strSql.Append(" where TypeID='" + TypeID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Usertype GetModel(string TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Usertype ");
            strSql.Append(" where TypeID='" + TypeID + "'");
            RoadSolution.Model.Usertype model = new RoadSolution.Model.Usertype();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.TypeID = TypeID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
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
            strSql.Append("select * from Usertype ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by TypeID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
