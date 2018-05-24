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
    /// 数据访问类PersonPosition。
    /// </summary>
    public class PersonPosition
    {
        public PersonPosition()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PositionID", "PersonPosition");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PersonPosition where PositionID='" + PositionID + "'");
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
        public string Add(RoadSolution.Model.PersonPosition model)
        {
            model.PositionID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PersonPosition(");
            strSql.Append("PositionID,UserID,PositionDate,PositionTime,Lat,Lng");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.PositionID + "',");
            strSql.Append("'" + model.UserID + "',");
            strSql.Append("'" + model.PositionDate + "',");
            strSql.Append("'" + model.PositionTime + "',");
            strSql.Append("" + model.Lat + ",");
            strSql.Append("" + model.Lng + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.PositionID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.PersonPosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PersonPosition set ");
            strSql.Append("UserID='" + model.UserID + "',");
            strSql.Append("PositionDate='" + model.PositionDate + "',");
            strSql.Append("PositionTime='" + model.PositionTime + "',");
            strSql.Append("Lat=" + model.Lat + ",");
            strSql.Append("Lng=" + model.Lng + "");
            strSql.Append(" where PositionID='" + model.PositionID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string PositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PersonPosition ");
            strSql.Append(" where PositionID='" + PositionID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.PersonPosition GetModel(string PositionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from PersonPosition ");
            strSql.Append(" where PositionID='" + PositionID + "'");
            RoadSolution.Model.PersonPosition model = new RoadSolution.Model.PersonPosition();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.PositionID = PositionID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                model.PositionDate = ds.Tables[0].Rows[0]["PositionDate"].ToString();
                if (ds.Tables[0].Rows[0]["PositionTime"].ToString() != "")
                {
                    model.PositionTime = DateTime.Parse(ds.Tables[0].Rows[0]["PositionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Lat"].ToString() != "")
                {
                    model.Lat = decimal.Parse(ds.Tables[0].Rows[0]["Lat"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Lng"].ToString() != "")
                {
                    model.Lng = decimal.Parse(ds.Tables[0].Rows[0]["Lng"].ToString());
                }
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
            strSql.Append("select * from PersonPosition ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by PositionID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
