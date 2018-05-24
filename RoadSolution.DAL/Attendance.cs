using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadSolution.DBUtils;
using System.Data;
namespace RoadSolution.DAL
{
    /// <summary>
    /// 数据访问类Attendance。
    /// </summary>
    public class Attendance
    {
        public Attendance()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AID", "Attendance");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Attendance where AID='" + AID + "'");
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
        public string Add(RoadSolution.Model.Attendance model)
        {
            model.AID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Attendance(");
            strSql.Append("AID,UserID,Date,Time,Photo,Lat,Lng");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.AID + "',");
            strSql.Append("'" + model.UserID + "',");
            strSql.Append("'" + model.Date + "',");
            strSql.Append("'" + model.Time + "',");
            strSql.Append("'" + model.Photo + "',");
            strSql.Append("" + model.Lat + ",");
            strSql.Append("" + model.Lng + "");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.AID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Attendance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Attendance set ");
            strSql.Append("UserID='" + model.UserID + "',");
            strSql.Append("Date='" + model.Date + "',");
            strSql.Append("Time='" + model.Time + "',");
            strSql.Append("Photo='" + model.Photo + "',");
            strSql.Append("Lat=" + model.Lat + ",");
            strSql.Append("Lng=" + model.Lng + "");
            strSql.Append(" where AID='" + model.AID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string AID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Attendance ");
            strSql.Append(" where AID='" + AID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Attendance GetModel(string AID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Attendance ");
            strSql.Append(" where AID='" + AID + "'");
            RoadSolution.Model.Attendance model = new RoadSolution.Model.Attendance();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.AID = AID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                model.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                if (ds.Tables[0].Rows[0]["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(ds.Tables[0].Rows[0]["Time"].ToString());
                }
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
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
            strSql.Append("select * from Attendance ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by AID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet ListAllAttrNUserinfoBySearch(string Name, string Department, string DateBegin, string DateEnd)
        {
            string strSql = "select  AID,a.UserID,Date,Time,a.Photo,Lat,Lng,Department,Name from [Attendance] a,[Userinfo] u where a.UserID=u.UserID ";
            if(!"".Equals(Name))
                strSql += " and Name like '%"+Name+"%'";
            if(!"".Equals(Department))
                strSql += " and Department like '%"+Department+"%'";
            if(!"".Equals(DateBegin))
                strSql += " and '"+DateBegin+"'<=cast(Date AS varchar(20))";
            if (!"".Equals(DateEnd))
                strSql += " and cast(Date AS varchar(20))>='" + DateEnd + "'";
            return DbHelperSQL.Query(strSql);
        }
        #endregion  成员方法
    }
}
